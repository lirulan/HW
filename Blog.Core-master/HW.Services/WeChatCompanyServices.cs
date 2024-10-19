using HW.Common;
using HW.Common.Helper;
using HW.IRepository.Base;
using HW.IServices;
using HW.Model;
using HW.Model.Models;
using HW.Model.ViewModels;
using HW.Services.BASE;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using HW.Repository.UnitOfWorks;

namespace HW.Services
{
    /// <summary>
	/// WeChatCompanyServices
	/// </summary>
    public class WeChatCompanyServices : BaseServices<WeChatCompany>, IWeChatCompanyServices
    {
        readonly IUnitOfWorkManage _unitOfWorkManage;
        readonly ILogger<WeChatCompanyServices> _logger;
        public WeChatCompanyServices(IUnitOfWorkManage unitOfWorkManage, ILogger<WeChatCompanyServices> logger)
        {
            this._unitOfWorkManage = unitOfWorkManage;
            this._logger = logger;
        }  
        
    }
}