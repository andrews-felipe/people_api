using Microsoft.EntityFrameworkCore;
using people_api.Models;

namespace people_api.Data
{
    public class DataContext : DbContext
    {
        public DbSet<People> Peoples { get; set; }
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {
        }

        // Essa sessão é a configuração de apontamento do banco sql server
        // ficará comentado visto que o projeto é para fins avaliativos
        // Para usar o banco basta comentar o contexto definido acima e descomentar o código abaixo adicionando a connection_string.

        // protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        // {
        //     optionsBuilder.UseSqlServer("CONNETION_STRING");
        // }
    }
}