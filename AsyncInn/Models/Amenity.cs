using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Amenity
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

    }
}
