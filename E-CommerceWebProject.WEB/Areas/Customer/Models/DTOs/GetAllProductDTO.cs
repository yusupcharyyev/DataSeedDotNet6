using E_CommerceWebProject.Models.Entities.Concrete;

namespace E_CommerceWebProject.WEB.Areas.Customer.Models.DTOs
{
    public class GetAllProductDTO
    {
        public Guid ProductID { get; set; }
        public string Name { get; set; }
        public string Code { get; set; }

        public double Price { get; set; }
        public double DiscountPrice { get; set; }
        public double DiscountPercent { get; set; }

        public Guid UserID { get; set; }

        public string UserRole { get; set; }

        public List<ProductColor> ProductColors { get; set; }
    }
}
