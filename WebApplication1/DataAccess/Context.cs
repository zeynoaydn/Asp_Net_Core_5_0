using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace WebApplication1.DataAccess
{
    public class Context:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=DESKTOP-UGD7FQ4\\SQLEXPRESS;Database=CoreBlogApiDb;integrated security=true;");
        }
        public DbSet<Employee> Employees { get; set; }
    }
}
