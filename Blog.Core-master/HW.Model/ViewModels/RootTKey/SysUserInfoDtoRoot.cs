﻿using System;
using System.Collections.Generic;

namespace HW.Model.ViewModels
{
    public class SysUserInfoDtoRoot<Tkey> where Tkey : IEquatable<Tkey>
    {
        public Tkey uID { get; set; }

        public List<Tkey> RIDs { get; set; }

    }
}
