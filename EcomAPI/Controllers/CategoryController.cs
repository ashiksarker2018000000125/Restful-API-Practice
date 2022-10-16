using EcomAPI.Data;
using EcomAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace EcomAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        public CategoryController(ApplicationDbContext context)
        {
            _context = context;
        }

        //public static List<Category> listofCategory = new List<Category>
        //{
        //    new Category {Id=1,Title="Samsung",DisplayOrder=1 },
        //     new Category {Id=2, Title="Apple", DisplayOrder=2},
        //      new Category {Id=3, Title="Nokia", DisplayOrder=3},
        //};


        [HttpGet]
        public IEnumerable<Category> Get()
        {
            return _context.categories;
        }

        [HttpGet("{id}")]
        public Category GetDetals(int id)
        {
            var list = _context.categories.Find(id);
            return list;
        }

        [HttpPost]
        public void Post([FromBody]Category category)
        {
            //List<Category> categories = new List<Category> { };
            //categories.Add(category);

            _context.categories.Add(category);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void Put(int id, [FromBody] Category category)
        {
            var categorylist = _context.categories.FirstOrDefault(x => x.Id == id);
            categorylist.Title = category.Title;
            categorylist.DisplayOrder = category.DisplayOrder;
            
            _context.categories.Update(categorylist);
            _context.SaveChanges();

        }

        [HttpDelete("{id}")]
        public void Delete(int id)
        {
            var category = _context.categories.Find(id);
            _context.categories.Remove(category);
            _context.SaveChanges();
        }
    }
}
