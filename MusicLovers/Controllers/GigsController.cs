using MusicLovers.Models;
using MusicLovers.ViewModels;
using System.Linq;
using System.Web.Mvc;

namespace MusicLovers.Controllers
{
    public class GigsController : Controller
    {
        private readonly ApplicationDbContext _context;
        public GigsController()
        {
            _context = new ApplicationDbContext();
        }
        public ActionResult Create()
        {
            var viewModel = new GigFormViewModel { Genres = _context.Genres.ToList() };
            return View(viewModel);
        }
    }
}