using E_CommerceWebProject.DAL.Context;
using E_CommerceWebProject.DAL.Repositories.Interfaces.Abstract;
using E_CommerceWebProject.Models.Entities.Abstract;
using E_CommerceWebProject.Models.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Repositories.Abstract
{
    public abstract class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        private readonly ProjectContext _context;
        protected readonly DbSet<T> _table;

        public BaseRepository(ProjectContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public bool Any(Expression<Func<T, bool>> expression)
        {
            return _table.Any(expression);
        }

        public void Create(T entity)
        {
            _table.Add(entity);
            _context.SaveChanges();
        }

        public void Delete(T entity)
        {
            entity.Statu = Statu.Passive;
            entity.RemovedDate = DateTime.Now;
            _context.SaveChanges();
        }

        public void Update(T entity)
        {
            entity.Statu = Statu.Modified;
            entity.ModifiedDate = DateTime.Now;
            _table.Update(entity);
            _context.SaveChanges();
        }
        public TResult GetByDefault<TResult>(Expression<Func<T, TResult>> selector, Expression<Func<T, bool>> expression, Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null)
        {
            IQueryable<T> query = _table; 
            if (include != null) 
            {
                query = include(query);
            }
            if (expression != null)   
            {
                query = query.Where(expression);    
            }
            return query.Select(selector).First(); 
        }

        public List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                                    Expression<Func<T, bool>> expression,
                                                               Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null, Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null)
        {
            IQueryable<T> query = _table;
            if (include != null)
            {
                query = include(query);
            }
            if (expression != null)
            {
                query = query.Where(expression);
            }
            if (orderby != null)
            {
                return orderby(query).Select(selector).ToList();
            }
            return query.Select(selector).ToList();
        }

        public T GetDefault(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).FirstOrDefault();
        }

        public List<T> GetDefaults(Expression<Func<T, bool>> expression)
        {
            return _table.Where(expression).ToList();
        }
    }
}
