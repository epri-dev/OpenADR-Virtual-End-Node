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
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using oadrlib.lib.oadr2b;

namespace oadr2b_ven.UserControls.Events
{
    public partial class frmCreateOpt : Form
    {
        public frmCreateOpt()
        {
            InitializeComponent();

            cmbOptType.SelectedIndex = 0;
        }

        /**********************************************************/

        public void setLists(List<string> marketContexts, List<string> resources)
        {
            cmbResource.Items.Clear();

            cmbResource.Items.Add("");
            cmbResource.SelectedIndex = 0;

            foreach (string resource in resources)
                cmbResource.Items.Add(resource);
        }

        /********************************************************************************/

        public OptReasonEnumeratedType OptReason
        {
            get
            {
                string optReason = cmbOptReason.SelectedItem.ToString();

                if (optReason == OptReasonEnumeratedType.economic.ToString())
                    return OptReasonEnumeratedType.economic;
                else if (optReason == OptReasonEnumeratedType.emergency.ToString())
                    return OptReasonEnumeratedType.emergency;
                else if (optReason == OptReasonEnumeratedType.mustRun.ToString())
                    return OptReasonEnumeratedType.mustRun;
                else if (optReason == OptReasonEnumeratedType.notParticipating.ToString())
                    return OptReasonEnumeratedType.notParticipating;
                else if (optReason == OptReasonEnumeratedType.outageRunStatus.ToString())
                    return OptReasonEnumeratedType.outageRunStatus;
                else if (optReason == OptReasonEnumeratedType.overrideStatus.ToString())
                    return OptReasonEnumeratedType.overrideStatus;
                else if (optReason == OptReasonEnumeratedType.participating.ToString())
                    return OptReasonEnumeratedType.participating;
                else if (optReason == OptReasonEnumeratedType.xschedule.ToString())
                    return OptReasonEnumeratedType.xschedule;

                return OptReasonEnumeratedType.economic;
            }
        }

        /********************************************************************************/

        public OptTypeType OptType
        {
            get
            {
                string optType = cmbOptType.SelectedItem.ToString();

                if (optType == OptTypeType.optIn.ToString())
                    return OptTypeType.optIn;
                else if (optType == OptTypeType.optOut.ToString())
                    return OptTypeType.optOut;

                return OptTypeType.optIn;
            }
        }

        /********************************************************************************/

        public string ResourceID
        {
            get
            {
                if (cmbResource.SelectedIndex == 0)
                    return null;

                return cmbResource.SelectedItem.ToString();
            }
        }
    }
}
