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
using System.Threading.Tasks;
using oadrlib.lib.oadr2b;

namespace oadr2b_ven.ven.signal
{
    public class ValidateUnits
    {
        /// <summary>
        /// validates currency type units.  assumes three valid signals: price and priceRelative with units of curencyType, and
        /// priceMultiplier with no units
        /// </summary>
        /// <param name="signalType"></param>
        /// <param name="units"></param>
        /// <param name="currencyDescriptonType"></param>
        public static void validateUnits(SignalTypeEnumeratedType signalType, ItemBaseType units, currencyItemDescriptionType currencyDescriptonType)
        {
            if (signalType == SignalTypeEnumeratedType.price || signalType == SignalTypeEnumeratedType.priceRelative)
            {
                // the class could be currencyType, or a sub class currencyPerKWh, currencyPerKW type
                if (units.GetType().BaseType != typeof(currencyType) && units.GetType() != typeof(currencyType))
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);

                currencyType c = (currencyType)units;

                if (c.itemDescription != currencyDescriptonType)
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);

                return;
            }

            if (signalType == SignalTypeEnumeratedType.priceMultiplier)
            {
                if (units != null)
                    throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_UNITS);

                return;
            }

            throw new ExceptionInvalidSignal(ExceptionInvalidSignal.INVALID_TYPE);
        }
    }
}
