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
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using oadrlib.lib.oadr2b;
using oadr2b_ven.ven;

namespace oadr2b_ven.UserControls.Events
{
    public partial class ucEvents : UserControl
    {
        /******************************************************************************/
        private Dictionary<int, string> m_payloadTypes = new Dictionary<int, string>();

        private Dictionary<string, oadrDistributeEventTypeOadrEvent> m_idToEvent = new Dictionary<string, oadrDistributeEventTypeOadrEvent>();
        private Dictionary<ListViewItem, oadrDistributeEventTypeOadrEvent> m_lviToEvent = new Dictionary<ListViewItem, oadrDistributeEventTypeOadrEvent>();

        private Dictionary<string, ListViewItem> m_idToLvi = new Dictionary<string, ListViewItem>();

        private IEvents m_callbackHandler;

        private string m_requestID;  // requestID associated with the most recent DistributeEvent message

        private int IND_ID = 0;
        private int IND_STARTTIME = 1;
        private int IND_DURATION = 2;
        private int IND_STATUS = 3;
        private int IND_OPTSTATE = 4;
        private int IND_MARKETCONTEXT = 5;
        private int IND_SIGNALTYPE = 6;
        private int IND_CURRENTVALUE = 7;
        private int IND_VTNCOMMENT = 8;
        private int IND_TESTEVENT = 9;
        private int IND_RESPONSEREQUIRED = 10;

        private Color COL_GREEN = Color.FromArgb(138, 249, 147);
        private Color COL_YELLOW = Color.FromArgb(255, 255, 136);

        // private Dictionary<string, string> m_idToOptState = new Dictionary<string,string>();

        /******************************************************************************/

        public ucEvents()
        {
            InitializeComponent();

            listView1.SelectedIndexChanged += new EventHandler(listView1_SelectedIndexChanged);

            m_payloadTypes.Add(0, "normal");
            m_payloadTypes.Add(1, "moderate");
            m_payloadTypes.Add(2, "high");
            m_payloadTypes.Add(3, "special");

            listView1.Columns.Add("ID");
            listView1.Columns.Add("Start Time");
            listView1.Columns.Add("Duration");
            listView1.Columns.Add("Status");
            listView1.Columns.Add("Opt State");
            listView1.Columns.Add("Market Context");
            listView1.Columns.Add("Signal Type");
            listView1.Columns.Add("Current Value");
            listView1.Columns.Add("VTN Comment");
            listView1.Columns.Add("Test Event");
            listView1.Columns.Add("Response Required");
            
        }

        /******************************************************************************/

        public void setCallbackHandler(IEvents callbackHandler)
        {
            m_callbackHandler = callbackHandler;
        }

        /******************************************************************************/

        private void updateTarget(string[] ids, ListBox listBox)
        {
            listBox.Items.Clear();
            

            if (ids == null)
                return;

            foreach (string id in ids)
            {
                listBox.Items.Add(id);
            }
        }

        /******************************************************************************/

        private void addIntervals(IntervalType[] intervals)
        {
            lstIntervals.Items.Clear();

            foreach (IntervalType intervalType in intervals)
            {
                ListViewItem lvi = new ListViewItem(intervalType.duration.duration);

                lvi.SubItems.Add(((IntervalTypeUidUid)intervalType.Item).text);

                // TODO: handle multiple streamPayloadBase???
                // FIXME: how to get the value of the interval
                float value = 0;//  ((PayloadFloatType)((signalPayloadType)intervalType.streamPayloadBase[0]).Item).value;

                string payload = convertPayloadType(value);

                lvi.SubItems.Add(payload);                

                lstIntervals.Items.Add(lvi);
            }
        }

        /******************************************************************************/

        private string convertPayloadType(float payload)
        { 
            if (!m_payloadTypes.ContainsKey((int)payload))
                return payload.ToString();

            return m_payloadTypes[(int)payload];
        }

        /******************************************************************************/

