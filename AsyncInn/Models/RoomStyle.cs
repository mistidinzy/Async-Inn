using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Models
{
    public class RoomStyle
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int Layout { get; set; }

        public List<RoomAmenity> RoomAmenities { get; set; }

    }
}
