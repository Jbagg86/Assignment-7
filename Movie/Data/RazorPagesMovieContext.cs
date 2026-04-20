using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Assignment9A.Models;

namespace Assignment9A.Data
{
    public class Assignment9AContext : IdentityDbContext
    {
        public Assignment9AContext(DbContextOptions<Assignment9AContext> options)
            : base(options)
        {
        }

        public DbSet<Assignment9A.Models.Movie> Movie { get; set; } = default!;
    }
}