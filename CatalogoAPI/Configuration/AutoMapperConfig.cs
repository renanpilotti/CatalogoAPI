using AutoMapper;
using CatalogoAPI.DTOs;
using CatalogoAPI.Models;

namespace CatalogoAPI.Configuration
{
    public class AutoMapperConfig : Profile
    {
        public AutoMapperConfig() 
        {
            CreateMap<Categoria, CategoriaDTO>().ReverseMap();
            CreateMap<Produto, ProdutoDTO>().ReverseMap();
        }
    }
}
