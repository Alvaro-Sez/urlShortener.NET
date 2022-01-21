using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using urlShortener.Models;

namespace urlShortener.Controllers
{
    [Route("url/[controller]")]
    [ApiController]
    public class UrlController : ControllerBase
    {
       
        private readonly ApplicationDbContext _context;

        public UrlController(ApplicationDbContext context)
        {
            _context = context;
        }
        

        [HttpGet]
        public async Task<IActionResult> Get()
        {
            try
            {
                var urlList = await _context.Url.ToListAsync();
                return Ok(urlList);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([FromBody] UrlDetail oUrl)
        {
            try
            {
                _context.Add(oUrl);
                await _context.SaveChangesAsync();
                return Ok(oUrl);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }

        }
     
    }
}
