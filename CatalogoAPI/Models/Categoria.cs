using System.Text.Json.Serialization;
using System.ComponentModel.DataAnnotations;

namespace CatalogoAPI.Models
{
    public class Categoria
    {
        public int CategoriaId { get; set; }

        public string? Nome { get; set; }

        public string? Imagem { get; set; }

        [JsonIgnore]
        public List<Produto> Produtos { get; set; } = [];
    }
}
