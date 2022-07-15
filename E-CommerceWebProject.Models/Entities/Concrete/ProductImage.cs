using E_CommerceWebProject.Models.Entities.Abstract;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class ProductImage : BaseEntity
    {
        public string Image { get; set; }
        
        [NotMapped]
        public IFormFile ImagePath { get; set; }

        public Guid ProductColorID { get; set; }
        public virtual ProductColor ProductColor { get; set; }
    }
}
