using Heshlash.Api.Models;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heshlash.Api.Data.IRepositories
{
    public interface IUserRepository
    {
        Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
