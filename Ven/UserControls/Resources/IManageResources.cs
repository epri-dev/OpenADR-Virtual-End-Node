using Oadr.Ven.Resources;

namespace Oadr.Ven.UserControls.Resources
{
    public interface IManageResources
    {
        void ProcessRegisterReports();

        void AddResource(Resource resource);
        
        void RemoveResource(Resource resource);
    }
}
