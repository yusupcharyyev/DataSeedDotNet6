using E_CommerceWebProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class ProductStockSize : BaseEntity
    {
        public int Stock { get; set; }
        public string BodySize { get; set; }

        public Guid ProductColorID { get; set; }
        public virtual ProductColor ProductColor { get; set; }
    }
}
