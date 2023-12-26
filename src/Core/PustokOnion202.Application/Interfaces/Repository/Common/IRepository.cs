using PustokOnion202.Domain.Entities.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Application.Interfaces.Repository.Common
{
    public interface IRepository<T> where T : BaseEntity, new()
    {
        IQueryable<T> GetAllWhere(
            Expression<Func<T, bool>>? expression = null, 
            Expression<Func<T, object>>? orderExpression = null,  
            int skip = 0,
            int take = 0,
            params string[] includes);
        IQueryable<T> GetAll(
           params string[] includes);
        Task<T> GetByIdAsync(
           int id,
           params string[] includes);
        Task<T> GetByExpressionAsync(
           Expression<Func<T, bool>>? expression = null,
           params string[] includes);
        Task<bool> IsExistAsync(Expression<Func<T, bool>> expression);
        IQueryable<T> GetAllWhere();
        Task<T> GetByIdAsync(int id);
        Task AddAsync(T tag);
        void Update(T tag);
        void Delete(T tag);
        Task SaveChangesAsync();

    }
}
