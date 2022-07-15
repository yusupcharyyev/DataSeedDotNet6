using E_CommerceWebProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class ProductColor : BaseEntity
    {
        public ProductColor()
        {
            ProductStockSizes = new List<ProductStockSize>();
            ProductImages = new List<ProductImage>();
        }
        public string Color { get; set; }

        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }

        public virtual List<ProductStockSize> ProductStockSizes { get; set; }
        public virtual List<ProductImage> ProductImages { get; set; }

    }
}
