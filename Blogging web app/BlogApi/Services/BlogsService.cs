using Microsoft.EntityFrameworkCore;
using BloogingWebSite.Models;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BloogingWebSite.Services;

namespace BloogingWebSite.Services
{
    public class BlogsService : IBlogsService
    {
        private readonly ApplicationDbContext _context;

        public BlogsService(ApplicationDbContext context)
        {
            _context = context;
        }


        public async Task<Blog> Add(Blog blog)
        {
            await _context.AddAsync(blog);
            _context.SaveChanges();

            return blog;
        }

        public Blog Delete(Blog blog)
        {
            _context.Remove(blog);
            _context.SaveChanges();

            return blog;
        }

        public async Task<IEnumerable<Blog>> GetAll()
        {
            return await _context.Blogs
                .OrderByDescending(m => m.CreationDate)
                .ToListAsync();
        }

        public async Task<Blog> GetById(int id)
        {
            return await _context.Blogs.SingleOrDefaultAsync(m => m.Id == id);
        }

        public Blog Update(Blog blog)
        {
            _context.Update(blog);
            _context.SaveChanges();

            return blog;
        }
       public PagedList< Blog> GetBlogsAsync(BlogParameters blogParameters)

        { 

            var Blogs =  _context.Blogs .OrderBy(e => e.CreationDate).ToList(); 
            return PagedList<Blog>.
                ToPagedList(Blogs, blogParameters.PageNumber, blogParameters.PageSize); }
    }
}