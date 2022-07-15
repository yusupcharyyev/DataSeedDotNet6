using E_CommerceWebProject.Models.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.Models.Entities.Concrete
{
    public class Comment : BaseEntity
    {
        public string Text { get; set; }

        public Guid UserID { get; set; }
        public virtual User User { get; set; }

        public Guid ProductID { get; set; }
        public virtual Product Product { get; set; }
    }
}
