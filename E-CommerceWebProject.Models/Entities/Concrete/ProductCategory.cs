using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class ProductCategory
    {
        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        public Guid CategoryID { get; set; }
        public virtual Category Category { get; set; }
    }
}
