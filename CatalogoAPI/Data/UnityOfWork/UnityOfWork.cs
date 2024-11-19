using CatalogoAPI.Context;
using CatalogoAPI.Data.Interfaces;
using CatalogoAPI.Data.Repository;

namespace CatalogoAPI.Data.UnityOfWork
{
    public class UnityOfWork<T> : IUnityOfWork<T> where T : class
    {
        private readonly ICategoriaRepository? _categoriaRepo;
        private readonly IProdutoRepository? _produtoRepo;
        private readonly IRepository<T>? _repo;

        public CatalogoAPIDbContext _context;

        public UnityOfWork(CatalogoAPIDbContext context)
        {
            _context = context;
        }

        public ICategoriaRepository CategoriaRepository { 
            get 
            { 
                return _categoriaRepo ?? new CategoriaRepository(_context); 
            } 
        }
        
        public IProdutoRepository ProdutoRepository
        { 
            get 
            { 
                return _produtoRepo ?? new ProdutoRepository(_context); 
            } 
        }

        public IRepository<T> Repository
        {
            get
            {
                return _repo ?? new Repository<T>(_context);
            }
        }

        public async Task CommitAsync()
        {
            await _context.SaveChangesAsync();
        }

        public async Task DisposeAsync()
        {
            await _context.DisposeAsync();
        }
    }
}
