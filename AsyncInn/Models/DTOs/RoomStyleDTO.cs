﻿using System;
using System.Collections.Generic;

namespace Async_Inn.Models.DTOs
{
    public class RoomDTO
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Layout { get; set; }

        public List<AmenityDTO> Amenities { get; set; }
    }
}
