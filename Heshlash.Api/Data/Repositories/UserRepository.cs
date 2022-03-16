using Heshlash.Api.Data.DbContexts;
using Heshlash.Api.Data.IRepositories;
using Heshlash.Api.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Heshlash.Api.Data.Repositories
{
    public class UserRepository : IUserRepository
    {
        protected readonly UserDbContext _dbContext;
        protected DbSet<User> _dbSet;

        public UserRepository(UserDbContext dbContext)
        {
            _dbContext = dbContext;
            _dbSet = _dbContext.Set<User>();
        }


        public async Task<User> CreateAsync(User user)
        {
            string hashPassword = ComputeHash(user.Password, new SHA256CryptoServiceProvider());
            user.Password = hashPassword;
            var entry = await _dbSet.AddAsync(user);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }


        public string ComputeHash(string input, HashAlgorithm algorithm)
        {
            Byte[] inputBytes = Encoding.UTF8.GetBytes(input);

            Byte[] hashedBytes = algorithm.ComputeHash(inputBytes);

            return BitConverter.ToString(hashedBytes);
        }


        public async Task<bool> DeleteAsync(Expression<Func<User, bool>> expression)
        {
            var entry = await _dbSet.FirstOrDefaultAsync(expression);
            if (entry == null)
                return false;
            _dbSet.Remove(entry);
            await _dbContext.SaveChangesAsync();
            return true;
        }
#pragma warning disable
        public async Task<IQueryable<User>> GetAllAsync(Expression<Func<User, bool>> expression = null)
        {
            return expression == null ? _dbSet : _dbSet.Where(expression);
        }
#pragma warning restore
        public async Task<User> GetAsync(Expression<Func<User, bool>> expression)
        {
            return await _dbSet.FirstOrDefaultAsync(expression);
        }

        public async Task<User> UpdateAsync(User user)
        {
            var entry = _dbSet.Update(user);
            await _dbContext.SaveChangesAsync();
            return entry.Entity;
        }
    }
}
