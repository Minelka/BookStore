using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCoreMvc.Controllers
{
    public class BookTypeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
