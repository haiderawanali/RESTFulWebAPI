using Microsoft.EntityFrameworkCore;
using RESTFulWebAPI.Models;

namespace RESTFulWebAPI.Data
{
    public class _DbContext : DbContext
    {
        public _DbContext(DbContextOptions<_DbContext> options) : base(options)
        {
        }

        public DbSet<Customer> Customer { get; set; }
        public DbSet<CustomerType> CustomerType { get; set; }
    }
}
