using API.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        public DbSet<Notification> Notifications { get; set; }
        
    }
}