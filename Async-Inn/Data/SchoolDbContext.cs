using System;
using Microsoft.EntityFrameworkCore;

namespace Async_Inn.Data
{
    public class SchoolDbContext : DbContext
    {
        public SchoolDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
