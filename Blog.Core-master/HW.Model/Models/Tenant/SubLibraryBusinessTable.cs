﻿using HW.Model.Models.RootTkey;
using HW.Model.Tenants;

namespace HW.Model.Models;

/// <summary>
/// 多租户-多库方案 业务表 <br/>
/// 公共库无需标记[MultiTenant]特性
/// </summary>
[MultiTenant]
public class SubLibraryBusinessTable : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    public decimal Amount { get; set; }
}