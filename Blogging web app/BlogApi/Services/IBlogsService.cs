using BloogingWebSite.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace BloogingWebSite.Services
{
    public interface IBlogsService
    {
        Task<IEnumerable<Blog>> GetAll();  
        Task<Blog> GetById(int id);
        Task<Blog> Add(Blog blog);
        Blog Update(Blog blog);
        Blog Delete(Blog blog);

        PagedList<Blog> GetBlogsAsync(BlogParameters blogParameters);
    }
}