using System.Threading.Tasks;
using HW.IServices.BASE;
using HW.Model.Models;

namespace HW.IServices
{
    public partial interface IPasswordLibServices :IBaseServices<PasswordLib>
    {
        Task<bool> TestTranPropagation2();
        Task<bool> TestTranPropagationNoTranError();
        Task<bool> TestTranPropagationTran2();
        Task<bool> TestTranPropagationTran3();
    }
}
