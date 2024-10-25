using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCoreMvc.Controllers
{
    public class PublisherController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
