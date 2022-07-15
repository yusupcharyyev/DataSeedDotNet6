using E_CommerceWebProject.DAL.Context;
using E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete;
using E_CommerceWebProject.Models.Entities.Concrete;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Repositories.Concrete
{
    public class ProductCategoryRepository : IProductCategoryRepository
    {
        private readonly ProjectContext _projectContext;
        private readonly DbSet<ProductCategory> _table;

        public ProductCategoryRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
            _table = projectContext.Set<ProductCategory>();

        }
        public void Create(ProductCategory entity)
        {
            _table.Add(entity);
            _projectContext.SaveChanges();
        }

        public void Delete(ProductCategory entity)
        {
            _table.Remove(entity);
            _projectContext.SaveChanges();
        }

        public List<ProductCategory> GetDefaults(Expression<Func<ProductCategory, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }
    }
}
