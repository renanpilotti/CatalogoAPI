using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string? Nome { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string? Imagem { get; set; }

        public List<Produto> Produtos { get; set; } = [];
    }
}
