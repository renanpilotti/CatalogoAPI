using CatalogoAPI.Data.Interfaces;
using CatalogoAPI.Data.Repository;
using CatalogoAPI.Data.UnityOfWork;

namespace CatalogoAPI.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static IServiceCollection ResolveDependencies(this IServiceCollection service)
        {
            service.AddScoped(typeof(IRepository<>), typeof(Repository<>));
            service.AddScoped(typeof(IUnityOfWork<>), typeof(UnityOfWork<>));
            //service.AddScoped<IUnityOfWork, UnityOfWork>();
            service.AddScoped<ICategoriaRepository, CategoriaRepository>();
            service.AddScoped<IProdutoRepository, ProdutoRepository>();

            return service;
        }
    }
}
