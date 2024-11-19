using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI.DTOs
{
    public class ProdutoDTO
    {
        public int ProdutoId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Máximo de {0} caracteres.")]
        public string? Descricao { get; set; }

        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Máximo de {0} caracteres.")]        
        public string? ImagemUrl { get; set; }

        public int CategoriaId { get; set; }
    }
}
