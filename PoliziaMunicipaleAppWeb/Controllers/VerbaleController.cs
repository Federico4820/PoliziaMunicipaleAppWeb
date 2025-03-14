using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Services;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class VerbaleController : Controller
    {
        private readonly VerbaleService _verbaleService;

        public VerbaleController(VerbaleService verbaleService)
        {
            _verbaleService = verbaleService;
        }

        public async Task<IActionResult> Index()
        {
            var verbali = await _verbaleService.GetAllAsync();
            return View(verbali);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Verbale verbale)
        {
            if (ModelState.IsValid)
            {
                await _verbaleService.AddAsync(verbale);
                return RedirectToAction(nameof(Index));
            }
            return View(verbale);
        }

    }
}
