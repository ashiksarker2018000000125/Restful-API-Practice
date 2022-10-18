using EcomAPI.Data;
using EcomAPI.Model;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

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
        public async Task<IActionResult> Get()
        {
            return Ok(await _context.categories.ToListAsync());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetDetals(int id)
        {
            var list = await _context.categories.FindAsync(id);
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
        public async Task<IActionResult> Post([FromBody]Category category)
        {
            //List<Category> categories = new List<Category> { };
            //categories.Add(category);

            if (category == null)
            {
                return BadRequest();
            }
            else
            {
                await _context.categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return StatusCode(StatusCodes.Status201Created);
            }
            
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> Put(int id, [FromBody] Category category)
        {
            var categorylist =await  _context.categories.FirstOrDefaultAsync(x => x.Id == id);

            if (categorylist == null)
            {
                return NotFound();
            }
            else
            {
                categorylist.Title = category.Title;
                categorylist.DisplayOrder = category.DisplayOrder;

                _context.categories.Update(categorylist);
                await _context.SaveChangesAsync();
                return Ok("Category Update Sucessfully");
            } 

        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _context.categories.FindAsync(id);
            if (category == null)
            {
                return NotFound();
            }
            else
            {
                _context.categories.Remove(category);
                await _context.SaveChangesAsync();
                return Ok("Category Deleted Sucessfully");
            }
            
        }
    }
}
