using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CatalogoAPI.Context;
using CatalogoAPI.Models;
using CatalogoAPI.Data.Interfaces;
using CatalogoAPI.Data.Repository;
using System.Data.Entity;
using CatalogoAPI.DTOs;
using AutoMapper;

namespace CatalogoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriasController : ControllerBase
    {
        protected readonly IUnityOfWork<Categoria> _uow;
        private readonly IMapper _mapper;

        public CategoriasController(IUnityOfWork<Categoria> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<CategoriaDTO>>> GetCategorias()
        {
            var categorias = await _uow.Repository.GetAll();

            var categoriasDto = categorias.Select(a => _mapper.Map<CategoriaDTO>(a));

            return Ok(categoriasDto);
        }

        [HttpGet("{categoriaId}")]
        public async Task<ActionResult<CategoriaDTO>> GetCategoria(int categoriaId)
        {
            var categoria = await _uow.Repository.Get(a => a.CategoriaId == categoriaId);

            if (categoria == null)
            {
                return NotFound();
            }

            var categoriaDto = _mapper.Map<CategoriaDTO>(categoria);

            return Ok(categoriaDto);
        }

        [HttpPost]
        public async Task<ActionResult<CategoriaDTO>> Create(CategoriaDTO categoriaDto)
        {
            var categoria = _mapper.Map<Categoria>(categoriaDto);

            var categoriaCriada = _uow.Repository.Create(categoria);
            await _uow.CommitAsync();

            return CreatedAtAction("GetCategoria", new { categoriaId = categoriaCriada.CategoriaId }, categoriaCriada);
        }

        [HttpPut("{categoriaId}")]
        public async Task<IActionResult> Update(int categoriaId, CategoriaDTO categoriaDto)
        {
            if (categoriaId != categoriaDto.CategoriaId)
            {
                return BadRequest();
            }

            var categoria = _mapper.Map<Categoria>(categoriaDto);

            _uow.Repository.Update(categoria);
            await _uow.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{categoriaId}")]
        public async Task<IActionResult> Delete(int categoriaId)
        {
            var categoria = await _uow.Repository.Get(a => a.CategoriaId == categoriaId);

            if (categoria == null)
            {
                return NotFound();
            }

            await _uow.Repository.Delete(categoria);
            await _uow.CommitAsync();

            return NoContent();
        }
    }
}
