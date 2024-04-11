﻿using LibeyTechnicalTestDomain.UbigeoAggregate.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibeyTechnicalTestDomain.ProvinceAggregate.Domain
{
    public class Province
    {
        public string ProvinceCode { get; private set; }
        public string RegionCode { get; private set; }
        public string ProvinceDescription { get; private set; }
    }
}
