using System.ComponentModel.DataAnnotations;

namespace Demo.Backend.Dtos
{
    public class ProductForCreationDto
    {
        [Required]
        public string Name { get; set; }

        [Required]
        public string Description { get; set; }
    }
}