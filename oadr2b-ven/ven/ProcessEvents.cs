//////////////////////////////////////////////////////////////////////////////////////
// Copyright (c) 2014, Electric Power Research Institute (EPRI)
// All rights reserved.
//
// oadr2b-ven, oadrlib, and oadr-test ("this software") are licensed under the 
// BSD 3-Clause license.
//
// Redistribution and use in source and binary forms, with or without modification, 
// are permitted provided that the following conditions are met:
//
//   * Redistributions of source code must retain the above copyright notice, this 
//     list of conditions and the following disclaimer.
//     
//   * Redistributions in binary form must reproduce the above copyright notice, 
//     this list of conditions and the following disclaimer in the documentation 
//     and/or other materials provided with the distribution.
//     
//   * Neither the name of EPRI nor the names of its contributors may 
//     be used to endorse or promote products derived from this software without 
//     specific prior written permission.
//
// THIS SOFTWARE IS PROVIDED BY THE COPYRIGHT HOLDERS AND CONTRIBUTORS "AS IS" AND 
// ANY EXPRESS OR IMPLIED WARRANTIES, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED 
// WARRANTIES OF MERCHANTABILITY AND FITNESS FOR A PARTICULAR PURPOSE ARE DISCLAIMED. 
// IN NO EVENT SHALL THE COPYRIGHT HOLDER OR CONTRIBUTORS BE LIABLE FOR ANY DIRECT, 
// INDIRECT, INCIDENTAL, SPECIAL, EXEMPLARY, OR CONSEQUENTIAL DAMAGES (INCLUDING, BUT 
// NOT LIMITED TO, PROCUREMENT OF SUBSTITUTE GOODS OR SERVICES; LOSS OF USE, DATA, OR 
// PROFITS; OR BUSINESS INTERRUPTION) HOWEVER CAUSED AND ON ANY THEORY OF LIABILITY, 
// WHETHER IN CONTRACT, STRICT LIABILITY, OR TORT (INCLUDING NEGLIGENCE OR OTHERWISE) 
// ARISING IN ANY WAY OUT OF THE USE OF THIS SOFTWARE, EVEN IF ADVISED OF THE POSSIBILITY 
// OF SUCH DAMAGE.
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using oadr2b_ven.ven;
using oadr2b_ven.ven.signal;
using oadrlib.lib.oadr2b;

namespace oadr2b_ven
{
    public enum eOptType
    {
        OptIn,
        OptOut,
        Manual
    };

    public class ProcessEvents
    {
        private Dictionary<string, OadrEventWrapper> m_idToEvent = new Dictionary<string, OadrEventWrapper>();
        private Queue<OptUpdate> m_qOptUpdate = new Queue<OptUpdate>();

        private List<string> m_marketContexts = new List<string>();
        private List<string> m_customSignals = new List<string>();

        private IVenWrapper m_callbacks;

        /**********************************************************/

        public ProcessEvents(IVenWrapper callbacks)
        {
            m_callbacks = callbacks;

            m_marketContexts.Add("http://MarketContext1");
        }

        /**********************************************************/

        public Dictionary<string, OadrEventWrapper> ActiveEvents
        {
            get { return m_idToEvent; }
        }

        /**********************************************************/

        public List<string> MarketContexts
        {
            get { return m_marketContexts; }            
        }

        /**********************************************************/

        public List<string> CustomSignals
        {
            get { return m_customSignals; }
        }

        /**********************************************************/

        private bool targetMatches(oadrDistributeEventTypeOadrEvent evt, VEN2b ven)
        {
            try
            {
                if (evt.eiEvent.eiTarget.venID != null)
                {
                    if (evt.eiEvent.eiTarget.venID[0] != ven.VENID)
                        return false;
                }
            }
            catch (Exception ex)
            {
                oadrlib.lib.helper.Logger.logException(ex);
                return false;
            }

            return true;
        }

        /**********************************************************/

        private bool signalsValid(oadrDistributeEventTypeOadrEvent evt)
        {
            if (evt.eiEvent.eiEventSignals.eiEventSignal == null)
                return true;

            try
            {
                for (int index = 0; index < evt.eiEvent.eiEventSignals.eiEventSignal.Length; index++ )
                {
                    eiEventSignalType signal = evt.eiEvent.eiEventSignals.eiEventSignal[index];

                    if (!m_customSignals.Contains(signal.signalName))
                        OadrSignals.Instance.validateSignal(signal);
                }
            }
            catch (ExceptionInvalidSignal ex)
            {
                m_callbacks.logSystemMessage("Invalid signal found: " + ex.Message, UserControls.Log.WebLogView.eWebLogMessageStatus.WARNING);
                return false;
            }

            return true;
        }

