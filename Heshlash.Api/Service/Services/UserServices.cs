using Heshlash.Api.Data.DbContexts;
using Heshlash.Api.Data.IRepositories;
using Heshlash.Api.Models;
using Heshlash.Api.Service.Interface;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Heshlash.Api.Service.Services
{
    public class UserServices : IUserServices
    {
        protected readonly IUserRepository _userRepo;

        protected readonly UserDbContext _dbContext;
        protected DbSet<User> _dbSet;


        public UserServices(IUserRepository userRepo, UserDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
            _userRepo = userRepo;
        }

        public Task<User> CreateAsync(User user)
        {
            return _userRepo.CreateAsync(user);
        }

        public Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            return _userRepo.DeleteAsync(expression);
        }
#pragma warning disable CS1998 // Async method lacks 'await' operators and will run synchronously
        public async Task<IEnumerable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            return await _userRepo.GetAllAsync();
        }

        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {

            return await _userRepo.GetAsync(expression);
        }

        public Task<User> UpdateAsync(User user)
        {
            return _userRepo.UpdateAsync(user);
        }




    }
}
