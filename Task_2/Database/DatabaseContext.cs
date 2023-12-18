using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;
using Task_2.Models;

namespace Task_2.Database
{
    public class DatabaseContext : DbContext
    {
        public DbSet<Class> Classes { get; set; }
        public DbSet<Models.File> Files { get; set; }
        public DbSet<DataRow> Rows { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=.\\SQLEXPRESS;Initial Catalog=TASK_2;Trusted_Connection=True;TrustServerCertificate=True");
        }
    }
}