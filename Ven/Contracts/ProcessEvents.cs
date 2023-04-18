using Oadr.Library;
using Oadr.Library.Profile2B;
using Oadr.Library.Profile2B.Models;
using Oadr.Ven.UserControls;
using System;
using System.Collections.Generic;
using System.Xml;
using Oadr.Ven.Signal;

namespace Oadr.Ven
{
    public class ProcessEvents
    {
        private readonly Queue<OptUpdate> _queuedOptUpdates = new Queue<OptUpdate>();
        private readonly IVenWrapper _callbacks;

        public Dictionary<string, OadrEventWrapper> ActiveEvents { get; } = new Dictionary<string, OadrEventWrapper>();

        public List<string> MarketContexts { get; } = new List<string>();

        public List<string> CustomSignals { get; } = new List<string>();

        public ProcessEvents(IVenWrapper callbacks)
        {
            _callbacks = callbacks;
            MarketContexts.Add("http://MarketContext1");
        }

        private bool TargetMatches(oadrDistributeEventTypeOadrEvent @event, Ven2B ven)
        {
            try
            {
                if (@event.eiEvent.eiTarget.venID != null)
                {
                    if (@event.eiEvent.eiTarget.venID[0] != ven.VenId)
                    {
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Logger.LogException(ex);
                return false;
            }
            return true;
        }
        
        private bool SignalsValid(oadrDistributeEventTypeOadrEvent @event)
        {
            if (@event.eiEvent.eiEventSignals.eiEventSignal == null)
            {
                return true;
            }

            try
            {
                foreach (var signal in @event.eiEvent.eiEventSignals.eiEventSignal)
                {
                    if (!CustomSignals.Contains(signal.signalName))
                    {
                        OadrSignals.Instance.ValidateSignal(signal);
                    }
                }
            }
            catch (ExceptionInvalidSignal ex)
            {
                _callbacks.LogSystemMessage($"Invalid signal found: {ex.Message}", LogMessageStatus.Warning);
                return false;
            }
            return true;
        }
        
        private bool EventValid(oadrDistributeEventTypeOadrEvent @event, Ven2B ven, string requestId, CreatedEventHelper createdEventHelper)
        {
            // TODO: Log event message when these checks fail.
            if (!TargetMatches(@event, ven))
            {
                _callbacks.LogSystemMessage($"Invalid target in event {@event.eiEvent.eventDescriptor.eventID}", LogMessageStatus.Warning);
                createdEventHelper.AddEvent(@event, requestId, OptTypeType.optOut, 452, "Invalid ID");
                return false;
            }

            if (!MarketContexts.Contains(@event.eiEvent.eventDescriptor.eiMarketContext.marketContext))
            {
                _callbacks.LogSystemMessage($"Invalid Market Context in event {@event.eiEvent.eventDescriptor.eventID}, {@event.eiEvent.eventDescriptor.eiMarketContext.marketContext}", LogMessageStatus.Warning);
                createdEventHelper.AddEvent(@event, requestId, OptTypeType.optOut, 453, "Not Recognized");
                return false;
            }

            if (!SignalsValid(@event))
            {
                createdEventHelper.AddEvent(@event, requestId, OptTypeType.optOut, 460, string.Empty);
                return false;
            }

            return true;
        }
        
        private void CheckForRemovedEvents(List<string> currentEventIDs)
        {
            var eventIds = new List<string>();
            foreach (var eventId in ActiveEvents.Keys)
            {
                eventIds.Add(eventId);
            }

            foreach (var eventId in eventIds)
            {
                if (!currentEventIDs.Contains(eventId))
                {
                    // TODO: Write to event log to indicate event was removed from list of distribute events.
                    _callbacks.LogSystemMessage($"Implicitly cancelling event with ID {eventId}", LogMessageStatus.Info);
                    ActiveEvents.Remove(eventId);
                }
            }
        }
        
        private void ProcessNewEvent(string requestId, OptTypeType oadrOptType, CreatedEventHelper createdEventHelper, oadrDistributeEventTypeOadrEvent @event)
        {
            var eventId = @event.eiEvent.eventDescriptor.eventID;
            ActiveEvents.Add(eventId, new OadrEventWrapper(@event, oadrOptType));

            _callbacks.LogSystemMessage($"Found new event with ID {eventId}", LogMessageStatus.Info);

            // Send a createdEvent message if a response is required.
            if (@event.oadrResponseRequired == ResponseRequiredType.always)
            {
                // Send the default opt for new events that aren't cancelled or completed.
                if (@event.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.cancelled &&
                    @event.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.completed)
                {
                    _callbacks.LogSystemMessage($"Opting new event: {oadrOptType}, {eventId}", LogMessageStatus.Info);
                    createdEventHelper.AddEvent(@event, requestId, oadrOptType);
                }
                else if (@event.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.cancelled)
                {
                    // Event was already cancelled by the time we first received it.
                    // Need to optIn to indicate we acknowledge the cancellation; optOut indicates we cannot cancel.
                    _callbacks.LogSystemMessage($"Opting into cancelled event: {eventId}", LogMessageStatus.Info);
                    createdEventHelper.AddEvent(@event, requestId, OptTypeType.optIn);
                    ActiveEvents[eventId].OptType = OptTypeType.optIn;
                }
                else if (@event.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.completed)
                {
                    // optOut of the previously completed event.
                    _callbacks.LogSystemMessage($"Opting out of completed event: {eventId}", LogMessageStatus.Info);
                    createdEventHelper.AddEvent(@event, requestId, OptTypeType.optOut);
                    ActiveEvents[eventId].OptType = OptTypeType.optOut;
                }
            }
        }

        private void ProcessExistingEvent(string requestId, CreatedEventHelper createdEventHelper, oadrDistributeEventTypeOadrEvent @event)
        {
            var eventId = @event.eiEvent.eventDescriptor.eventID;
            var existingEvent = ActiveEvents[eventId];
            if (existingEvent.OadrEvent.eiEvent.eventDescriptor.modificationNumber > @event.eiEvent.eventDescriptor.modificationNumber)
            {
                // The incoming event has an old modification number; keep tracking the old event and report an error to the VTN.
                _callbacks.LogSystemMessage($"Event update received out of sequence and will be ignored: {eventId}, current={existingEvent.OadrEvent.eiEvent.eventDescriptor.modificationNumber}, incoming={@event.eiEvent.eventDescriptor.modificationNumber}", LogMessageStatus.Warning);
                createdEventHelper.AddEvent(@event, requestId, existingEvent.OptType, 450, "Out of sequence");
                return;
            }

            // If the event was updated (modification numbers don't match), we must re-optIn/Out, provided the event is still active.
            if (existingEvent.OadrEvent.eiEvent.eventDescriptor.modificationNumber != @event.eiEvent.eventDescriptor.modificationNumber &&
                @event.oadrResponseRequired == ResponseRequiredType.always &&
                @event.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.completed)
            {
                // The event was modified; need to send createdEvent again.
                if (@event.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.cancelled)
                {
                    _callbacks.LogSystemMessage($"Opting modified event: {existingEvent.OptType}, {eventId}", LogMessageStatus.Info);
                    createdEventHelper.AddEvent(@event, requestId, existingEvent.OptType);
                }
                // Event was cancelled; need to optIn to indicate we acknowledge the cancellation; optOut indicates we cannot cancel.
                else
                {
                    _callbacks.LogSystemMessage($"Opting into cancelled event: {eventId}", LogMessageStatus.Info);
                    createdEventHelper.AddEvent(@event, requestId, OptTypeType.optIn);
                    ActiveEvents[eventId].OptType = OptTypeType.optIn;
                }
            }

            // If the event is active and is being cancelled and the Start After parameter was set, delay cancelling the event by RandomizedMinutes minutes.
            if (ActiveEvents[eventId].OadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.active &&
                ActiveEvents[eventId].RandomizedMinutes != 0 &&
                @event.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.cancelled)
            {
                // Force the event to remain active.
                @event.eiEvent.eventDescriptor.eventStatus = EventStatusEnumeratedType.active;

                // Set the end time to be used to determine when the event will end.
                ActiveEvents[eventId].InitiateDelayCancel();
                _callbacks.LogSystemMessage($"Active event with randomized start time was cancelled. The event will be cancelled at {ActiveEvents[eventId].DelayCanceledEndTime}.", LogMessageStatus.Info);
            }

            var oldEventStatus = ActiveEvents[eventId].OadrEvent.eiEvent.eventDescriptor.eventStatus;
            var newEventStatus = @event.eiEvent.eventDescriptor.eventStatus;

            // Log event status changes.
            if (oldEventStatus != @event.eiEvent.eventDescriptor.eventStatus)
            {
                _callbacks.LogSystemMessage($"Server reported Event status changed: {eventId}, old={oldEventStatus}, new={newEventStatus}", LogMessageStatus.Info);
            }

            // Replace the event.
            ActiveEvents[eventId].OadrEvent = @event;
        }

        public void Process(oadrDistributeEventType distributeEvent, string requestId, EOptType optType, Ven2B ven)
        {
            // Track list of valid events from distributeEvent object.
            // Will use to match against our list of active events.
            var eventIds = new List<string>();

            // Validate the VTN ID.
            if (distributeEvent.vtnID != ven.VtnId)
            {
                // The VTN ID was invalid; remove all events and send an error message.
                CheckForRemovedEvents(eventIds);

                _callbacks.LogSystemMessage($"Invalid VTN ID: {distributeEvent.vtnID}", LogMessageStatus.Warning);
                CreatedEvent createdEvent = ven.CreatedEvent(requestId, 452, "Invalid ID");
                _callbacks.ProcessCreatedEvent(createdEvent, ActiveEvents, requestId);
                return;
            }

            // The VTN didn't send any events; clear all events we have stored.
            if (distributeEvent.oadrEvent == null)
            {
                CheckForRemovedEvents(eventIds);
                _callbacks.ProcessCreatedEvent(null, ActiveEvents, requestId);
                return;
            }

            var oadrOptType = optType == EOptType.OptIn ? OptTypeType.optIn : OptTypeType.optOut;
            
            // Send a createdEvent with an opt type of the incoming optType for all new events that aren't canceled or completed.
            // optIn/Out of cancelled and completed events as appropriate.
            var createdEventHelper = new CreatedEventHelper();
            foreach (var evt in distributeEvent.oadrEvent)
            {
                var eventId = evt.eiEvent.eventDescriptor.eventID;

                // Validate that the event is for this VEN and MarketContext.
                if (!EventValid(evt, ven, requestId, createdEventHelper))
                {
                    continue;
                }
                eventIds.Add(eventId);
                if (!ActiveEvents.ContainsKey(eventId))
                {
                    ProcessNewEvent(requestId, oadrOptType, createdEventHelper, evt);
                }
                else
                {
                    ProcessExistingEvent(requestId, createdEventHelper, evt);                    
                }

                var eventWrapper = ActiveEvents[eventId];
                if (eventWrapper.RandomizedMinutes != 0)
                {
                    _callbacks.LogSystemMessage($"Event start time delayed due to start after parameter: event ID={eventWrapper.OadrEvent.eiEvent.eventDescriptor.eventID}, start after={eventWrapper.OadrEvent.eiEvent.eiActivePeriod.properties.tolerance.tolerate.startafter}, randomized minutes={eventWrapper.RandomizedMinutes}", LogMessageStatus.Info);
                }
            }

            // Events in ActiveEvents but not in the incoming distributeEvent message must be implicitly canceled.
            CheckForRemovedEvents(eventIds);

            if (createdEventHelper.EventResponses.Count > 0)
            {
                var createdEvent = ven.CreatedEvent(createdEventHelper);
                _callbacks.ProcessCreatedEvent(createdEvent, ActiveEvents, requestId);
            }
            else
            {
                // Still need to call this function to ensure the UI is updated with any event status changes.
                _callbacks.ProcessCreatedEvent(null, ActiveEvents, requestId);
            }
        }
        
        public CreatedEvent ProcessOptUpdate(Ven2B ven, string requestId)
        {
            lock (_queuedOptUpdates)
            {
                if (_queuedOptUpdates.Count == 0)
                {
                    return null;
                }

                var optUpdate = _queuedOptUpdates.Dequeue();
                return ven.CreatedEvent(requestId, optUpdate.Events, optUpdate.OptType);
            }
        }

        public void QueueOptUpdate(List<oadrDistributeEventTypeOadrEvent> events, OptTypeType optType)
        {
            lock (_queuedOptUpdates)
            {
                var optUpdate = new OptUpdate(events, optType);
                _queuedOptUpdates.Enqueue(optUpdate);
            }
        }
        
        public void ClearEvents()
        {
            lock (_queuedOptUpdates)
            {
                ActiveEvents.Clear();
            }
        }
        
        public List<oadrDistributeEventTypeOadrEvent> CheckEventStatusChanges(int serverOffsetSeconds)
        {
            var result = new List<oadrDistributeEventTypeOadrEvent>();
            foreach (var eventKeyValue in ActiveEvents)
            {
                var oadrEvent = eventKeyValue.Value.OadrEvent;
                if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.cancelled)
                {
                    continue;
                }

                var now = DateTime.Now.AddSeconds(serverOffsetSeconds);
                var dtStart = oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.ToLocalTime();
                var duration = XmlConvert.ToTimeSpan(oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration);
                var rampUpDuration = new TimeSpan(0);

                if (oadrEvent.eiEvent.eiActivePeriod.properties.xeiRampUp != null)
                {
                    rampUpDuration = XmlConvert.ToTimeSpan(oadrEvent.eiEvent.eiActivePeriod.properties.xeiRampUp.duration);
                }

                var oldEventStatus = oadrEvent.eiEvent.eventDescriptor.eventStatus;
                EventStatusEnumeratedType newEventStatus;
                if (now < dtStart)
                {
                    newEventStatus = (now + rampUpDuration >= dtStart) ? EventStatusEnumeratedType.near : EventStatusEnumeratedType.far;
                }
                // Duration of 0 indicates an open ended event (no scheduled end time).
                else if (now >= dtStart && (now < dtStart + duration || duration.TotalSeconds == 0))
                {
                    newEventStatus = EventStatusEnumeratedType.active;
                }
                else
                {
                    newEventStatus = EventStatusEnumeratedType.completed;
                }

                // If an active event is cancelled and the event has the start after parameter set
                // the event will remain active for a random number of minutes before cancelling.
                if (eventKeyValue.Value.DelayCancel)
                {
                    if (now >= eventKeyValue.Value.DelayCanceledEndTime)
                    {
                        newEventStatus = EventStatusEnumeratedType.cancelled;
                        _callbacks.LogSystemMessage("Cancelling active event after waiting a randomized minutes", LogMessageStatus.Info);
                    }
                }

                if (newEventStatus != oldEventStatus)
                {
                    oadrEvent.eiEvent.eventDescriptor.eventStatus = newEventStatus;
                    _callbacks.LogSystemMessage($"Event status changed: {oadrEvent.eiEvent.eventDescriptor.eventID}, old={oldEventStatus}, new={newEventStatus}", LogMessageStatus.Info);
                    result.Add(oadrEvent);
                }
            }
            return result;
        }
    }

    public enum EOptType
    {
        OptIn,
        OptOut,
        Manual
    }
}
