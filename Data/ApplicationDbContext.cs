using Microsoft.EntityFrameworkCore;
using urlShortener.Models;

namespace urlShortener
{
    public class ApplicationDbContext :DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options ): base(options)
        {

        }

        public DbSet<UrlDetail> Url { get; set; }
    }
}
