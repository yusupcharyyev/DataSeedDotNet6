using E_CommerceWebProject.DAL.Context;
using E_CommerceWebProject.DAL.Repositories.Abstract;
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
    public class BasketRepository : IBasketRepository
    {
        private readonly ProjectContext _projectContext;
        private readonly DbSet<Basket> _table;

        public BasketRepository(ProjectContext projectContext)
        {
            _projectContext = projectContext;
            _table = projectContext.Set<Basket>();

        }
        public void Create(Basket entity)
        {
            _table.Add(entity);
            _projectContext.SaveChanges();
        }

        public void Delete(Basket entity)
        {
            _table.Remove(entity);
            _projectContext.SaveChanges();
        }

        public List<Basket> GetDefaults(Expression<Func<Basket, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }
    }
}
