using HW.Common.HttpContextUser;
using HW.IServices;
using HW.Model;
using HW.Model.Models;
using Microsoft.AspNetCore.Mvc;

namespace HW.Controllers
{
    /// <summary>
    /// 博客管理
    /// </summary>
    [Produces("application/json")]
    [Route("api/Blog")]
    [Route("api/[controller]/[action]")]
    public class CustController : BaseApiController
    {
        public ICustServices _custServices { get; set; }
        readonly ILogger<CustController> _logger;
        readonly IUser _user;

        /// <summary>
        /// 构造函数
        /// </summary>
        /// <param name="logger"></param>
        /// 
        public CustController(ILogger<CustController> logger, IUser user)
        {
            _logger = logger;
            _user = user;
        }

        /// <summary>
        /// 获取全部客户
        /// </summary>
        /// <param name="page"></param>
        /// <param name="key"></param>
        /// <returns></returns>
        // GET: api/User
        [HttpGet]
        public async Task<MessageModel<PageModel<Cust>>> Get(int page = 1, string key = "")
        {
            if (string.IsNullOrEmpty(key) || string.IsNullOrWhiteSpace(key))
            {
                key = "";
            }
            int intPageSize = 50;

            var data = await _custServices.QueryPage(a => a.IsDeleted != true && (a.Name != null && a.Name.Contains(key)), page, intPageSize, " Id desc ");


            return Success(data, "获取成功");

        }

        // GET: api/User/5
        [HttpGet("{id}")]
        public string Get(string id)
        {
            return "value";
        }

        /// <summary>
        /// 添加角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        // POST: api/User
        [HttpPost]
        public async Task<MessageModel<string>> Post([FromBody] Cust role)
        {
            role.CreateId = _user.ID;
            role.CreateBy = _user.Name;
            var id = (await _custServices.Add(role));
            return id > 0 ? Success(id.ObjToString(), "添加成功") : Failed("添加失败");

        }

        /// <summary>
        /// 更新角色
        /// </summary>
        /// <param name="role"></param>
        /// <returns></returns>
        // PUT: api/User/5
        [HttpPut]
        public async Task<MessageModel<string>> Put([FromBody] Cust role)
        {
            if (role == null || role.Id <= 0)
                return Failed("缺少参数");

            return await _custServices.Update(role) ? Success(role?.Id.ObjToString(), "更新成功") : Failed("更新失败");

        }

        /// <summary>
        /// 删除角色
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        // DELETE: api/ApiWithActions/5
        [HttpDelete]
        public async Task<MessageModel<string>> Delete(long id)
        {

            var data = new MessageModel<string>();
            if (id <= 0) return Failed();
            var userDetail = await _custServices.QueryById(id);
            if (userDetail == null) return Success<string>(null, "角色不存在");
            userDetail.IsDeleted = true;
            return await _custServices.Update(userDetail) ? Success(userDetail?.Id.ObjToString(), "删除成功") : Failed();
        }

    }
}