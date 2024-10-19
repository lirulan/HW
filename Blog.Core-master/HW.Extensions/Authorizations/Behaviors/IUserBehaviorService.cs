using System.Threading.Tasks;

namespace HW.Extensions.Authorizations.Behaviors
{
    public interface IUserBehaviorService
    {

        Task<bool> CreateOrUpdateUserAccessByUid();

        Task<bool> RemoveAllUserAccessByUid();

        Task<bool> CheckUserIsNormal();

        Task<bool> CheckTokenIsNormal();
    }
}
