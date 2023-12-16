using HospitalManegementSystem.Data;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using System.Linq.Expressions;

namespace HospitalManegementSystem.Services
{
    public interface IRepository<T> where T : class
    {
        Task<IEnumerable<T>> GetAllAsync();
        Task<T> GetByIdAsync([FromBody]int id);
        Task<T> GetAsync([FromBody] Expression<Func<T, bool>> predicate);
        Task CreateAsync([FromBody] T entity);
        Task UpdateAsync(int id ,[FromBody] T entity);
        Task DeleteAsync([FromBody]int id);
        
    }
}
