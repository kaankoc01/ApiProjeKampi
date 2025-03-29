using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CategoriesController : ControllerBase
    {
        private readonly ApiContext _context;
        public CategoriesController(ApiContext context)
        {
            _context = context;
        }
        [HttpGet]
        public IActionResult CategoryList()
        {
            var values = _context.Categories.ToList();
            return Ok(values);

        }
        [HttpGet("{id}")]
        public IActionResult GetByIdCategory(int id)
        {
            var category = _context.Categories.Find(id);
            if (category == null)
            {
                return NotFound("Category not found");
            }
            return Ok(category);
        }
        [HttpPost]
        public IActionResult CreateCategory(Category category)
        {
            _context.Categories.Add(category);
            _context.SaveChanges();
            return Ok("Kategori ekleme işlemi başarılı");
        }
        [HttpPut]
        public IActionResult UpdateCategory(Category category)
        {
            _context.Categories.Update(category);
            _context.SaveChanges();
            return Ok("Kategori güncelleme işlemi başarılı.");
        }
        [HttpDelete]
        public IActionResult DeleteCategory(int id)
        {
            var category = _context.Categories.Find(id);
            //if (category == null)
            //{
            //    return NotFound("Category not found");
            //}
            _context.Categories.Remove(category);
            _context.SaveChanges();
            return NoContent();
        }
    }
}
