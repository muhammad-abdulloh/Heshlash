using Heshlash.Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Heshlash.Api.Data.DbContexts
{
    public class UserDbContext : DbContext
    {
        public UserDbContext(DbContextOptions<UserDbContext> options) : base(options)
        {
        }
        public virtual DbSet<User> Users { get; set; }
    }
}
