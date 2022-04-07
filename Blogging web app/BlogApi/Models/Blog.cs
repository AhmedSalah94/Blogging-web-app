using System;
using System.ComponentModel.DataAnnotations;

namespace BloogingWebSite.Models
{
    public class Blog
    {
        public int Id { get; set; }

        [MaxLength(250)]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }

    }
}
