using CatalogoAPI.Context;
using CatalogoAPI.Data.Interfaces;
using CatalogoAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Data.Repository
{
    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(CatalogoAPIDbContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Produto>> GetProdutosByCategoriaId(int categoriaId)
        {
            return (await GetAll()).Where(a => a.CategoriaId == categoriaId);
        }
    }
}
