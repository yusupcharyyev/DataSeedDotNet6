using E_CommerceWebProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class Order : BaseEntity
    {
        public Order()
        {
            OrderDetails = new List<OrderDetails>();
        }
        public Guid CustomerID { get; set; }
        public virtual User User { get; set; }
        public double TotalPrice { get; set; }
        public virtual List<OrderDetails> OrderDetails { get; set; }
    }
}
