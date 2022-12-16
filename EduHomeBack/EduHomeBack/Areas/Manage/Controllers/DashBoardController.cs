using EduHomeBack.DAL;
using Microsoft.AspNetCore.Mvc;

namespace EduHomeBack.Areas.Manage.Controllers
{
    [Area("Manage")]
    public class DashBoardController : Controller
    {
        private readonly AppDbContext _appDbContext;
        public DashBoardController(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
       
    }
}
