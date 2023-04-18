using Oadr.Library.Profile2B.Models;
using System.Collections.Generic;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Events
{
    public partial class CreateOptForm : System.Windows.Forms.Form
    {
        public CreateOptForm()
        {
            InitializeComponent();

            cmbOptType.SelectedIndex = 0;
        }

        public OptReasonEnumeratedType OptReason
        {
            get
            {
                var optReason = cmbOptReason.SelectedItem.ToString();
                if (optReason == OptReasonEnumeratedType.economic.ToString())
                {
                    return OptReasonEnumeratedType.economic;
                }

                if (optReason == OptReasonEnumeratedType.emergency.ToString())
                {
                    return OptReasonEnumeratedType.emergency;
                }

                if (optReason == OptReasonEnumeratedType.mustRun.ToString())
                {
                    return OptReasonEnumeratedType.mustRun;
                }

                if (optReason == OptReasonEnumeratedType.notParticipating.ToString())
                {
                    return OptReasonEnumeratedType.notParticipating;
                }

                if (optReason == OptReasonEnumeratedType.outageRunStatus.ToString())
                {
                    return OptReasonEnumeratedType.outageRunStatus;
                }

                if (optReason == OptReasonEnumeratedType.overrideStatus.ToString())
                {
                    return OptReasonEnumeratedType.overrideStatus;
                }

                if (optReason == OptReasonEnumeratedType.participating.ToString())
                {
                    return OptReasonEnumeratedType.participating;
                }

                if (optReason == OptReasonEnumeratedType.xschedule.ToString())
                {
                    return OptReasonEnumeratedType.xschedule;
                }

                return OptReasonEnumeratedType.economic;
            }
        }
        
        public OptTypeType OptType
        {
            get
            {
                var optType = cmbOptType.SelectedItem.ToString();
                if (optType == OptTypeType.optIn.ToString())
                {
                    return OptTypeType.optIn;
                }

                if (optType == OptTypeType.optOut.ToString())
                {
                    return OptTypeType.optOut;
                }
                return OptTypeType.optIn;
            }
        }
        
        public string ResourceId
        {
            get
            {
                if (cmbResource.SelectedIndex == 0)
                {
                    return null;
                }
                return cmbResource.SelectedItem.ToString();
            }
        }

        public void SetLists(List<string> marketContexts, List<string> resources)
        {
            cmbResource.Items.Clear();
            cmbResource.Items.Add(string.Empty);
            cmbResource.SelectedIndex = 0;
            foreach (var resource in resources)
            {
                cmbResource.Items.Add(resource);
            }
        }
    }
}
