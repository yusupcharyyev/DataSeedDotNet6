using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class OrderDetails
    {
        public double Price { get; set; }
        public Guid Stock { get; set; }
        public double? DiscountPercent { get; set; }
        public double? DiscountPrice { get; set; }
        public Guid OrderID { get; set; }
        public Guid ProductID { get; set; }
        public virtual Product Products { get; set; }
    }
}
