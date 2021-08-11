using CoreApi.Entities;
using Microsoft.EntityFrameworkCore;

namespace CoreApi.Helpers
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }

        public DbSet<Todo> Todo { get; set; }
    }
}