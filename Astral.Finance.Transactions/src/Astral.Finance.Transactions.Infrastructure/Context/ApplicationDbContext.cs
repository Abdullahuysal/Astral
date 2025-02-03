using Microsoft.EntityFrameworkCore;

namespace Astral.Finance.Transactions.Infrastructure.Context
{
    public sealed class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }



    }
}
