using Microsoft.EntityFrameworkCore;
using Task_1.Model;

namespace Task_1.DatabaseContext
{
    public class TxtDbContext : DbContext
    {
        public DbSet<TxtData> Rows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=TASK_1;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}