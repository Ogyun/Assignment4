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
        [HttpGet("{categoryId}")]
        public ActionResult<Category>GetCategory(int categoryId)
        {
            var category = _dataService.GetCategory(categoryId);
            if (category == null) return NotFound();
            return Ok(category);
        }
        [HttpPost]
        public ActionResult CreateCategory([FromBody] Category category)
        {
            
            var cat = _dataService.CreateCategory(category.Name, category.Description);
            return CreatedAtAction("CreateCategory", cat);
        }
        [HttpDelete("{categoryId}")]

        public ActionResult DeleteCategory(int categoryId)
        {
            var category = _dataService.DeleteCategory(categoryId);
            if (category == false) return NotFound();
            return Ok();
        }
        [HttpPut("{categoryId}")]
        public ActionResult PutCategory(int categoryId,[FromBody] Category category)
        {
            var cat = _dataService.UpdateCategory(categoryId,category.Name, category.Description);
            if (cat == false) return NotFound();
            return Ok();
        }

    }
}
