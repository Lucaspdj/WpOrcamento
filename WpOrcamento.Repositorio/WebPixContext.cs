using WPOrcamento.Entidade;
using Microsoft.EntityFrameworkCore;

namespace Repository
{
    public class WebPixContext : DbContext
    {
        public DbSet<Orcamento> Orcamento { get; set; }
        public DbSet<Status> Status { get; set; }
        public DbSet<Agenda> Agenda { get; set; }
        public DbSet<Interacao> Interacao { get; set; }


        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            // optionsBuilder.UseSqlServer(@"Server=DESKTOP-9B04LJT\SQLEXPRESS;Database=WebPixPrincipal;Trusted_Connection=True;Integrated Security = True;");
            optionsBuilder.UseSqlServer(@"Data Source=34.226.175.244;Initial Catalog=WpOrcamento;Persist Security Info=True;User ID=sa;Password=StaffPro@123;");

        }
    }
}
