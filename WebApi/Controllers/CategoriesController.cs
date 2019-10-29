using DatabaseService;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("api/categories")]
    public class CategoriesController:ControllerBase
    {
        IDataService _dataService;

        public CategoriesController(IDataService dataService)
        {
            _dataService = dataService;
        }

        [HttpGet]
        public ActionResult<List<Category>> GetCategories()
        {
            var categories = _dataService.GetCategories();
            return Ok(categories);
        }
    }
}
