using System.Threading.Tasks;
using HW.IServices.BASE;
using HW.Model.Models;

namespace HW.IServices;

public interface ITenantService : IBaseServices<SysTenant>
{
    public Task SaveTenant(SysTenant tenant);

    public Task InitTenantDb(SysTenant tenant);
}