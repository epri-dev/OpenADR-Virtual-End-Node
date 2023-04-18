using Oadr.Library.Profile2B.Models;
using Oadr.Ven;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Globalization;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Events
{
    public partial class EventsControl : UserControl
    {
        private readonly Dictionary<int, string> _payloadTypes = new Dictionary<int, string>();
        private readonly Dictionary<string, oadrDistributeEventTypeOadrEvent> _idToEvent = new Dictionary<string, oadrDistributeEventTypeOadrEvent>();
        private readonly Dictionary<ListViewItem, oadrDistributeEventTypeOadrEvent> _itemToEvent = new Dictionary<ListViewItem, oadrDistributeEventTypeOadrEvent>();
        private readonly Dictionary<string, ListViewItem> _idToItem = new Dictionary<string, ListViewItem>();
        private readonly Color _colorGreen = Color.FromArgb(138, 249, 147);
        private readonly Color _colorYellow = Color.FromArgb(255, 255, 136);

        private string _requestId;  // RequestId associated with the most recent oadrDistributeEvent message.
        private const int ListViewIndexStartTime = 1;
        private const int ListViewIndexDuration = 2;
        private const int ListViewIndexStatus = 3;
        private const int ListViewIndexOptState = 4;
        private const int ListViewIndexMarketContext = 5;
        private const int ListViewIndexSignalType = 6;
        private const int ListViewIndexCurrentValue = 7;
        private const int ListViewIndexVtnComment = 8;
        private const int ListViewIndexTestEvent = 9;
        private const int ListViewIndexResponseRequired = 10;

        private IEvents _callbackHandler;

        public EventsControl()
        {
            InitializeComponent();

            _payloadTypes.Add(0, "normal");
            _payloadTypes.Add(1, "moderate");
            _payloadTypes.Add(2, "high");
            _payloadTypes.Add(3, "special");

            lvEvents.Columns.Add("ID");
            lvEvents.Columns.Add("Start Time");
            lvEvents.Columns.Add("Duration");
            lvEvents.Columns.Add("Status");
            lvEvents.Columns.Add("Opt State");
            lvEvents.Columns.Add("Market Context");
            lvEvents.Columns.Add("Signal Type");
            lvEvents.Columns.Add("Current Value");
            lvEvents.Columns.Add("VTN Comment");
            lvEvents.Columns.Add("Test Event");
            lvEvents.Columns.Add("Response Required");

            lvEvents.SelectedIndexChanged += OnEventsSelectedIndexChanged;
        }

        public void SetCallbackHandler(IEvents callbackHandler)
        {
            _callbackHandler = callbackHandler;
        }

        private static void UpdateTarget(string[] ids, ListBox listBox)
        {
            listBox.Items.Clear();
            if (ids == null)
            {
                return;
            }
            foreach (var id in ids)
            {
                listBox.Items.Add(id);
            }
        }

        private void AddIntervals(IntervalType[] intervals)
        {
            lstIntervals.Items.Clear();
            foreach (var intervalType in intervals)
            {
                var item = new ListViewItem(intervalType.duration.duration);
                item.SubItems.Add(((IntervalTypeUidUid)intervalType.Item).text);

                // TODO: handle multiple streamPayloadBase???
                // FIXME: how to get the value of the interval
                const float value = 0; // ((PayloadFloatType)((signalPayloadType)intervalType.streamPayloadBase[0]).Item).value;

                var payload = ConvertPayloadType(value);
                item.SubItems.Add(payload);
                lstIntervals.Items.Add(item);
            }
        }

        private string ConvertPayloadType(float payload)
        {
            if (!_payloadTypes.ContainsKey((int)payload))
            {
                return payload.ToString(CultureInfo.InvariantCulture);
            }
            return _payloadTypes[(int)payload];
        }

        private void AddSignal(eiEventSignalType signal)
        {
            var item = new ListViewItem(signal.signalName);
            item.SubItems.Add(signal.signalType.ToString());
            item.SubItems.Add(signal.signalID);

            var value = signal.currentValue.Item.value;
            var payload = ConvertPayloadType(value);
            item.SubItems.Add(payload);
            lstSignals.Items.Add(item);

            AddIntervals(signal.intervals);
        }
        
        private void UpdateSelectedEvent(ListViewItem lvi)
        {
            var oadrEvent = _itemToEvent[lvi];

            // Event descriptor.
            tbEventID.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eventID;
            tbModificationNumber.TextBoxText = oadrEvent.eiEvent.eventDescriptor.modificationNumber.ToString();
            tbPriority.TextBoxText = oadrEvent.eiEvent.eventDescriptor.priority.ToString();
            tbMarketContext.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eiMarketContext.marketContext;
            tbCreatedDate.TextBoxText = oadrEvent.eiEvent.eventDescriptor.createdDateTime.ToLocalTime().ToString(CultureInfo.InvariantCulture);
            tbEventStatus.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
            tbTestEvent.TextBoxText = oadrEvent.eiEvent.eventDescriptor.testEvent;
            tbVtnComment.TextBoxText = oadrEvent.eiEvent.eventDescriptor.vtnComment;

            // Active period.
            tbDTStart.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.ToLocalTime().ToString(CultureInfo.InvariantCulture);
            tbDuration.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration;

            // FIXME: These are all optional. Need a better way to reference the object w/o worrying.
            // About exceptions.
            try
            {
                tbTolerance.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.tolerance.tolerate.startafter;
            }
            catch
            {
                // ignored
            }

            try
            {
                tbNotification.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.xeiNotification.duration;
            }
            catch
            {
                // ignored
            }

            try
            {
                tbRampup.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.xeiRampUp.duration;
            }
            catch
            {
                // ignored
            }

            try
            {
                tbRecovery.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.xeiRecovery.duration;
            }
            catch
            {
                // ignored
            }

            // Targets.
            UpdateTarget(oadrEvent.eiEvent.eiTarget.groupID, lstGroups);
            UpdateTarget(oadrEvent.eiEvent.eiTarget.resourceID, lstResources);
            UpdateTarget(oadrEvent.eiEvent.eiTarget.venID, lstVENs);
            UpdateTarget(oadrEvent.eiEvent.eiTarget.partyID, lstParty);

            // Signals.
            lstSignals.Items.Clear();
            foreach (var signal in oadrEvent.eiEvent.eiEventSignals.eiEventSignal)
            {
                AddSignal(signal);
            }
        }
        
        private void OnEventsSelectedIndexChanged(object sender, EventArgs e)
        {
            if (lvEvents.SelectedItems.Count == 0)
            {
                return;
            }
            UpdateSelectedEvent(lvEvents.SelectedItems[0]);
        }
        
        private void AddNewEvent(oadrDistributeEventTypeOadrEvent oadrEvent, string eventId)
        {
            var lvi = new ListViewItem(eventId)
            {
                UseItemStyleForSubItems = false
            };

            for (var x = 0; x < lvEvents.Columns.Count - 1; x++)
            {
                lvi.SubItems.Add(string.Empty);
            }

            _idToEvent.Add(eventId, oadrEvent);
            _itemToEvent.Add(lvi, oadrEvent);
            _idToItem.Add(eventId, lvi);
            lvEvents.Items.Add(lvi);
            UpdateEvent(oadrEvent, eventId);
        }
        
        private void UpdateEvent(oadrDistributeEventTypeOadrEvent oadrEvent, string eventId)
        {
            var item = _idToItem[eventId];
            item.SubItems[ListViewIndexStartTime].Text = oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.ToLocalTime().ToString(CultureInfo.InvariantCulture);
            item.SubItems[ListViewIndexDuration].Text = oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration;

            Color color;
            switch (oadrEvent.eiEvent.eventDescriptor.eventStatus)
            {
                case EventStatusEnumeratedType.active:
                    color = _colorGreen;
                    break;
                case EventStatusEnumeratedType.near:
                    color = _colorYellow;
                    break;
                default:
                    color = item.SubItems[0].BackColor;
                    break;
            }

            item.SubItems[ListViewIndexStatus].BackColor = color;
            item.SubItems[ListViewIndexStatus].Text = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
            item.SubItems[ListViewIndexMarketContext].Text = oadrEvent.eiEvent.eventDescriptor.eiMarketContext.marketContext;
            item.SubItems[ListViewIndexSignalType].Text = oadrEvent.eiEvent.eiEventSignals.eiEventSignal[0].signalType.ToString();
            
            var value = oadrEvent.eiEvent.eiEventSignals.eiEventSignal[0].currentValue.Item.value;
            var payload = ConvertPayloadType(value);
            item.SubItems[ListViewIndexCurrentValue].Text = payload;
            item.SubItems[ListViewIndexVtnComment].Text = oadrEvent.eiEvent.eventDescriptor.vtnComment;
            item.SubItems[ListViewIndexTestEvent].Text = oadrEvent.eiEvent.eventDescriptor.testEvent;
            item.SubItems[ListViewIndexResponseRequired].Text = oadrEvent.oadrResponseRequired.ToString();

            _idToEvent[eventId] = oadrEvent;
            _itemToEvent[item] = oadrEvent;
            if (lvEvents.SelectedItems.Count != 0)
            {
                if (lvEvents.SelectedItems[0] == item)
                {
                    UpdateSelectedEvent(item);
                }
            }
        }

        public void UpdateEventsTimeTriggered(IEnumerable<oadrDistributeEventTypeOadrEvent> oadrEvents)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    foreach (var oadrEvent in oadrEvents)
                    {
                        var eventId = oadrEvent.eiEvent.eventDescriptor.eventID;
                        try
                        {
                            var item = _idToItem[eventId];
                            Color color;
                            if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.active)
                            {
                                color = _colorGreen;
                            }
                            else if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.near)
                            {
                                color = _colorYellow;
                            }
                            else
                            {
                                color = item.SubItems[0].BackColor;
                            }

                            item.SubItems[ListViewIndexStatus].BackColor = color;
                            item.SubItems[ListViewIndexStatus].Text = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
                            tbEventStatus.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
                        }
                        // Certain situations arise where an event that isn't in _idToItem is passed to this method.
                        // We can safely ignore those events.
                        catch (KeyNotFoundException)
                        {
                            // ignore
                        }
                    }
                }
            });
            
            Invoke(mi);
        }
        
        private void RemoveEvent(string eventId)
        {
            _idToEvent.Remove(eventId);
            _idToItem.Remove(eventId);
            var item = _idToItem[eventId];
            _itemToEvent.Remove(item);
            lvEvents.Items.Remove(item);
        }
        
        private void RemoveAllEventsInterval()
        {
            var eventIds = new List<string>();

            foreach (var eventId in _idToEvent.Keys)
            {
                eventIds.Add(eventId);
            }

            foreach (var eventId in eventIds)
            {
                RemoveEvent(eventId);
            }
        }
        
        public void RemoveAllEvents()
        {
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    RemoveAllEventsInterval();
                }
            });
            
            Invoke(mi);
        }
        
        private void CheckForRemovedEvents(List<string> currentEventIds)
        {
            var eventIds = new List<string>();
            foreach (var eventId in _idToEvent.Keys)
            {
                eventIds.Add(eventId);
            }
            foreach (var eventId in eventIds)
            {
                if (!currentEventIds.Contains(eventId))
                {
                    RemoveEvent(eventId);
                }
            }
        }
        
        public void UpdateEvents(Dictionary<string, OadrEventWrapper> activeEvents, string requestId)
        {
            var eventIds = new List<string>();
            _requestId = requestId;
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    if (activeEvents.Count == 0)
                    {
                        RemoveAllEventsInterval();
                        return;
                    }

                    foreach (var oadrEventWrapper in activeEvents.Values)
                    {
                        var oadrEvent = oadrEventWrapper.OadrEvent;
                        var eventId = oadrEvent.eiEvent.eventDescriptor.eventID;
                        if (!_idToEvent.ContainsKey(eventId))
                        {
                            AddNewEvent(oadrEvent, eventId);
                        }
                        else
                        {
                            UpdateEvent(oadrEvent, eventId);
                        }
                        eventIds.Add(eventId);
                    }
                    // Remove events from UI that are no longer in the list.
                    CheckForRemovedEvents(eventIds);
                }
            });
            
            Invoke(mi);
        }
        
        public void UpdateOptType(oadrCreatedEventType createdEvent)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    // Will be null if VEN is returning an error response.
                    if (createdEvent.eiCreatedEvent.eventResponses == null)
                    {
                        return;
                    }

                    foreach (var eventResponse in createdEvent.eiCreatedEvent.eventResponses)
                    {
                        var eventId = eventResponse.qualifiedEventID.eventID;
                        if (!_idToItem.ContainsKey(eventId))
                        {
                            continue;
                        }

                        var item = _idToItem[eventId];
                        item.SubItems[ListViewIndexOptState].Text = eventResponse.optType.ToString();
                    }
                }
            });
            
            Invoke(mi);
        }
        
        public void UpdateOptType(oadrCreateOptType createOpt)
        {
            var mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    var eventId = createOpt.qualifiedEventID.eventID;
                    if (!_idToItem.ContainsKey(eventId))
                    {
                        return;
                    }

                    var item = _idToItem[eventId];
                    item.SubItems[ListViewIndexOptState].Text = createOpt.optType.ToString();
                }
            });

            Invoke(mi);
        }

        private List<oadrDistributeEventTypeOadrEvent> GetSelectedEvents()
        {
            var events = new List<oadrDistributeEventTypeOadrEvent>();
            foreach (ListViewItem item in lvEvents.SelectedItems)
            {
                events.Add(_itemToEvent[item]);
            }
            return events;
        }
        
        private void OptInOut(OptTypeType optType)
        {
            if (lvEvents.SelectedItems.Count == 0)
            {
                return;
            }

            var events = GetSelectedEvents();
            _callbackHandler?.ProcessEventOpt(events, optType, _requestId, 200, "OK");
        }

        private void Invoke(MethodInvoker mi)
        {
            // BeginInvoke only needs to be called if we're trying to update the UI from a thread that did not create it.
            if (InvokeRequired)
            {
                BeginInvoke(mi);
            }
            else
            {
                mi.Invoke();
            }
        }
        
        private void OnOptInToolStripMenuItemClick(object sender, EventArgs e)
        {
            lock (this)
            {
                OptInOut(OptTypeType.optIn);
            }
        }
        
        private void OnOptOutToolStripMenuItemClick(object sender, EventArgs e)
        {
            lock (this)
            {
                OptInOut(OptTypeType.optOut);
            }
        }

        private void OnCustomCreateOptToolStripMenuItemClick(object sender, EventArgs e)
        {
            lock (this)
            {
                var marketContexts = new List<string>();
                var resources = new List<string>();

                var createOpt = new CreateOptForm();
                _callbackHandler.PopulateLists(marketContexts, resources);
                createOpt.SetLists(marketContexts, resources);

                var result = createOpt.ShowDialog();
                if (result != DialogResult.OK)
                {
                    return;
                }

                var events = GetSelectedEvents();
                _callbackHandler?.ProcessCreateEventOpt(events, createOpt.OptType, createOpt.OptReason, createOpt.ResourceId);
            }
        }
    }
}
