using EduHomeBack.DAL;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace EduHomeBack.Controllers
{
    public class HomeController : Controller
    {
        private readonly AppDbContext _context;

        public HomeController(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IActionResult> Index()
        { 
            return View();
        }

       
    }
}
