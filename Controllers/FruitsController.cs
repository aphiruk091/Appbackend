using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using appbackend.Models;
namespace appbackend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FruitsController : ControllerBase
    {
        private readonly OraDbContext _context;

        public FruitsController(OraDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        [Route("GetFruit")]
        public async Task<IActionResult> Get()
        {
            var result = await _context.Fruits.OrderByDescending(e => e.Id).ToListAsync();
            return Ok(result);
        }

        [HttpPost]
        [Route("AddFruit")]
        public async Task<Fruit> AddStudent(Fruit objStudent)
        {
            _context.Fruits.Add(objStudent);
            await _context.SaveChangesAsync();
            return objStudent;
        }
        [HttpPost]
        [Route("AddFile")]
        public IActionResult UploadFile(IFormFile file)
        {
            if (file == null || file.Length == 0)
            {
                return BadRequest("File not selected");
            }

            var fileName = Path.GetFileName(file.FileName);
            var filePath = Path.Combine("D:\\Project\\App_Fruits\\appfrontend\\public\\img", fileName);
            using var stream = new FileStream(filePath, FileMode.Create);
            file.CopyTo(stream);

            return Ok();
        }
        
        [HttpGet]
        [Route("GetFruitName")]
        public async Task<IActionResult> FruitName(string filtername)
        {
            var result = await _context.Fruits.Where(e => e.Name.Contains(filtername)).OrderByDescending(e => e.Id).ToListAsync();
            return Ok(result);
        }
    }
}