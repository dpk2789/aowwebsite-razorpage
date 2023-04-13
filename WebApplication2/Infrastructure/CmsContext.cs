using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using WebApplication2.Infrastructure.Models;

namespace WebApplication2.Infrastructure
{
    public class CmsContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public CmsContext(DbContextOptions<CmsContext> options) : base(options)
        {            
        }

        public DbSet<CmsPages> CmsPages { get; set; }
    }
}
