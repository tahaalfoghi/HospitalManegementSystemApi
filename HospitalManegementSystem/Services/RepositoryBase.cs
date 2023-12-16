using HospitalManegementSystem.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace HospitalManegementSystem.Services
{
    // Repository Pattern Implementation
    public class RepositoryBase<T>:IRepository<T> where T : class
    {
        
        private readonly AppDbContext _context;

        public RepositoryBase(AppDbContext context)
        {
            _context = context;
        }

        public async Task CreateAsync([FromBody] T entity)
        {
            var record = entity;
            await _context.Set<T>().AddAsync(record);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync([FromBody] int id)
        {
            var record = await _context.Set<T>().FindAsync(id);
            _context.Set<T>().Remove(record);
           await _context.SaveChangesAsync();


        }

        public async Task<IEnumerable<T>> GetAllAsync()
        {
            return await _context.Set<T>().ToListAsync();
        }

        public async Task<T> GetAsync([FromBody] Expression<Func<T, bool>> predicate)
        {
            var record = await _context.Set<T>().SingleOrDefaultAsync(predicate);

            return record;
        }

        public async Task<T> GetByIdAsync([FromBody] int id)
        {
            var record =await _context.Set<T>().FindAsync(id);
            return record;
        }

        public async Task UpdateAsync( int id, [FromBody] T entity)
        {
            _context.Set<T>().Update(entity);
            await _context.SaveChangesAsync();
        }
    }
}
