using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using XYZ.Data;
using XYZ.Models;
using System.Threading.Tasks;

namespace XYZ.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class PersonController : Controller
    {
        private readonly AppDbContext _db;
        public PersonController(AppDbContext db) => _db = db;

        public async Task<IActionResult> Index()
        {
            return View(await _db.People.ToListAsync());
        }


        public async Task<IActionResult> Delete(int id)
        {
            Person p = await _db.People.FindAsync(id);
            if (p == null)
                return NotFound();

            return View(p);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            Person p = await _db.People.FindAsync(id);
            if (p == null)
                return NotFound();

            _db.People.Remove(p);
            await _db.SaveChangesAsync();

            return RedirectToAction(nameof(Index));
        }
    }
}