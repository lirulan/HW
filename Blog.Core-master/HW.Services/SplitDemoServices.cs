using HW.IRepository.Base;
using HW.IServices;
using HW.Model.Models;
using HW.Services.BASE;
using System.Linq;
using System.Threading.Tasks;

namespace HW.FrameWork.Services
{
    /// <summary>
    /// sysUserInfoServices
    /// </summary>	
    public class SplitDemoServices : BaseServices<SplitDemo>, ISplitDemoServices
    {
        private readonly IBaseRepository<SplitDemo> _splitDemoRepository;
        public SplitDemoServices(IBaseRepository<SplitDemo> splitDemoRepository)
        {
            _splitDemoRepository = splitDemoRepository;
        }


    }
}
