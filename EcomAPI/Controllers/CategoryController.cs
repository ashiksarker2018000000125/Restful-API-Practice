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
        public IActionResult Get()
        {
            return Ok(_context.categories);
        }

        [HttpGet("{id}")]
        public IActionResult GetDetals(int id)
        {
            var list = _context.categories.Find(id);
            if (list == null)
            {
                return NotFound();
            }
            else
            {
                return Ok(list);
            }
            
        }

        [HttpPost]
        public IActionResult Post([FromBody]Category category)
        {
            //List<Category> categories = new List<Category> { };
            //categories.Add(category);

            if (category == null)
            {
                return BadRequest();
            }
            else
            {
                _context.categories.Add(category);
                _context.SaveChanges();
                return StatusCode(StatusCodes.Status201Created);
            }
            
        }

        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Category category)
        {
            var categorylist = _context.categories.FirstOrDefault(x => x.Id == id);

            if (categorylist == null)
            {
                return NotFound();
            }
            else
            {
                categorylist.Title = category.Title;
                categorylist.DisplayOrder = category.DisplayOrder;

                _context.categories.Update(categorylist);
                _context.SaveChanges();
                return Ok("Category Update Sucessfully");
            } 

        }

        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            var category = _context.categories.Find(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _context.categories.Remove(category);
                _context.SaveChanges();
                return Ok("Category Deleted Sucessfully");
            }
            
        }
    }
}
