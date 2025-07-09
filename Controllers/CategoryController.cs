using Microsoft.AspNetCore.Mvc;
using User_Products_DashBoard_MVC.Models.Entity;
using User_Products_DashBoard_MVC.Service;

namespace User_Products_DashBoard_MVC.Controllers
{
    public class CategoryController : Controller
    {

        private readonly IGenericService<ProductCategory> _genericService;

        public CategoryController(IGenericService<ProductCategory> genericService)
        {
            this._genericService = genericService;
        }


        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var categories = await _genericService.GetAllAsync();
            return View(categories);
        }

        [HttpPost]
        public async Task<IActionResult> CreateCategory(ProductCategory request)
        {
            await _genericService.CreateItemAsync(request);
            return RedirectToAction(nameof(GetAllCategories));
        }

        [HttpGet]
        public IActionResult CreateCategory()
        {
            return View();
        }
    }
}
