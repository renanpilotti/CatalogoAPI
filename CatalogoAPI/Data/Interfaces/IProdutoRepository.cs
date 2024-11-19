using CatalogoAPI.Models;

namespace CatalogoAPI.Data.Interfaces
{
    public interface IProdutoRepository : IRepository<Produto>
    {
        Task<IEnumerable<Produto>> GetProdutosByCategoriaId(int categoriaId);
    }
}
