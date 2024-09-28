using CatalogoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Context
{
    public class CatalogoAPIDbContext : DbContext
    {
        public CatalogoAPIDbContext(DbContextOptions<CatalogoAPIDbContext> options) : base(options) 
        { 
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
    }
}
