using Microsoft.EntityFrameworkCore;
using PustokOnion202.Application.DTOs.Book;
using PustokOnion202.Application.Interfaces.Repository.Common;
using PustokOnion202.Domain.Entities;
using PustokOnion202.Domain.Entities.Common;
using PustokOnion202.Persistence.Contexts;
using System;
using System.Buffers.Text;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace PustokOnion202.Persistence.Implementations.Repositories
{
    public class Repository<T> : IRepository<T> where T : BaseEntity, new()
    {
        private readonly AppDbContext _context;
        private readonly DbSet<T> _table;

        public Repository(AppDbContext context)
        {
            _context = context;
            _table = context.Set<T>();
        }
        public IQueryable<T> GetAll(params string[] includes)
        {
            IQueryable<T> query = _table;
            query = _addIncludes(query, includes);
            return query;
        }
        public IQueryable<T> GetAllWhere(
            Expression<Func<T,
            bool>>? expression = null,
            Expression<Func<T, object>>? orderExpression = null,
            int skip = 0, int take = 0,
            params string[] includes)
        {
            IQueryable<T> query = _table;
            if (expression != null) query = query.Where(expression);
            if (orderExpression != null) query = query.OrderByDescending(orderExpression);
            if (skip != 0) query = query.Skip(skip);
            if (take != 0) query = query.Take(take);
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
        public async Task<T> GetByIdAsync(int id, params string[] includes)
        {
            IQueryable<T> query = _table.Where(d => d.Id == id);
            query = _addIncludes(query, includes);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<T> GetByExpressionAsync(Expression<Func<T, bool>>? expression = null,params string[] includes)
        {
            IQueryable<T> query = _table.Where(expression);
            query = _addIncludes(query, includes);
            return await query.FirstOrDefaultAsync();
        }
        public async Task<bool> IsExistAsync(Expression<Func<T, bool>> expression)
        {
            return await _table.AnyAsync(expression);
        }
        public async Task<T> GetByIdAsync(int id)
        {
            T tag = await _table.FirstOrDefaultAsync(c => c.Id == id);
            return tag;
        }
        public async Task CreateAsync(CreateBookDto dto)
        {
            if (await _repository.IsExistAsync(p => p.Name == dto.Name)) throw new Exception($"there is a product with the same {dto.Name}");
            if (!await _categoryRepository.IsExistAsync(c => c.Id == dto.CategoryId)) throw new Exception("The product you are looking for is no longer available");

            Book product = _mapper.Map<Product>(dto);

            product.ProductColors = new List<ProductColor>();

            if (dto.ColorIds is not null)
            {
                foreach (var colId in dto.ColorIds)
                {
                    if (!await _colorRepository.IsExistAsync(c => c.Id == colId)) throw new Exception($"Could not find {colId}");
                    product.ProductColors.Add(new ProductColor { ColorId = colId });
                }
            }
            await _repository.AddAsync(product);
            await _repository.SaveChangesAsync();
        }
        public async Task AddAsync(T tag)
        {
            await _table.AddAsync(tag);
        }

        public void Delete(T tag)
        {
            _table.Remove(tag);
        }

        public void Update(T tag)
        {
            _table.Update(tag);
        }

        public async Task SaveChangesAsync()
        {
           await _context.SaveChangesAsync();
        }    
       

        public IQueryable<T> GetAllWhere()
        {
            throw new NotImplementedException();
        }
        private IQueryable<T> _addIncludes(IQueryable<T> query, params string[] includes)
        {
            if (includes is not null)
            {
                for (int i = 0; i < includes.Length; i++)
                {
                    query = query.Include(includes[i]);
                }
            }
            return query;
        }
    }
}