        private void addSignal(eiEventSignalType signal)
        {
            ListViewItem lvi = new ListViewItem(signal.signalName);

            lvi.SubItems.Add(signal.signalType.ToString());
            lvi.SubItems.Add(signal.signalID);

            String payload = "";
            //if (signal.currentValue.Item.value != null)
            //{
                float value = signal.currentValue.Item.value;
                payload = convertPayloadType(value);
            //}

            lvi.SubItems.Add(payload);

            lstSignals.Items.Add(lvi);

            addIntervals(signal.intervals);
        }

        /******************************************************************************/

        private void updateSelectedEvent(ListViewItem lvi)
        {
            oadrDistributeEventTypeOadrEvent oadrEvent = m_lviToEvent[lvi];

            // event descriptor
            tbEventID.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eventID;
            tbModificationNumber.TextBoxText = oadrEvent.eiEvent.eventDescriptor.modificationNumber.ToString();
            tbPriority.TextBoxText = oadrEvent.eiEvent.eventDescriptor.priority.ToString();
            tbMarketContext.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eiMarketContext.marketContext;

            // oadrEvent.eiEvent.eventDescriptor.createdDateTime.Kind = DateTimeKind.Utc;
            tbCreatedDate.TextBoxText = oadrEvent.eiEvent.eventDescriptor.createdDateTime.ToLocalTime().ToString();

            tbEventStatus.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
            tbTestEvent.TextBoxText = oadrEvent.eiEvent.eventDescriptor.testEvent;
            tbVtnComment.TextBoxText = oadrEvent.eiEvent.eventDescriptor.vtnComment;

            // active period
            tbDTStart.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.ToLocalTime().ToString();
            tbDuration.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration;

            // FIXME: these are all optional.  need a better way to reference the object w/o worrying
            // about exceptions
            try
            {
                tbTolerance.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.tolerance.tolerate.startafter;
            }
            catch { }

            try
            {
                tbNotification.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.xeiNotification.duration;
            }            
            catch { }

            try
            {
                tbRampup.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.xeiRampUp.duration;
            }
            catch { }

            try
            {
                tbRecovery.TextBoxText = oadrEvent.eiEvent.eiActivePeriod.properties.xeiRecovery.duration;
            }
            catch { }

            // targets
            updateTarget(oadrEvent.eiEvent.eiTarget.groupID, lstGroups);
            updateTarget(oadrEvent.eiEvent.eiTarget.resourceID, lstResources);
            updateTarget(oadrEvent.eiEvent.eiTarget.venID, lstVENs);
            updateTarget(oadrEvent.eiEvent.eiTarget.partyID, lstParty);
            
            // signals
            lstSignals.Items.Clear();
            foreach (eiEventSignalType signal in oadrEvent.eiEvent.eiEventSignals.eiEventSignal)
                addSignal(signal);

        }

        /******************************************************************************/

        private void listView1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            ListViewItem lvi = listView1.SelectedItems[0];

            updateSelectedEvent(lvi);
        }

        /******************************************************************************/

        private void addNewEvent(oadrDistributeEventTypeOadrEvent oadrEvent, string eventID)
        {
            ListViewItem lvi = new ListViewItem(eventID);
            lvi.UseItemStyleForSubItems = false;

            for (int x = 0; x < listView1.Columns.Count - 1; x++)
                lvi.SubItems.Add("");

            m_idToEvent.Add(eventID, oadrEvent);
            m_lviToEvent.Add(lvi, oadrEvent);
            m_idToLvi.Add(eventID, lvi);

            listView1.Items.Add(lvi);

            updateEvent(oadrEvent, eventID);          
        }

        /******************************************************************************/

