using Microsoft.EntityFrameworkCore;
using EmpresaAPI.Domain.Entites;

namespace EmpresaAPI.Infrastructure.Data
{
    // Classe responsável pelo mapeamento das entidades
    // para as tabelas do banco de dados
    public class AppDbContext : DbContext
    {
        //Representa a tabela de funcionários no banco de dados
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Pacientes> Pacientes { get; set; }
    }
}
