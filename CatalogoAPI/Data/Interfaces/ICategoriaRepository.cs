using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;

namespace CatalogoAPI.Data.Interfaces
{
    public interface ICategoriaRepository : IRepository<Categoria>
    {
        public void Teste(int id);
    }
}
