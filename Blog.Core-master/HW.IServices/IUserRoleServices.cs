using HW.IServices.BASE;
using HW.Model.Models;
using System.Threading.Tasks;

namespace HW.IServices
{	
	/// <summary>
	/// UserRoleServices
	/// </summary>	
    public interface IUserRoleServices :IBaseServices<UserRole>
	{

        Task<UserRole> SaveUserRole(long uid, long rid);
        Task<int> GetRoleIdByUid(long uid);
    }
}

