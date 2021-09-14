using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Pictures : BaseEntity
    {
        public string Name { get; set; }
        public Part Part { get; set; }
        public int Partid { get; set; }
    }
}
