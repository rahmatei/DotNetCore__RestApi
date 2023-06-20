using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using RestSample.Model;
using RestSampleCtrlSamples.Models;

namespace RestSampleCtrlSamples.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// DI Level Constacture
        /// </summary>
        private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            this._dbContext = dbContext;
        }
        /*       [HttpGet]
                public ActionResult GetAllProducts([FromServices]ProductDbContext _dbContext)
                {
                    var products = _dbContext.Products.ToList();
                    return Ok(products);
                }*/

        [HttpGet]
        public async Task<ActionResult> GetAllProducts([FromServices] ProductDbContext _dbContext)
        {
            var products = await _dbContext.Products.ToListAsync();
            return Ok(products);
        }



        [HttpGet("GetProduct/{id}")]
        public ActionResult GetProduct ([FromServices] ProductDbContext _dbContext , int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null) { NotFound(); }
            return Ok(product);
        }
        [HttpPost]
        public IActionResult Post([FromBody] AddProductDto product)
        {
            if (ModelState.IsValid)
            {
                var p = product.ToProduct();
                _dbContext.Products.Add(p);
                _dbContext.SaveChanges();
                return Ok(p.Id);
            }
            return BadRequest(ModelState);
            
        }

        [HttpGet("Redirect")]
        public IActionResult Redirect()
        {
            return Redirect("http://google.com");
        }

    }
}
