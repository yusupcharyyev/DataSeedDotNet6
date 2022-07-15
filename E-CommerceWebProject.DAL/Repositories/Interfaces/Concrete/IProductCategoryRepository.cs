using E_CommerceWebProject.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete
{
    public interface IProductCategoryRepository
    {
        void Create(ProductCategory entity);
        void Delete(ProductCategory entity);
        List<ProductCategory> GetDefaults(System.Linq.Expressions.Expression<Func<ProductCategory, bool>> expression);
    }
}
