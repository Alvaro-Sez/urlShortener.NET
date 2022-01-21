using Microsoft.EntityFrameworkCore;
using urlShortener.Helpers;
using urlShortener.Models;

namespace urlShortener.Services
{
    public class UrlShortenerService : IUrlShortenerService
    {
        private readonly ApplicationDbContext _context;

        public UrlShortenerService(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<UrlDetail> GetById(int id)
        {
            UrlDetail oUrl = await _context.Url.FindAsync(id);
            return oUrl;
        }

        public async Task<UrlDetail> GetByCode(string code)
        {
            int id = UrlShortenerHelper.Decode(code);
            UrlDetail oUrl = await _context.Url.FindAsync(id);
            return oUrl;
        }

        public async Task<UrlDetail> GetByOriginalUrl(string originalUrl)
        {
            List<UrlDetail> urlList = await _context.Url.ToListAsync();
            
            foreach(UrlDetail oUrl in urlList)
            {
                if (oUrl.OriginalUrl == originalUrl)
                {
                    return oUrl;
                }
            }

            return null;
        }

        public async Task<int> Save(UrlDetail shortened)
        {
            _context.Url.Add(shortened);
            await _context.SaveChangesAsync();

            return shortened.Id;
        }
    }
}