        private void updateEvent(oadrDistributeEventTypeOadrEvent oadrEvent, string eventID)
        {
            ListViewItem lvi = m_idToLvi[eventID];
            
            // lvi.SubItems[1].Text = oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration;

            lvi.SubItems[IND_STARTTIME].Text = oadrEvent.eiEvent.eiActivePeriod.properties.dtstart.datetime.ToLocalTime().ToString();
            lvi.SubItems[IND_DURATION].Text = oadrEvent.eiEvent.eiActivePeriod.properties.duration.duration;

            
            Color color;

            if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.active)
                color = COL_GREEN;
            else if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.near)
                color = COL_YELLOW;
            else
                color = lvi.SubItems[0].BackColor;

            lvi.SubItems[IND_STATUS].BackColor = color;

            lvi.SubItems[IND_STATUS].Text = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();

            lvi.SubItems[IND_MARKETCONTEXT].Text = oadrEvent.eiEvent.eventDescriptor.eiMarketContext.marketContext;

            lvi.SubItems[IND_SIGNALTYPE].Text = oadrEvent.eiEvent.eiEventSignals.eiEventSignal[0].signalType.ToString();


            float value = oadrEvent.eiEvent.eiEventSignals.eiEventSignal[0].currentValue.Item.value;
            string payload = convertPayloadType(value);
            lvi.SubItems[IND_CURRENTVALUE].Text = payload;

            lvi.SubItems[IND_VTNCOMMENT].Text = oadrEvent.eiEvent.eventDescriptor.vtnComment;
            lvi.SubItems[IND_TESTEVENT].Text = oadrEvent.eiEvent.eventDescriptor.testEvent;

            lvi.SubItems[IND_RESPONSEREQUIRED].Text = oadrEvent.oadrResponseRequired.ToString();

            m_idToEvent[eventID] = oadrEvent;
            m_lviToEvent[lvi] = oadrEvent;

            if (listView1.SelectedItems.Count != 0)
            {
                if (listView1.SelectedItems[0] == lvi)
                    updateSelectedEvent(lvi);
            }
        }

        /******************************************************************************/

        public void updateEventsTimeTriggered(IEnumerable<oadrDistributeEventTypeOadrEvent> oadrEvents)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    foreach (oadrDistributeEventTypeOadrEvent oadrEvent in oadrEvents)
                    {
                        string eventID = oadrEvent.eiEvent.eventDescriptor.eventID;

                        try
                        {                            
                            ListViewItem lvi = m_idToLvi[eventID];

                            Color color;

                            if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.active)
                                color = COL_GREEN;
                            else if (oadrEvent.eiEvent.eventDescriptor.eventStatus == EventStatusEnumeratedType.near)
                                color = COL_YELLOW;
                            else
                                color = lvi.SubItems[0].BackColor;

                            lvi.SubItems[IND_STATUS].BackColor = color;
                            lvi.SubItems[IND_STATUS].Text = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
                            tbEventStatus.TextBoxText = oadrEvent.eiEvent.eventDescriptor.eventStatus.ToString();
                        }
                        // certain situations arise where an event that isn't in m_idToLvi
                        // is pased to this funciton.  we can safely ignore those events
                        catch (KeyNotFoundException)
                        {
                        }
                    }
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /******************************************************************************/

        private void removeEvent(string eventID)
        {
            // m_idToEvent
            // m_lvitoEvent
            // m_idToLvi

            m_idToEvent.Remove(eventID);
            ListViewItem lvi = m_idToLvi[eventID];

            m_idToLvi.Remove(eventID);

            m_lviToEvent.Remove(lvi);

            listView1.Items.Remove(lvi);
        }

        /******************************************************************************/

        private void removeAllEventsInterval()
        {
            List<string> eventIDs = new List<string>();

            foreach (string eventID in m_idToEvent.Keys)
                eventIDs.Add(eventID);

            foreach (string eventID in eventIDs)
                removeEvent(eventID);
        }

        /******************************************************************************/

        public void removeAllEvents()
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {

                lock (this)
                {
                    removeAllEventsInterval();
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /******************************************************************************/

        private void checkForRemovedEvents(List<string> currentEventIDs)
        {
            List<string> eventIDs = new List<string>();

            foreach (string eventID in m_idToEvent.Keys)
                eventIDs.Add(eventID);

            foreach (string eventID in eventIDs)
            {
                if (!currentEventIDs.Contains(eventID))
                    removeEvent(eventID);
            }
        }

        /******************************************************************************/

        /*
         * set removeMissingEvents to true when this function is called with the entire list
         * of events, ie, when requestEvents is called on the VTN
         * set removeMissingEvents to false if the incoming distributeEvent updates or adds 
         *   a limited set of events
         */
        // public void updateEvents(oadrDistributeEventType distributeEvent)
        public void updateEvents(Dictionary<string, OadrEventWrapper> activeEvents, string requestID)
        {
            List<string> eventIDs = new List<string>();

            m_requestID = requestID;

            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    if (activeEvents.Count() == 0)
                    {
                        removeAllEventsInterval();
                        return;
                    }

                    foreach (OadrEventWrapper oadrEventWrapper in activeEvents.Values)
                    {
                        oadrDistributeEventTypeOadrEvent oadrEvent = oadrEventWrapper.OadrEvent;
                        string eventID = oadrEvent.eiEvent.eventDescriptor.eventID;

                        if (!m_idToEvent.ContainsKey(eventID))
                            addNewEvent(oadrEvent, eventID);
                        else
                            updateEvent(oadrEvent, eventID);

                        eventIDs.Add(eventID);
                    }

                    // remove events from UI that are no longer in the list                    
                    checkForRemovedEvents(eventIDs);                   
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }

        /******************************************************************************/

        // public void updateOptType(List<oadrDistributeEventTypeOadrEvent> evts, OptTypeType optType)
        public void updateOptType(oadrCreatedEventType createdEvent)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                lock (this)
                {
                    // will be null if VEN is returning an error response
                    if (createdEvent.eiCreatedEvent.eventResponses == null)
                        return;

                    foreach (eventResponsesEventResponse eventResponse in createdEvent.eiCreatedEvent.eventResponses)
                    {
                        string eventID = eventResponse.qualifiedEventID.eventID;

                        if (!m_idToLvi.ContainsKey(eventID))
                            continue;

                        ListViewItem lvi = m_idToLvi[eventID];

                        lvi.SubItems[IND_OPTSTATE].Text = eventResponse.optType.ToString();
                    }
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();
        }


        /******************************************************************************/

        public void updateOptType(oadrCreateOptType createOpt)
        {
            MethodInvoker mi = new MethodInvoker(delegate
            {
                
                lock (this)
                {
                    string eventID = createOpt.qualifiedEventID.eventID;

                    if (!m_idToLvi.ContainsKey(eventID))
                        return;

                    ListViewItem lvi = m_idToLvi[eventID];

                    lvi.SubItems[IND_OPTSTATE].Text = createOpt.optType.ToString();
                }
            });

            // BeginInvoke only needs to be called if we're tyring to update the UI from
            // a thread that did not create it
            if (this.InvokeRequired)
                this.BeginInvoke(mi);
            else
                mi.Invoke();

        }

        /******************************************************************************/

        private List<oadrDistributeEventTypeOadrEvent> getSelectedEvents()
        {
            List<oadrDistributeEventTypeOadrEvent> evts = new List<oadrDistributeEventTypeOadrEvent>();

            foreach (ListViewItem lvi in listView1.SelectedItems)
            {
                oadrDistributeEventTypeOadrEvent evt = m_lviToEvent[lvi];

                evts.Add(evt);
            }
            return evts;
        }

        /******************************************************************************/

        private void optInOut(OptTypeType optType)
        {
            if (listView1.SelectedItems.Count == 0)
                return;

            List<oadrDistributeEventTypeOadrEvent> evts = getSelectedEvents();
            
            if (m_callbackHandler != null)
                m_callbackHandler.processEventOpt(evts, optType, m_requestID, 200, "OK");            
        }

        /******************************************************************************/

        private void optInToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                optInOut(OptTypeType.optIn);
            }
        }

        /******************************************************************************/

        private void optOutToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                optInOut(OptTypeType.optOut);
            }

        }

        /******************************************************************************/

        private void customCreateOptToolStripMenuItem_Click(object sender, EventArgs e)
        {
            lock (this)
            {
                List<string> marketContexts = new List<string>();
                List<string> resources = new List<string>();

                frmCreateOpt createOpt = new frmCreateOpt();

                m_callbackHandler.populateLists(marketContexts, resources);

                createOpt.setLists(marketContexts, resources);

                DialogResult result = createOpt.ShowDialog();

                if (result != DialogResult.OK)
                    return;

                List<oadrDistributeEventTypeOadrEvent> evts = getSelectedEvents();

                if (m_callbackHandler != null)
                    m_callbackHandler.processCreateEventOpt(evts, createOpt.OptType, createOpt.OptReason, createOpt.ResourceID);

            }
        }
    }
}
