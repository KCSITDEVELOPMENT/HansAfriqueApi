using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Part: BaseEntity
    {
        public string Part_Category { get; set; }
        public string Part_Description { get; set; }
    }
}
