﻿using System;
using System.Threading.Tasks;
using HW.Common;
using HW.Common.DB;
using HW.Common.Utility;
using HW.IRepository.Base;
using HW.IServices;
using HW.Model.Models;
using HW.Repository.UnitOfWorks;
using HW.Services.BASE;
using SqlSugar;

namespace HW.Services
{
    public partial class PasswordLibServices : BaseServices<PasswordLib>, IPasswordLibServices
    {
        IBaseRepository<PasswordLib> _dal;
        private readonly IUnitOfWorkManage _unitOfWorkManage;
        private readonly ISqlSugarClient _db;
        private SqlSugarScope db => _db as SqlSugarScope;

        public PasswordLibServices(IBaseRepository<PasswordLib> dal, IUnitOfWorkManage unitOfWorkManage, ISqlSugarClient db)
        {
            this._dal = dal;
            _unitOfWorkManage = unitOfWorkManage;
            _db = db;
            base.BaseDal = dal;
        }

        [UseTran(Propagation = Propagation.Required)]
        public async Task<bool> TestTranPropagation2()
        {
            await _dal.Add(new PasswordLib()
            {
                PLID = IdGeneratorUtility.NextId(),
                IsDeleted = false,
                plAccountName = "aaa",
                plCreateTime = DateTime.Now
            });

            return true;
        }

        [UseTran(Propagation = Propagation.Mandatory)]
        public async Task<bool> TestTranPropagationNoTranError()
        {
            await _dal.Add(new PasswordLib()
            {
                IsDeleted = false,
                plAccountName = "aaa",
                plCreateTime = DateTime.Now
            });

            return true;
        }

        [UseTran(Propagation = Propagation.Nested)]
        public async Task<bool> TestTranPropagationTran2()
        {
            await db.Insertable(new PasswordLib()
            {
                PLID = IdGeneratorUtility.NextId(),
                IsDeleted = false,
                plAccountName = "aaa",
                plCreateTime = DateTime.Now
            }).ExecuteReturnSnowflakeIdAsync();

            //throw new Exception("测试嵌套事务异常回滚");
            return true;
        }

        public async Task<bool> TestTranPropagationTran3()
        {
            Console.WriteLine("Begin Transaction Before:" + db.ContextID);
            db.BeginTran();
            Console.WriteLine("Begin Transaction After:" + db.ContextID);
            Console.WriteLine("");
            await db.Insertable(new PasswordLib()
            {
                PLID = IdGeneratorUtility.NextId(),
                IsDeleted = false,
                plAccountName = "aaa",
                plCreateTime = DateTime.Now
            }).ExecuteReturnSnowflakeIdAsync();

            //throw new Exception("测试嵌套事务异常回滚");
            return true;
        }
    }
}