﻿using SqlSugar;
using System;

namespace HW.Model.Models
{
    /// <summary>
    /// 客户表
    /// </summary>
    public class Cust : RootEntityTkey<long>
    {
        public Cust()
        {
            OrderSort = 1;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;
            IsDeleted = false;
        }
        public Cust(string name)
        {
            Name = name;
            Description = "";
            OrderSort = 1;
            Enabled = true;
            CreateTime = DateTime.Now;
            ModifyTime = DateTime.Now;

        }

        /// <summary>
        ///获取或设置是否禁用，逻辑上的删除，非物理删除
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public bool? IsDeleted { get; set; }
        /// <summary>
        /// 名称
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string Name { get; set; }
        /// <summary>
        ///描述
        /// </summary>
        [SugarColumn(Length = 100, IsNullable = true)]
        public string Description { get; set; }
        /// <summary>
        ///排序
        /// </summary>
        public int OrderSort { get; set; }
        
        /// <summary>
        /// 是否激活
        /// </summary>
        public bool Enabled { get; set; }
        /// <summary>
        /// 创建ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? CreateId { get; set; }
        /// <summary>
        /// 创建者
        /// </summary>
        [SugarColumn(Length = 50, IsNullable = true)]
        public string CreateBy { get; set; }
        /// <summary>
        /// 创建时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? CreateTime { get; set; } = DateTime.Now;
        /// <summary>
        /// 修改ID
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public long? ModifyId { get; set; }
        /// <summary>
        /// 修改者
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public string ModifyBy { get; set; }
        /// <summary>
        /// 修改时间
        /// </summary>
        [SugarColumn(IsNullable = true)]
        public DateTime? ModifyTime { get; set; } = DateTime.Now;


    }
}
