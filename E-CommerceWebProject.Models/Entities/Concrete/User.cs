using E_CommerceWebProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class User : BaseEntity
    {
        public User()
        {
            Comments = new List<Comment>();
            Orders = new List<Order>();
            Products = new List<Product>();
        }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string IdentityId { get; set; }
        public string? BoutiqueName { get; set; }
        public string Adres { get; set; }

        public virtual List<Product> Products { get; set; }
        public virtual List<Comment> Comments { get; set; }
        public virtual List<Order> Orders { get; set; }
    }
}
