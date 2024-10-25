using Microsoft.AspNetCore.Mvc;

namespace BookStore.AspNetCoreMvc.Controllers
{
    public class AuthourController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
