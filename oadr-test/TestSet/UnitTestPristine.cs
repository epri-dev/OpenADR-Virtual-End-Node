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
using System.IO;
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oadr_test.helper.pristine;
using oadrlib.lib.helper;

using oadr_test.helper;
using System.Globalization;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestPristine
    {
        /// <summary>
        /// generate a distributeEvent message for Quality Logic to verify
        /// by default, the VS xsd compiler does not add the subtituion group types to
        /// ItemBase which is used to set the units of a signal.  Is this valid XML?  Should
        /// all VENs/VTNs be able to parse this XML?
        /// 
        /// this function is not complete ...
        /// </summary>
        [TestMethod]
        public void generateOadrDistributeEvent()
        {
            oadrPayload payload = new oadrPayload();

            payload.oadrSignedObject = new oadrSignedObject();

            oadrDistributeEventType distributeEvent = new oadrDistributeEventType();

            distributeEvent.schemaVersion = "2.0b";

            distributeEvent.eiResponse = new EiResponseType();
            distributeEvent.eiResponse.requestID = "";
            distributeEvent.eiResponse.responseCode = "200";
            distributeEvent.eiResponse.responseDescription = "OK";

            distributeEvent.requestID = "OadrDisReq050214_092500_050";
            distributeEvent.vtnID = "TH_VTN";

            payload.oadrSignedObject.Item = distributeEvent;

            distributeEvent.oadrEvent = new oadrDistributeEventTypeOadrEvent[1];

            oadrDistributeEventTypeOadrEvent oadrEvent = new oadrDistributeEventTypeOadrEvent();

            distributeEvent.oadrEvent[0] = oadrEvent;
           
            eiEventType eiEvent = new eiEventType();

            oadrEvent.eiEvent = eiEvent;

            eiEvent.eventDescriptor = new eventDescriptorType();            

            eiEvent.eventDescriptor.eventID = "Event050214_092500_550_0";
            eiEvent.eventDescriptor.modificationNumber = 0;
            eiEvent.eventDescriptor.modificationDateTime = DateTime.ParseExact("2014-02-05T17:25:00Z", "yyyy-MM-ddTHH:mm:00Z", CultureInfo.InvariantCulture);
            eiEvent.eventDescriptor.modificationReason = "Update";
            eiEvent.eventDescriptor.priority = 1;
            eiEvent.eventDescriptor.eiMarketContext = new eventDescriptorTypeEiMarketContext();
            eiEvent.eventDescriptor.eiMarketContext.marketContext = "http://MarketContext1";
            eiEvent.eventDescriptor.createdDateTime = DateTime.ParseExact("2014-02-05T17:25:00Z", "yyyy-MM-ddTHH:mm:00Z", CultureInfo.InvariantCulture);
            eiEvent.eventDescriptor.eventStatus = EventStatusEnumeratedType.completed;
            eiEvent.eventDescriptor.testEvent = "false";
            eiEvent.eventDescriptor.vtnComment = "Sample Payload";                       
            eiEvent.eventDescriptor.vtnComment = "comment";

            // active period
            eiEvent.eiActivePeriod = new eiActivePeriodType();
            eiEvent.eiActivePeriod.properties = new properties();
            eiEvent.eiActivePeriod.properties.dtstart = new dtstart();
            eiEvent.eiActivePeriod.properties.dtstart.datetime = DateTime.ParseExact("2014-02-05T17:35:00Z", "yyyy-MM-ddTHH:mm:00Z", CultureInfo.InvariantCulture);
            eiEvent.eiActivePeriod.properties.duration = new DurationPropType();
            eiEvent.eiActivePeriod.properties.duration.duration = "PT5M";
            eiEvent.eiActivePeriod.properties.xeiNotification = new DurationPropType();
            eiEvent.eiActivePeriod.properties.xeiNotification.duration = "PT1M";
            
            // signals
            eiEvent.eiEventSignals = new eiEventSignalsType();
            eiEvent.eiEventSignals.eiEventSignal = new eiEventSignalType[1];

            eiEventSignalType signal = new eiEventSignalType();
            signal.intervals = new IntervalType[1];
            signal.intervals[0] = new IntervalType();
            signal.intervals[0].duration = new DurationPropType();
            signal.intervals[0].duration.duration = "PT5M";
            IntervalTypeUidUid uid = new IntervalTypeUidUid();
            uid.text = "0";
            signal.intervals[0].Item = uid;

            // signal payload
            signal.intervals[0].streamPayloadBase = new StreamPayloadBaseType[1];

            signalPayloadType val = new signalPayloadType();
            PayloadFloatType pft = new PayloadFloatType();
            pft.value = (float)3.14;
            val.Item = pft;
            signal.intervals[0].streamPayloadBase[0] = val;

            eiEvent.eiEventSignals.eiEventSignal[0] = signal;

            // signal type
            signal.signalName = SignalNameEnumeratedType.ELECTRICITY_PRICE.ToString();
            signal.signalType = SignalTypeEnumeratedType.price;
            signal.signalID = "SIG_02";

            currencyType currency = new currencyType();
            currency.itemDescription = currencyItemDescriptionType.currencyPerKWh;
            currency.itemUnits = ISO3AlphaCurrencyCodeContentType.USD;
            currency.siScaleCode = SiScaleCodeType.none;
           
            signal.itemBase = currency;

            signal.currentValue = new currentValueType();
            PayloadFloatType pft2 = new PayloadFloatType();
            pft2.value = (float)0.0;
            signal.currentValue.Item = pft2;

            signal.eiTarget = new EiTargetType();
            signal.eiTarget.resourceID = new string[2];
            signal.eiTarget.resourceID[0] = "resource1";
            signal.eiTarget.resourceID[1] = "resource2";

            oadrEvent.oadrResponseRequired = ResponseRequiredType.always;

            string xml = SerializeOadrObject.serializeOjbect(payload, payload.GetType());
            Console.Out.WriteLine(xml);

            /*serializer = new XmlSerializer(typeof(eiEventSignalType));

            MemoryStream ms = new MemoryStream(Encoding.UTF8.GetBytes(xml));

            signal = (eiEventSignalType)serializer.Deserialize(ms);

            Assert.IsNotNull(signal);

            ms.Close();*/
        }

        [TestMethod]
        public void generateSignalWEnergy()
        {
            eiEventSignalType signal = new eiEventSignalType();

            EnergyApparentType energy = new EnergyApparentType();

            energy.itemDescription = "Apparent Energy";
            energy.itemUnits = "KWh";
            energy.siScaleCode = SiScaleCodeType.none;

            signal.itemBase = energy;

            string xml = SerializeOadrObject.serializeOjbect(signal, signal.GetType());

            Console.Out.WriteLine(xml);
        }
    }
}
