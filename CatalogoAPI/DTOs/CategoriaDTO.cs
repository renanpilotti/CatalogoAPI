using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI.DTOs
{
    public class CategoriaDTO
    {
        public int CategoriaId { get; set; }

        [Required]
        [StringLength(50, ErrorMessage = "Máximo de {0} caracteres.")]
        public string? Nome { get; set; }

        [Required]
        [StringLength(300, ErrorMessage = "Máximo de {0} caracteres.")]
        public string? Imagem { get; set; }
    }
}
