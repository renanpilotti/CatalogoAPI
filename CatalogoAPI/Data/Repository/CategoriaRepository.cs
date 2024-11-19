using CatalogoAPI.Context;
using CatalogoAPI.Data.Interfaces;
using CatalogoAPI.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CatalogoAPI.Data.Repository
{
    public class CategoriaRepository : Repository<Categoria>, ICategoriaRepository
    {

        public CategoriaRepository(CatalogoAPIDbContext context) : base(context)
        {
        }

        public void Teste(int id)
        {
            Console.WriteLine($"Id de número {id}.");
        }
    }
}
