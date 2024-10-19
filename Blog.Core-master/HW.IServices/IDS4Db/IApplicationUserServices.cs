using System.Threading.Tasks;
using HW.IServices.BASE;
using HW.Model.IDS4DbModels;

namespace HW.IServices
{
    public partial interface IApplicationUserServices : IBaseServices<ApplicationUser>
    {
        bool IsEnable();
    }
}