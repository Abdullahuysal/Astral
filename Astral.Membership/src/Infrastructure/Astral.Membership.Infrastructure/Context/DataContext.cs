using Astral.Membership.Core.Aggregates;
using Astral.Membership.Infrastructure.Configurations;
using Microsoft.EntityFrameworkCore;

namespace Astral.Membership.Infrastructure.Context
{
    public class DataContext : DbContext
    {
        public DataContext()
        {

        }
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Member> Members { get; set; }
        public DbSet<Token> Tokens { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);
            builder.ApplyConfiguration(new UserConfig());
        }
    }
}
