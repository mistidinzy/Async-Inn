using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models.DTOs
{
    public class AmenityDTO
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}