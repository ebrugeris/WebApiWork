using Microsoft.EntityFrameworkCore;

namespace WebApiWork.Models
{
    public class AdminUserContext:DbContext
    {
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Data Source=DESKTOP-IO74TBU\SQLEXPRESS01;Initial Catalog=WebApiSample;Integrated Security=True;TrustServerCertificate=True;");
        }
        public DbSet<AdminUser> AdminUsers { get; set; }
    }
}
