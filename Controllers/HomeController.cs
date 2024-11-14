using ECommerse_App;
using ECommerse_App.Data;
using ECommerse_App.Entities;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;


namespace ECommerse_App.Controllers
{
    [ApiController]
    [Route("api")]
    public class HomeController : ControllerBase
    {

        private readonly MongoDbContext _context;

        public HomeController(MongoDbContext context)
        {
            _context = context;
        }


        [HttpGet("")]
        public IActionResult Root()
        {
            return Ok("E-Commerse Root Page...");
        }

        [HttpGet("getproducts")]
        public async Task<List<Product>> GetProducts()
        {
            var result = await _context.product.Find(_ => true).ToListAsync();

            return result;
        }

        [HttpGet("getproduct/{id}")]
        public async Task<IActionResult> GetProductById(int id)
        {
            Console.WriteLine("id: " + id);
            // var filter = Builders<Product>.Filter;
            var result = await _context.product.Find(Builders<Product>.Filter.Eq("_id", id)).FirstOrDefaultAsync();
            Console.WriteLine("Result id: " + result);
            if (result == null)
            {
                return BadRequest("Result Not Found!");
            }
            return Ok(result);
        }

        [HttpPost("addproduct")]
        public async Task<IActionResult> AddProduct([FromBody]Product prod)
        {
            try
            {
                await _context.product.InsertOneAsync(prod);
                return Ok("Added Product...");
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
