using System.ComponentModel.DataAnnotations;  // Necessário para usar DataAnnotations

namespace ProductClienthub.api.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "The product name is required.")]
        public string Name { get; set; }  // Agora é obrigatório (não anulável)

        [Range(0.01, double.MaxValue, ErrorMessage = "The price must be greater than 0.")]
        public decimal Price { get; set; }
    }
}
