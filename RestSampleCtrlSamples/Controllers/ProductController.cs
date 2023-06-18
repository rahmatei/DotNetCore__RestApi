using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RestSample.Model;

namespace RestSampleCtrlSamples.Controllers
{
    [Route("api/[controller]")]
    public class ProductController : ControllerBase
    {
        /// <summary>
        /// DI Level Constacture
        /// </summary>
        /*private readonly ProductDbContext _dbContext;

        public ProductController(ProductDbContext dbContext)
        {
            this._dbContext = dbContext;
        }*/
        [HttpGet]
        public ActionResult GetAllProducts([FromServices]ProductDbContext _dbContext)
        {
            var products = _dbContext.Products.ToList();
            return Ok(products);
        }

        [HttpGet("GetProduct/{id}")]
        public ActionResult GetProduct ([FromServices] ProductDbContext _dbContext , int id)
        {
            var product = _dbContext.Products.SingleOrDefault(p => p.Id == id);
            if (product == null) { NotFound(); }
            return Ok(product);
        }
    }
}
