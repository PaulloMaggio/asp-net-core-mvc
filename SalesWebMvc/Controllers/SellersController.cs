using Microsoft.AspNetCore.Mvc;

namespace SalesWebMvc.Controllers
{
    public class SellersController : Controller
    {
        private readonly Services.SellerService _sellerService;

        public SellersController(Services.SellerService sellerService)
        {
            _sellerService = sellerService;
        }

        public IActionResult Index()
        {
            var list = _sellerService.FindAll();

            return View(list);
        }


    }
}
