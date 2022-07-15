using E_CommerceWebProject.DAL.Context;
using E_CommerceWebProject.DAL.Repositories.Abstract;
using E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete;
using E_CommerceWebProject.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Repositories.Concrete
{
    public class ProductImageRepository : BaseRepository<ProductImage>, IProductImageRepository
    {
        public ProductImageRepository(ProjectContext context) : base(context)
        {
        }
    }
}
