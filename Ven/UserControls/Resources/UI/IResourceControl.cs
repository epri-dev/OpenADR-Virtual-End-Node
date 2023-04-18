using Oadr.Ven.Resources;
using System.Windows.Forms;

namespace Oadr.Ven.UserControls.Resources.UI
{
    public interface IResourceControl
    {
        Resource GetResource();

        UserControl GetUserControl();

        ResourceControl GetUserControlResource();

        void Edit();

        bool Save();

        void Cancel();

        void Remove();
    }
}
