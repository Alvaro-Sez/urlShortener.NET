using System.ComponentModel.DataAnnotations;

namespace urlShortener.Models;

    public class UrlDetail
    {

        public int Id { get; set; }

        [Required]
        public string OriginalUrl { get; set; }

    }

