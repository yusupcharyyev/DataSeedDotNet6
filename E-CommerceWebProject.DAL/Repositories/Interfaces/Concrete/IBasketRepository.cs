using E_CommerceWebProject.DAL.Repositories.Interfaces.Abstract;
using E_CommerceWebProject.Models.Entities.Concrete;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace E_CommerceWebProject.DAL.Repositories.Interfaces.Concrete
{
    public interface IBasketRepository
    {
        void Create(Basket entity);
        void Delete(Basket entity);
        List<Basket> GetDefaults(System.Linq.Expressions.Expression<Func<Basket, bool>> expression);
    }
}
