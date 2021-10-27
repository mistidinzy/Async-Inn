using System;
using System.ComponentModel.DataAnnotations.Schema;
using Microsoft.AspNetCore.Identity;

namespace Async_Inn.Models.Identity
{
    public class ApplicationUser : IdentityUser
    {
       [Column(TypeName = "DATE")] //Store in SQL as a Date, instead of DateTime
       public DateTime? DateOfBirth { get; set; }
    }
}
