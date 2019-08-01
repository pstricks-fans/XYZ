using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace XYZ.Controllers
{
    public class HomeController : Controller
    {
        public async Task<IActionResult> Index() => View();

        public async Task<IActionResult> Delete(int id)
        {
            ViewBag.Message = "From Delete";
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            TempData["Message"] = "From DeleteConfirmed";
            return RedirectToAction(nameof(Index));
        }
    }
}