        /**********************************************************/

        private bool eventValid(oadrDistributeEventTypeOadrEvent evt, VEN2b ven, string requestID, CreatedEventHelper createdEventHelper)
        {
            // TODO: log event message when these checks fail

            if (!targetMatches(evt, ven))
            {
                m_callbacks.logSystemMessage("Invalid target in event " + evt.eiEvent.eventDescriptor.eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.WARNING);
                createdEventHelper.addEvent(evt, requestID, OptTypeType.optOut, 452, "Invalid ID");
                return false;
            }

            if (!m_marketContexts.Contains(evt.eiEvent.eventDescriptor.eiMarketContext.marketContext))
            {
                m_callbacks.logSystemMessage("Invalid Market Context in event " + evt.eiEvent.eventDescriptor.eventID + ", " + evt.eiEvent.eventDescriptor.eiMarketContext.marketContext, UserControls.Log.WebLogView.eWebLogMessageStatus.WARNING);
                createdEventHelper.addEvent(evt, requestID, OptTypeType.optOut, 453, "Not Recognized");
                return false;
            }

            if (!signalsValid(evt))
            {
                createdEventHelper.addEvent(evt, requestID, OptTypeType.optOut, 460, "");
                return false;
            }

            return true;
        }

        /**********************************************************/

        private void checkForRemovedEvents(List<string> currentEventIDs)
        {
            List<string> eventIDs = new List<string>();

            foreach (string eventID in m_idToEvent.Keys)
                eventIDs.Add(eventID);

            foreach (string eventID in eventIDs)
            {
                if (!currentEventIDs.Contains(eventID))
                {
                    // TODO: write to event log to inidcate event was
                    // removed from list of distribute events
                    m_callbacks.logSystemMessage("Implicitly cancelling event with id " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                    m_idToEvent.Remove(eventID);
                }
            }
        }

        /**********************************************************/


        private void processNewEvent(string requestID, OptTypeType oadrOptType, CreatedEventHelper createdEventHelper, oadrDistributeEventTypeOadrEvent evt)
        {
            string eventID = evt.eiEvent.eventDescriptor.eventID;

            m_idToEvent.Add(eventID, new OadrEventWrapper(evt, oadrOptType));

            m_callbacks.logSystemMessage("Found new event " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);

            // send a createdEvent message if a response is required
            if (evt.oadrResponseRequired == ResponseRequiredType.always)
            {
                // send the default opt for new events that aren't cancelled or completed
                if (evt.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.cancelled &&
                    evt.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.completed)
                {
                    m_callbacks.logSystemMessage("Opting new event: " + oadrOptType.ToString() + " , " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);

                    createdEventHelper.addEvent(evt, requestID, oadrOptType, 200, "OK");
                }
                else if (evt.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.cancelled)
                {
                    // event was already cancelled by the time we first received it; 
                    // need to optIn to indicate we ackowledge the cancellation
                    // optOut indicates we cannot cancel
                    m_callbacks.logSystemMessage("Opting into cancelled event: " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                    createdEventHelper.addEvent(evt, requestID, OptTypeType.optIn, 200, "OK");
                    m_idToEvent[eventID].OptType = OptTypeType.optIn;
                }
                else if (evt.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.completed)
                {
                    // optOut of the previously completed event
                    m_callbacks.logSystemMessage("Opting out of completed event: " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                    createdEventHelper.addEvent(evt, requestID, OptTypeType.optOut, 200, "OK");
                    m_idToEvent[eventID].OptType = OptTypeType.optOut;
                }
            }
        }

        /**********************************************************/

        private void processExistingEvent(string requestID, CreatedEventHelper createdEventHelper, oadrDistributeEventTypeOadrEvent evt)
        {
            string eventID = evt.eiEvent.eventDescriptor.eventID;

            OadrEventWrapper existingEvent = m_idToEvent[eventID];

            if (existingEvent.OadrEvent.eiEvent.eventDescriptor.modificationNumber > evt.eiEvent.eventDescriptor.modificationNumber)
            {
                // the incoming event has an old modification number; keep tracking the old event
                // and report an error to the VTN
                m_callbacks.logSystemMessage("Event update received out of sequence and will be ignored: " + eventID + ", current=" + existingEvent.OadrEvent.eiEvent.eventDescriptor.modificationNumber.ToString() + ", incoming=" + evt.eiEvent.eventDescriptor.modificationNumber.ToString(), UserControls.Log.WebLogView.eWebLogMessageStatus.WARNING);
                createdEventHelper.addEvent(evt, requestID, existingEvent.OptType, 450, "Out of sequence");
                return;
            }

            // if the event was updated (modification numbers don't match), we must re-optin/out, provided
            // the event is still active
            if (existingEvent.OadrEvent.eiEvent.eventDescriptor.modificationNumber != evt.eiEvent.eventDescriptor.modificationNumber &&
                evt.oadrResponseRequired == ResponseRequiredType.always &&
                evt.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.completed)
            {
                // the event was modified; need to send createdEvent again
                if (evt.eiEvent.eventDescriptor.eventStatus != EventStatusEnumeratedType.cancelled)
                {
                    m_callbacks.logSystemMessage("Opting modified event: " + existingEvent.OptType.ToString() + " , " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                    createdEventHelper.addEvent(evt, requestID, existingEvent.OptType, 200, "OK");
                }
                // event was cancelled; need to optIn to indicate we ackowledge the cancellation
                // optOut indicates we cannot cancel
                else
                {
                    m_callbacks.logSystemMessage("Opting into cancelled event: " + eventID, UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                    createdEventHelper.addEvent(evt, requestID, OptTypeType.optIn, 200, "OK");
                    m_idToEvent[eventID].OptType = OptTypeType.optIn;
                }
            }

            // if the event is active and is being cancelled and the Start After parameter was set,
            // delay cancelling the event by RandomizedMinutes minutes
            if (m_idToEvent[eventID].OadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.active &&
                m_idToEvent[eventID].RandomizedMinutes != 0 && evt.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.cancelled)
            {
                // force the event to remain active
                evt.eiEvent.eventDescriptor.eventStatus = EventStatusEnumeratedType.active;

                // set the end time to be used to detemermine when the event will end
                m_idToEvent[eventID].initiateDelayCancel();

                m_callbacks.logSystemMessage(string.Format("Active event with randomized start time was cancelled.  event will be cancelled at ",
                    m_idToEvent[eventID].DelayCanceledEndTime.ToString()), UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);

            }

            EventStatusEnumeratedType oldEventStatus = m_idToEvent[eventID].OadrEvent.eiEvent.eventDescriptor.eventStatus;
            EventStatusEnumeratedType newEventStatus = evt.eiEvent.eventDescriptor.eventStatus;

            // log event status changes
            if (oldEventStatus != evt.eiEvent.eventDescriptor.eventStatus)
                m_callbacks.logSystemMessage("Server reported Event status changed: " + eventID + ", old=" + oldEventStatus.ToString() + ", new=" + newEventStatus.ToString(), UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);

            // replace the event
            m_idToEvent[eventID].OadrEvent = evt;
            return;
        }

        /**********************************************************/

        public void processEvents(oadrDistributeEventType distributeEvent, string requestID, eOptType optType, VEN2b ven)
        {
            List<string> eventIDs = new List<string>();     // track list of valid events from distributeEvent object
                                                            // will use to match against our list of active events
            
            // validate the VTN id
            if (distributeEvent.vtnID != ven.VTNID)
            {
                // the VTN ID was invalid; remove all events and send an error message
                checkForRemovedEvents(eventIDs);

                m_callbacks.logSystemMessage("Invalid VTN ID: " + distributeEvent.vtnID, UserControls.Log.WebLogView.eWebLogMessageStatus.WARNING);

                CreatedEvent createdEvent = ven.createdEvent(requestID, 452, "Invalid ID");

                m_callbacks.processCreatedEvent(createdEvent, m_idToEvent, requestID);
                
                return;
            }

            // the VTN didn't send any events; clear all events we have stored
            if (distributeEvent.oadrEvent == null)
            {
                checkForRemovedEvents(eventIDs);
                m_callbacks.processCreatedEvent(null, m_idToEvent, requestID);
                return;
            }

            OptTypeType oadrOptType = (optType == eOptType.OptIn ? OptTypeType.optIn : OptTypeType.optOut);
            
            // send a createdEvent with an opt type of the incoming optType for all new events
            // that aren't canceled or completed.  optIn/out of cancelled and completed events as appropriate
            CreatedEventHelper createdEventHelper = new CreatedEventHelper();

            foreach (oadrDistributeEventTypeOadrEvent evt in distributeEvent.oadrEvent)
            {
                string eventID = evt.eiEvent.eventDescriptor.eventID;

                // validate that the event is for this VEN and MarketContext
                if (!eventValid(evt, ven, requestID, createdEventHelper))
                    continue;

                eventIDs.Add(eventID);                
                
                if (!m_idToEvent.ContainsKey(eventID))
                {
                    processNewEvent(requestID, oadrOptType, createdEventHelper, evt);
                }
                else
                {
                    processExistingEvent(requestID, createdEventHelper, evt);                    
                }

                OadrEventWrapper eventWrapper = m_idToEvent[eventID];

                if (eventWrapper.RandomizedMinutes != 0)
                {
                    m_callbacks.logSystemMessage(string.Format("Event start time delayed due to start after parameter: event ID={0}, start after={1}, randomized minutes={2}",
                        eventWrapper.OadrEvent.eiEvent.eventDescriptor.eventID, eventWrapper.OadrEvent.eiEvent.eiActivePeriod.properties.tolerance.tolerate.startafter,
                        eventWrapper.RandomizedMinutes), UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                }
            }

            // events in m_idToEvent but not in the incoming distributeEvent message must be
            // implicitly canceled
            checkForRemovedEvents(eventIDs);

            if (createdEventHelper.EventResponses.Count > 0)
            {
                CreatedEvent createdEvent = ven.createdEvent(createdEventHelper);

                m_callbacks.processCreatedEvent(createdEvent, m_idToEvent, requestID);
            }
            else
                // still need to call this function to ensure the UI is updated with any event status changes
                m_callbacks.processCreatedEvent(null, m_idToEvent, requestID);
        }

        /**********************************************************/

        public CreatedEvent processOptUpdate(VEN2b ven, string requestID)
        {
            lock (m_qOptUpdate)
            {
                if (m_qOptUpdate.Count == 0)
                    return null;

                OptUpdate optUpdate = m_qOptUpdate.Dequeue();

                return ven.createdEvent(requestID, optUpdate.Evts, optUpdate.OptType);
            }
        }

        /**********************************************************/

        public void queueOptUpdate(List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType)
        {
            lock (m_qOptUpdate)
            {
                OptUpdate optUpdate = new OptUpdate(evts, optType);
                m_qOptUpdate.Enqueue(optUpdate);
            }
        }

        /**********************************************************/

        public void clearEvents()
        {
            lock (m_qOptUpdate)
            {
                m_idToEvent.Clear();
            }
        }

        /**********************************************************/
        public List<oadrDistributeEventTypeOadrEvent> checkEventStatusChanges(int serverOffsetSeconds)
        {
            var result = new List<oadrDistributeEventTypeOadrEvent>();

            foreach (KeyValuePair<string, OadrEventWrapper> eventKeyValue in m_idToEvent)
            {
                oadrDistributeEventTypeOadrEvent oadrEvent = eventKeyValue.Value.OadrEvent;

                if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.cancelled)
                    continue;

                DateTime now = DateTime.Now.AddSeconds(serverOffsetSeconds);

                DateTime dtstart = oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.ToLocalTime();

                TimeSpan duration = XmlConvert.ToTimeSpan(oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration);

                TimeSpan rampUpDuration = new TimeSpan(0);

                if (oadrEvent.eiEvent.eiActivePeriod.properties.xeiRampUp != null)
                {
                    rampUpDuration = XmlConvert.ToTimeSpan(oadrEvent.eiEvent.eiActivePeriod.properties.xeiRampUp.duration);
                }

                EventStatusEnumeratedType oldEventStatus = oadrEvent.eiEvent.eventDescriptor.eventStatus;
                EventStatusEnumeratedType newEventStatus;

                if (now < dtstart)
                {
                    newEventStatus = (now + rampUpDuration >= dtstart) ? EventStatusEnumeratedType.near 
                                                                           : EventStatusEnumeratedType.far;
                }
                // duration of 0 indicates an open ended event (no scheduled end time)
                else if(now >= dtstart && (now < dtstart + duration || duration.TotalSeconds == 0))
                {
                    newEventStatus = EventStatusEnumeratedType.active;
                }
                else
                {
                    newEventStatus = EventStatusEnumeratedType.completed;
                }

                // if an active event is cancelled and the event has the start after parameter set
                // the event will remain active for a random number of minutes before cancelling
                if (eventKeyValue.Value.DelayCancel)
                {
                    if (now >= eventKeyValue.Value.DelayCanceledEndTime)
                    {
                        newEventStatus = EventStatusEnumeratedType.cancelled;

                        m_callbacks.logSystemMessage("Cancelling active event after waiting a randomized minutes", UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);
                    }
                }

                if (newEventStatus != oldEventStatus)
                {
                    oadrEvent.eiEvent.eventDescriptor.eventStatus = newEventStatus;

                    m_callbacks.logSystemMessage("Event status changed: " + oadrEvent.eiEvent.eventDescriptor.eventID + ", old=" + oldEventStatus.ToString() + ", new=" + newEventStatus.ToString(), UserControls.Log.WebLogView.eWebLogMessageStatus.INFO);

                    //oadrlib.lib.helper.Logger.logMessage(String.Format("event {0} status change: {1} to {2}",
                    //                                     eventKeyValue.Key, oldEventStatus, newEventStatus));

                    result.Add(oadrEvent);
                }
            }

            return result;
        }
    }
}
