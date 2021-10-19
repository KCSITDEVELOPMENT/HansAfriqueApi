using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HansAfriqueApi.Entities
{
    public class Picture : BaseEntity
    {
        public string Url { get; set; }
        public string IsMain { get; set; }
        public int Productid { get; set; }
        public Product Product { get; set; }
    }
}
