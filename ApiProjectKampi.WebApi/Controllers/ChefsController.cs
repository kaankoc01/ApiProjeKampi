using ApiProjectKampi.WebApi.Context;
using ApiProjectKampi.WebApi.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProjectKampi.WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ChefsController : ControllerBase
    {
        private readonly ApiContext _context;

        public ChefsController(ApiContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult ChefList()
        {
            return Ok(_context.Chefs.ToList());
        }
        [HttpGet("{id}")]
        public IActionResult GetByIdChef(int id)
        {
 
            return Ok(_context.Chefs.Find(id));
        }
        [HttpPost]
        public IActionResult CreateChef(Chef chef)
        {
            _context.Chefs.Add(chef);
            _context.SaveChanges();
            return Ok("Create Chef");
        }
        [HttpPut]
        public IActionResult UpdateChef(Chef chef)
        {
            _context.Chefs.Update(chef);
            _context.SaveChanges();
            return Ok("Update Chef");
        }
        [HttpDelete]
        public IActionResult DeleteChef(int id)
        {
            var value = _context.Chefs.Find(id);
            _context.Chefs.Remove(value);
            _context.SaveChanges();
            return Ok("Delete Chef");
        }
    }
}
