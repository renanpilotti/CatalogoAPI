using Microsoft.AspNetCore.Mvc;
using CatalogoAPI.Models;
using CatalogoAPI.Data.Interfaces;
using AutoMapper;
using CatalogoAPI.DTOs;

namespace CatalogoAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IUnityOfWork<Produto> _uow;
        private readonly IMapper _mapper;

        public ProdutosController(IUnityOfWork<Produto> uow, IMapper mapper)
        {
            _uow = uow;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Produto>>> GetProdutos()
        {
            var produtos = await _uow.ProdutoRepository.GetAll();

            return Ok(produtos);
        }

        [HttpGet("{produtoId}")]
        public async Task<ActionResult<ProdutoDTO>> GetProduto(int produtoId)
        {
            var produto = await _uow.ProdutoRepository.Get(a => a.ProdutoId == produtoId);

            if (produto == null)
            {
                return NotFound();
            }

            var produtoDto = _mapper.Map<ProdutoDTO>(produto);

            return Ok(produtoDto);
        }

        [HttpPost]
        public async Task<ActionResult<ProdutoDTO>> PostProduto(ProdutoDTO produtoDto)
        {
            var produto = _mapper.Map<Produto>(produtoDto);

            var produtoCriado = _uow.Repository.Create(produto);
            await _uow.CommitAsync();

            return CreatedAtAction("GetProduto", new { produtoId = produtoCriado.ProdutoId }, produtoCriado);
        }

        [HttpPut("{produtoId}")]
        public async Task<IActionResult> PutProduto(int produtoId, ProdutoDTO produtoDto)
        {
            if (produtoId != produtoDto.ProdutoId)
            {
                return BadRequest();
            }

            var produto = _mapper.Map<Produto>(produtoDto);

            _uow.ProdutoRepository.Update(produto);
            await _uow.CommitAsync();

            return NoContent();
        }

        [HttpDelete("{produtoId}")]
        public async Task<IActionResult> DeleteProduto(int produtoId)
        {
            var produto = await _uow.Repository.Get(a => a.ProdutoId == produtoId);

            if (produto == null)
            {
                return NotFound();
            }

            await _uow.ProdutoRepository.Delete(produto);
            await _uow.CommitAsync();

            return NoContent();
        }
    }
}
