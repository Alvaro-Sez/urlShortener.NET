using urlShortener.Models;

namespace urlShortener.Services;

    public interface IUrlShortenerService
    {
        Task<UrlDetail> GetById(int id);

        Task<UrlDetail> GetByCode(string path);

        Task<UrlDetail> GetByOriginalUrl(string originalUrl);

        Task<int> Save(UrlDetail shortened);
    }
