using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/products")]
    public class ProductsController:ControllerBase
    {
        IDataService _dataService;

        public ProductsController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet("{productId}")]
        public ActionResult<Product>GetProduct(int productId)
        {
            var product = _dataService.GetProduct(productId);
            if (product == null) return NotFound();
            return Ok(product);
        }

        [HttpGet("category/{categoryId}")]
        public ActionResult<List<Product>>GetProductsByCategory(int categoryId)
        {
            var products = _dataService.GetProductByCategory(categoryId);
            List<Product> empthyList = new List<Product>();
            if (products == null) return NotFound(empthyList);
            return Ok(products);
        }

    }
}
