namespace CatalogoAPI.Data.Interfaces
{
    public interface IUnityOfWork<T>
    {
        ICategoriaRepository CategoriaRepository { get; }
        IProdutoRepository ProdutoRepository { get; }
        IRepository<T> Repository { get; }
        Task CommitAsync();
        Task DisposeAsync();
    }
}
