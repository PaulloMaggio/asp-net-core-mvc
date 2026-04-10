using Microsoft.AspNetCore.Mvc;
using SalesWebMvc.Models.ViewModels;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly Services.SellerService _sellerService;
        private readonly Services.DepartmentService _departmentService;

        public SellersController(Services.SellerService sellerService, Services.DepartmentService departmentService)
        {
            _sellerService = sellerService;
            _departmentService = departmentService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }

        public IActionResult Create()
        {
            var departments = _departmentService.FindAll();
            var viewModel = new SellerFormViewModel { Departments = departments };
            return View(viewModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Models.Seller seller)
        {
            _sellerService.Insert(seller);
            return RedirectToAction(nameof(Index));
        }

        public IActionResult Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }
            var obj = _sellerService.FindById(id.Value);
            if (obj == null)
            {
                return NotFound();
            }
            return View(obj);
        }

        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(int id)
        {
            _sellerService.Remove(id);
            return RedirectToAction(nameof(Index));
        }
    }
}
