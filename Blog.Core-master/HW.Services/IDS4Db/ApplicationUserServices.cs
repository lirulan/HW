using System.Threading.Tasks;
using HW.Common.DB;
using HW.Common.DB.Extension;
using HW.IRepository.Base;
using HW.Model.IDS4DbModels;
using HW.Services.BASE;

namespace HW.IServices
{
    public class ApplicationUserServices : BaseServices<ApplicationUser>, IApplicationUserServices
    {
        public bool IsEnable()
        {
            var configId = typeof(ApplicationUser).GetEntityTenant();
            return Db.AsTenant().IsAnyConnection(configId);
        }
    }
}