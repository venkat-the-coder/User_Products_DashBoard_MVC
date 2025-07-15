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

        [HttpGet]
        public async Task<ActionResult> UpdateCategory(int id)
        {
            var category = await _genericService.GetItemByIdAsync(id);
            if (category != null)
            {
                return View(category);
            }

            return NotFound("Category Not Found");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> UpdateCategory(ProductCategory request)
        {
            var itemToBeUpdated = await _genericService.GetItemByIdAsync(request.Id);
            if (itemToBeUpdated != null)
            {
                itemToBeUpdated.Name = request.Name;
                await _genericService.UpdateItem(itemToBeUpdated);
                return RedirectToAction(nameof(GetAllCategories));
            }
            return NotFound("Category to be Updated is Not Found");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> DeleteCategory(int id)
        {
            var itemTobeDeleted = await _genericService.GetItemByIdAsync(id);
            if (itemTobeDeleted != null) {
                Console.WriteLine(itemTobeDeleted.Name);
                await _genericService.DeleteItem(itemTobeDeleted);
                return RedirectToAction(nameof(GetAllCategories));
            }

            return NotFound("Category to be Deleted is Not Found");

        }
    }
}
