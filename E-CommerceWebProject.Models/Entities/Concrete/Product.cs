using E_CommerceWebProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class Product : BaseEntity
    {
        public Product()
        {
            ProductCategories = new List<ProductCategory>();
            Comments = new List<Comment>();
            ProductColors = new List<ProductColor>();
        }
        public string Name { get; set; }
        public string Code { get; set; }

        public double Price { get; set; }
        public double? DiscountPrice { get; set; }
        public double? DiscountPercent { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        public virtual List<ProductCategory> ProductCategories { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<ProductColor> ProductColors { get; set; }
    }
}
