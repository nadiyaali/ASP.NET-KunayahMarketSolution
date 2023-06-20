using KunayahMarketPrj.Model;
using KunayahMarketPrj.WebSite.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace KunayahMarketPrj.Controllers
 {
    // This uses the route =   localhost:1234/products
    [Route("[controller]")]
    [ApiController]
    public class ProductsController : ControllerBase
    {
        public JsonFileProductService ProductService { get;}
        public ProductsController(JsonFileProductService productService) 
        { 
            this.ProductService = productService;
        }

        [HttpGet]
        public IEnumerable<Product> Get()
        { 
            return ProductService.GetProducts();
        }


        // Add a get request for adding rating, instead of get, patch should be used
        // url wil be = localhost:1234/products/rate
        //jenlooper-cactus
        [Route("Rate")]
        [HttpGet]     
        public ActionResult Get([FromQuery] string productId, [FromQuery] int rating) 
        { 
            ProductService.AddRating(productId, rating);
            return Ok();
            
        }
    }
}
