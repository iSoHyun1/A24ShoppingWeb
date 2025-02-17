using A24Shopping.Repository;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace A24Shopping.Controllers
{
    public class ProductController : Controller
    {
        private readonly DataContext _dataContext;

        public ProductController(DataContext context) 
        {
            _dataContext = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult AllProduct()
        {
            var products = _dataContext.Products.Include("Category").ToList();
            return View(products);
        }


        public async Task<IActionResult> Details(int Id)
        {
            if (Id == null) return RedirectToAction("Index");

            var productsById = _dataContext.Products.Where(p => p.Id == Id).FirstOrDefault();

            return View(productsById);
        }
    }
}
