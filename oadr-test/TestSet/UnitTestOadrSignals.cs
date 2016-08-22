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
using System.Text;
using System.Xml.Serialization;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using oadr2b_ven.ven.signal;
using oadrlib.lib.helper;
using oadrlib.lib.oadr2b;

namespace oadr_test.TestSet
{
    [TestClass]
    public class UnitTestOadrSignals
    {
        OadrSignals m_oadrSignals = OadrSignals.Instance;

        /******************************************************************************/

        private currencyType generateCurrency(currencyItemDescriptionType description)
        {
            currencyType currency = new currencyType();

            currency.itemDescription = description;
            currency.itemUnits = ISO3AlphaCurrencyCodeContentType.USD;
            currency.siScaleCode = SiScaleCodeType.none;
            
            return currency;
        }

        /******************************************************************************/

        private currencyPerKWhType generateCurrencyPerKWh(currencyItemDescriptionType description)
        {
            currencyPerKWhType currency = new currencyPerKWhType();

            currency.itemDescription = description;
            currency.itemUnits = ISO3AlphaCurrencyCodeContentType.USD;
            currency.siScaleCode = SiScaleCodeType.none;

            return currency;
        }

        /******************************************************************************/

        private PowerItemType generatePower(ePowerItemType powerType, decimal hertz, decimal voltage)
        {
            PowerItemType power = null;

            switch (powerType)
            {
                case ePowerItemType.PowerApparent:
                    power = new PowerApparentType();
                    break;

                case ePowerItemType.PowerReactive:
                    power = new PowerReactiveType();
                    break;

                case ePowerItemType.PowerReal:
                    power = new PowerRealType();
                    break;
            }

            power.itemDescription = "";
            power.itemUnits = "W";
            power.siScaleCode = SiScaleCodeType.none;

            power.powerAttributes = new PowerAttributesType();
            power.powerAttributes.hertz = hertz;
            power.powerAttributes.voltage = voltage;

            return power;
        }

        /******************************************************************************/

        private EnergyItemType generateEnergy(eEnergyItemType energyType)
        {
            EnergyItemType energy = null;

            switch (energyType)
            {
                case eEnergyItemType.EnergyApparent:
                    energy = new EnergyApparentType();
                    break;

                case eEnergyItemType.EnergyReactive:
                    energy = new EnergyReactiveType();
                    break;

                case eEnergyItemType.EnergyReal:
                    energy = new EnergyRealType();
                    break;
            }

            return energy;
        }

        /******************************************************************************/

        private void validateSignal(eiEventSignalType signal, bool shouldBeValid, string exceptionMessage = null)
        {
            try
            {
                m_oadrSignals.validateSignal(signal);

                if (!shouldBeValid)
                    Assert.Fail("Exception expected");
            }
            catch (ExceptionInvalidSignal ex)
            {
                if (shouldBeValid)
                    Assert.Fail("Unexpected exception: " + ex.Message);

                Assert.AreEqual(exceptionMessage, ex.Message);
            }
        }

        /******************************************************************************/

        private void validateSignal(SignalNameEnumeratedType signalName, SignalTypeEnumeratedType signalType, ItemBaseType units, bool shouldBeValid, string exceptionMessage = null)
        {
            eiEventSignalType signal = new eiEventSignalType();

            signal.signalName = signalName.ToString();
            signal.signalType = signalType;

            signal.itemBase = units;

            validateSignal(signal, shouldBeValid, exceptionMessage);
        }

        /******************************************************************************/

