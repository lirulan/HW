﻿using System.Collections.Generic;
using HW.Model.Models.RootTkey;
using HW.Model.Tenants;
using SqlSugar;

namespace HW.Model.Models;

/// <summary>
/// 多租户-多表方案 业务表 <br/>
/// </summary>
[MultiTenant(TenantTypeEnum.Tables)]
public class MultiBusinessTable : BaseEntity
{
    /// <summary>
    /// 名称
    /// </summary>
    public string Name { get; set; }

    /// <summary>
    /// 金额
    /// </summary>
    public decimal Amount { get; set; }

    [Navigate(NavigateType.OneToMany, nameof(MultiBusinessSubTable.MainId))]
    public List<MultiBusinessSubTable> Child { get; set; }
}