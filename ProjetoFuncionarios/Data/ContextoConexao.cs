using Microsoft.EntityFrameworkCore;
using ProjetoFuncionarios.Model;

namespace ProjetoFuncionarios.Data
{
    public class ContextoConexao : DbContext
    {
        public DbSet<Funcionario> Funcionarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            base.OnConfiguring(optionsBuilder.UseNpgsql(
                "Server=localhost;" +
                "Port=5432; Database=postgres;" +
                "User Id=postgres;" +
                "Password=123;"));
        }
    }
}