        [TestMethod]
        public void testSimple()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.SIMPLE, SignalTypeEnumeratedType.level, null, true);
            validateSignal(SignalNameEnumeratedType.simple, SignalTypeEnumeratedType.level, null, true);


            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.SIMPLE, SignalTypeEnumeratedType.delta, null, false, ExceptionInvalidSignal.INVALID_TYPE);                      
        }

        /******************************************************************************/

        [TestMethod]
        public void testPriceOfElectricty()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKWh), true);
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.priceRelative, generateCurrency(currencyItemDescriptionType.currencyPerKWh), true);
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.priceMultiplier, null, true);

            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.price, generateCurrencyPerKWh(currencyItemDescriptionType.currencyPerKWh), true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.priceRelative, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.priceMultiplier, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);

            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.level, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_TYPE);
            validateSignal(SignalNameEnumeratedType.ELECTRICITY_PRICE, SignalTypeEnumeratedType.price, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_UNITS);
        }

        /******************************************************************************/

        [TestMethod]
        public void testEnergyPrice()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKWh), true);
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.priceRelative, generateCurrency(currencyItemDescriptionType.currencyPerKWh), true);
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.priceMultiplier, null, true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.priceRelative, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.priceMultiplier, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);

            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.level, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_TYPE);
            validateSignal(SignalNameEnumeratedType.ENERGY_PRICE, SignalTypeEnumeratedType.price, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_UNITS);
        }

        /******************************************************************************/

        [TestMethod]
        public void testDemandCharge()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKW), true);
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.priceRelative, generateCurrency(currencyItemDescriptionType.currencyPerKW), true);
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.priceMultiplier, null, true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKWh), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.priceRelative, generateCurrency(currencyItemDescriptionType.currencyPerKWh), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.priceMultiplier, generateCurrency(currencyItemDescriptionType.currencyPerKWh), false, ExceptionInvalidSignal.INVALID_UNITS);

            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.level, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_TYPE);
            validateSignal(SignalNameEnumeratedType.DEMAND_CHARGE, SignalTypeEnumeratedType.price, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_UNITS);
        }

        /******************************************************************************/

        [TestMethod]
        public void testBidPrice()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.BID_PRICE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currency), true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.BID_PRICE, SignalTypeEnumeratedType.priceMultiplier, generateCurrency(currencyItemDescriptionType.currency), false, ExceptionInvalidSignal.INVALID_TYPE);
            validateSignal(SignalNameEnumeratedType.BID_PRICE, SignalTypeEnumeratedType.price, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.BID_PRICE, SignalTypeEnumeratedType.price, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_UNITS);
        }

        /******************************************************************************/

        [TestMethod]
        public void testBidLoad()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.BID_LOAD, SignalTypeEnumeratedType.setpoint, generatePower(ePowerItemType.PowerReal, 60, 120), true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.BID_LOAD, SignalTypeEnumeratedType.priceMultiplier, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_TYPE);
            validateSignal(SignalNameEnumeratedType.BID_LOAD, SignalTypeEnumeratedType.setpoint, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
        }

        /******************************************************************************/

        [TestMethod]
        public void testBidEnergy()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.BID_ENERGY, SignalTypeEnumeratedType.setpoint, generateEnergy(eEnergyItemType.EnergyReal), true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.BID_ENERGY, SignalTypeEnumeratedType.priceMultiplier, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_TYPE);
            validateSignal(SignalNameEnumeratedType.BID_ENERGY, SignalTypeEnumeratedType.setpoint, generateCurrency(currencyItemDescriptionType.currencyPerKW), false, ExceptionInvalidSignal.INVALID_UNITS);
        }

        /******************************************************************************/

        [TestMethod]
        public void testChargeState()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.setpoint, generateEnergy(eEnergyItemType.EnergyReal), true);
            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.delta, generateEnergy(eEnergyItemType.EnergyReal), true);
            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.multiplier, null, true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.setpoint, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.delta, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.multiplier, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_UNITS);

            validateSignal(SignalNameEnumeratedType.CHARGE_STATE, SignalTypeEnumeratedType.priceRelative, generatePower(ePowerItemType.PowerReal, 60, 120), false, ExceptionInvalidSignal.INVALID_TYPE);
        }

        /******************************************************************************/

        [TestMethod]
        public void testLoadDispatch()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.setpoint, generatePower(ePowerItemType.PowerReal, 60, 120), true);
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.delta, generatePower(ePowerItemType.PowerReal, 60, 120), true);
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.multiplier, null, true);
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.level, generatePower(ePowerItemType.PowerReal, 60, 120), true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.setpoint, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.delta, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.multiplier, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.level, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_UNITS);

            validateSignal(SignalNameEnumeratedType.LOAD_DISPATCH, SignalTypeEnumeratedType.price, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_TYPE);
        }

        /******************************************************************************/

        [TestMethod]
        public void testLoadControl()
        {
            // 
            // positive test cases
            //
            validateSignal(SignalNameEnumeratedType.LOAD_CONTROL, SignalTypeEnumeratedType.xloadControlCapacity, null, true);
            validateSignal(SignalNameEnumeratedType.LOAD_CONTROL, SignalTypeEnumeratedType.xloadControlLevelOffset, null, true);
            validateSignal(SignalNameEnumeratedType.LOAD_CONTROL, SignalTypeEnumeratedType.xloadControlSetpoint, null, true);
            validateSignal(SignalNameEnumeratedType.LOAD_CONTROL, SignalTypeEnumeratedType.xloadControlPercentOffset, null, true);

            // 
            // negative test cases
            //
            validateSignal(SignalNameEnumeratedType.LOAD_CONTROL, SignalTypeEnumeratedType.xloadControlCapacity, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_UNITS);
            validateSignal(SignalNameEnumeratedType.LOAD_CONTROL, SignalTypeEnumeratedType.price, generateEnergy(eEnergyItemType.EnergyReal), false, ExceptionInvalidSignal.INVALID_TYPE);
        }


        /******************************************************************************/

        [TestMethod]
        public void testCustom()
        {
            eiEventSignalType signal = new eiEventSignalType();

            // 
            // positive test cases
            //
            // the test harness requires rejecting unknown custom signals so we can't
            // automatically accept an unknown custom signal
            // validates all x- (custom) names
            // signal.signalName = "x-something cool";
            // validateSignal(signal, true);

            // 
            // negative test cases
            //
            signal.signalName = "invalid";
            validateSignal(signal, false, ExceptionInvalidSignal.UNKNOWN_SIGNAL_NAME + ": " + signal.signalName);
        }
    }
}
