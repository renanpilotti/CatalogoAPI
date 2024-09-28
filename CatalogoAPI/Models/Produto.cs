using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace CatalogoAPI.Models
{
    public class Produto
    {
        public int ProdutoId { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string? Nome { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string? Descricao { get; set; }
        [Column(TypeName = "decimal(10,2)")]
        public decimal Preco { get; set; }
        [Required]
        [StringLength(300, ErrorMessage = "Mínimo de {0} caracteres.")]
        public string? ImagemUrl { get; set; }
        public float Estoque { get; set; }
        public DateTime DataCadastro { get; set; }

        public int CategoriaId { get; set; }
        public Categoria? Categoria { get; set; }
    }
}
