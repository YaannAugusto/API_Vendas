using Microsoft.EntityFrameworkCore;
using Pagamento.Models;

namespace Pagamento.Context
{
    public class VendaContext : DbContext
    {
        public VendaContext(DbContextOptions<VendaContext> options) : base(options)
        {}

        public DbSet<Venda> Vendas {get; set;}
    }
}