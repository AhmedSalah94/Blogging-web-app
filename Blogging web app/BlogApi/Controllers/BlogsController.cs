using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BloogingWebSite.Dtos;
using BloogingWebSite.Models;
using BloogingWebSite.Services;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System;

namespace BloogingWebSite.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BlogsController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IBlogsService _blogsService;

        public BlogsController(IBlogsService blogsService, IMapper mapper)
        {
            _blogsService = blogsService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var blogs = await _blogsService.GetAll();

            var data = _mapper.Map<IEnumerable<BlogDto>>(blogs);

            return Ok(data);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var blog = await _blogsService.GetById(id);

            if(blog == null)
                return NotFound();

            var dto = _mapper.Map<BlogDto>(blog);

            return Ok(dto);
        }


        [HttpPost("CreateAsync")]
        public async Task<IActionResult> CreateAsync(AddBlogDto dto)
        {
            var blog = _mapper.Map<Blog>(dto);
            blog.CreationDate = DateTime.Now;

           await _blogsService.Add(blog);

            return Ok(blog);
        }

        [HttpPut("UpdateAsync")]
        public async Task<IActionResult> UpdateAsync(UpdateBlogDto dto)
        {
            var blog = await _blogsService.GetById(dto.Id);

            if (blog == null)
                return NotFound($"No blog was found with ID {dto.Id}");


            blog.Title = dto.Title;
            blog.CreationDate = dto.CreationDate;
            blog.Body = dto.Body;

            _blogsService.Update(blog);

            return Ok(blog);
        }

        [HttpDelete("DeleteAsync/{id}")]
      
        public async Task<IActionResult> DeleteAsync(int id)
        {
            var blog = await _blogsService.GetById(id);

            if (blog == null)
                return NotFound($"No blog was found with ID {id}");

            _blogsService.Delete(blog);

            return Ok(blog);
        }

        [HttpGet]
        [Route("GetBlogPagging")]
        public IActionResult GetBlogs( [FromQuery] BlogParameters blogParameters)
        {

            var bLogsFromDb = _blogsService.GetBlogsAsync(blogParameters);
            Response.Headers.Add("X-Pagination", JsonConvert.SerializeObject(bLogsFromDb.MetaData));
            
            return Ok(bLogsFromDb);
        }

    }
}