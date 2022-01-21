using Microsoft.AspNetCore.Mvc;
using urlShortener.Helpers;
using urlShortener.Models;
using urlShortener.Services;

namespace urlShortener.Controllers
{
    [Route("url/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {

        private readonly IUrlShortenerService _service;

        public UrlController(IUrlShortenerService service)
        {
            _service = service;
        }

        [HttpPost]
        public async Task<IActionResult> Post(UrlDetail originalUrl)
        {
            try
            {
                if(originalUrl == null)
                {
                    return BadRequest();
                }

                UrlDetail oUrl = await _service.GetByOriginalUrl(originalUrl.OriginalUrl);

                if (oUrl == null)
                {
                    oUrl = originalUrl;
                    oUrl.Id = 0;
                    int id = await _service.Save(oUrl);
                
                    return Ok(UrlShortenerHelper.Encode(id));
                }
                return Ok(UrlShortenerHelper.Encode(oUrl.Id));

            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        public async Task<IActionResult> Get(string code)
        {
            try
            {
                if(code == null)
                {
                    return BadRequest(new {message = "no short url provided"});
                }
                UrlDetail oUrl = await _service.GetByCode(code);
                if(oUrl == null)
                {
                    return BadRequest(new { message = "invalid code" });
                }
                return Ok(oUrl.OriginalUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }

    }                   
}
