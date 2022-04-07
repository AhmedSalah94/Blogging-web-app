using Microsoft.AspNetCore.Http;
using System;
using System.ComponentModel.DataAnnotations;

namespace BloogingWebSite.Dtos
{
    public class BlogDto
    {
        public int Id
        {
            get; set;
        }
            [MaxLength(250)]
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class UpdateBlogDto
    {
        
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public DateTime CreationDate { get; set; }
    }
    public class AddBlogDto
    {

        
        public string Title { get; set; }
        public string Body { get; set; }
        
    }
}