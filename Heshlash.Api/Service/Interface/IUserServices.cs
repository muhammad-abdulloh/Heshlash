using Heshlash.Api.Models;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heshlash.Api.Service.Interface
{
    public interface IUserServices
    {
        Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null);
        Task<User> GetAsync(Expression<Func<User, bool>> expression);
        Task<User> CreateAsync(User user);
        Task<User> UpdateAsync(User user);
        Task<bool> DeleteAsync(Expression<Func<User, bool>> expression);
    }
}
