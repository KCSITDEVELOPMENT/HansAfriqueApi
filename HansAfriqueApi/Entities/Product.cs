﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Product : BaseEntity
    {
        public Brand Brand { get; set; }
        public int Brandid { get; set; }
        public Part Part { get; set; }

    }
}
