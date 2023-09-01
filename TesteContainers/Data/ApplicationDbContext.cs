using Microsoft.EntityFrameworkCore;
using TesteContainers.Models;
using static TesteContainers.Models.ContainerModel;

namespace TesteContainers.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }

        public DbSet<ContainerModel> Containers { get; set; }
        public DbSet<MovimentacoesModel> Movimentacoes { get; set; }
    }
}

