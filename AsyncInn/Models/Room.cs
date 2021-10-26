using System;
using System.ComponentModel.DataAnnotations;

namespace Async_Inn.Models
{
    public class Room
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Layout { get; set; }

    }
}
