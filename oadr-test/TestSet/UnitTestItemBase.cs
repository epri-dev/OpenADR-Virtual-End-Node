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
using oadrlib.lib.helper;
using oadrlib.lib.oadr2b;

using oadr_test.helper;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestItemBase
    {
        /******************************************************************************/

        public void testItemBase(ItemBaseType itemBase)
        {
            eiEventSignalType signal = new eiEventSignalType();

            signal.itemBase = itemBase;

            string xml = SerializeOadrObject.serializeOjbect(signal, signal.GetType());

            // by default, the itemBase substitution parameters are generated with a root element of 'itemBase'
            // hand made modifications to oadr20b.cs fix this problem
            Assert.IsFalse(xml.Contains("itemBase"));

            Console.Out.WriteLine(xml);

            signal = (eiEventSignalType)SerializeOadrObject.deserializeObject(xml, typeof(eiEventSignalType));

            Assert.IsNotNull(signal, xml);
            Assert.IsNotNull(signal.itemBase, xml);
        }

        /******************************************************************************/

        [TestMethod]
        public void currency()
        {
            currencyType c = new currencyType();

            c.itemDescription = currencyItemDescriptionType.currency;
            c.itemUnits = ISO3AlphaCurrencyCodeContentType.USD;
            c.siScaleCode = SiScaleCodeType.none;

            testItemBase(c);
        }

        /******************************************************************************/

        [TestMethod]
        public void currencyPerKWh()
        {
            currencyPerKWhType c = new currencyPerKWhType();

            c.itemDescription = currencyItemDescriptionType.currencyPerKWh;
            c.itemUnits = ISO3AlphaCurrencyCodeContentType.USD;
            c.siScaleCode = SiScaleCodeType.none;

            testItemBase(c);
        }

        /******************************************************************************/

        [TestMethod]
        public void currencyPerKW()
        {
            currencyPerKWType c = new currencyPerKWType();

            c.itemDescription = currencyItemDescriptionType.currencyPerKW;
            c.itemUnits = ISO3AlphaCurrencyCodeContentType.USD;
            c.siScaleCode = SiScaleCodeType.none;

            testItemBase(c);
        }

        /******************************************************************************/

        public void testPowerItemType(PowerItemType power)
        {
            power.itemDescription = "Real";
            power.itemUnits = "KW";
            power.siScaleCode = SiScaleCodeType.none;

            power.powerAttributes = new PowerAttributesType();
            power.powerAttributes.ac = true;
            power.powerAttributes.hertz = 60;
            power.powerAttributes.voltage = 120;

            testItemBase(power);
        }

        /******************************************************************************/

        [TestMethod]
        public void powerReal()
        {
            PowerRealType power = new PowerRealType();

            testPowerItemType(power);
        }

        /******************************************************************************/

        [TestMethod]
        public void powerReactive()
        {
            PowerReactiveType power = new PowerReactiveType();

            testPowerItemType(power);
        }

        /******************************************************************************/

        [TestMethod]
        public void powerApparent()
        {
            PowerApparentType power = new PowerApparentType();

            testPowerItemType(power);
        }

        /******************************************************************************/

        public void testEnergyItemType(EnergyItemType energyType)
        {
            energyType.itemDescription = "energy";
            energyType.itemUnits = "KW";
            energyType.siScaleCode = SiScaleCodeType.none;

            testItemBase(energyType);
        }

        /******************************************************************************/

        [TestMethod]
        public void energyReal()
        {
            EnergyRealType energy = new EnergyRealType();

            testEnergyItemType(energy);
        }

        /******************************************************************************/

        [TestMethod]
        public void energyApparent()
        {
            EnergyApparentType energy = new EnergyApparentType();

            testEnergyItemType(energy);
        }

        /******************************************************************************/

        [TestMethod]
        public void energyReactive()
        {
            EnergyReactiveType energy = new EnergyReactiveType();

            testEnergyItemType(energy);
        }
    }
}
