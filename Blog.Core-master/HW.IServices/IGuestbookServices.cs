using HW.IServices.BASE;
using HW.Model;
using HW.Model.Models;
using System.Threading.Tasks;

namespace HW.IServices
{
    public partial interface IGuestbookServices : IBaseServices<Guestbook>
    {
        Task<MessageModel<string>> TestTranInRepository();
        Task<bool> TestTranInRepositoryAOP();

        Task<bool> TestTranPropagation();

        Task<bool> TestTranPropagationNoTran();

        Task<bool> TestTranPropagationTran();
        Task TestTranPropagationTran2();
        Task TestTranPropagationTran3();
    }
}