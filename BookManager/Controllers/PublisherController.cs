using Microsoft.AspNetCore.Mvc;

namespace BookManager.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
