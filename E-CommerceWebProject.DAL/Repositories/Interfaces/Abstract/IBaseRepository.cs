﻿using E_CommerceWebProject.Models.Entities.Abstract;
using Microsoft.EntityFrameworkCore.Query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Repositories.Interfaces.Abstract
{
    public interface IBaseRepository<T> where T : BaseEntity
    {
        void Create(T entity);
        void Update(T entity);
        void Delete(T entity);
        bool Any(Expression<Func<T, bool>> expression);
        T GetDefault(Expression<Func<T, bool>> expression);
        List<T> GetDefaults(Expression<Func<T, bool>> expression);


        TResult GetByDefault<TResult>(Expression<Func<T, TResult>> selector,
                                      Expression<Func<T, bool>> expression,
                                      Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null);
        List<TResult> GetByDefaults<TResult>(Expression<Func<T, TResult>> selector,
                                      Expression<Func<T, bool>> expression,                                    Func<IQueryable<T>, IIncludableQueryable<T, object>> include = null,
                                      Func<IQueryable<T>, IOrderedQueryable<T>> orderby = null);
    }
}
