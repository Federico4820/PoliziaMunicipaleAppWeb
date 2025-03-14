using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Services;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class AnagraficaController : Controller
    {
        private readonly AnagraficaService _anagraficaService;

        public AnagraficaController(AnagraficaService anagraficaService)
        {
            _anagraficaService = anagraficaService;
        }

        public async Task<IActionResult> Index()
        {
            var anagrafiche = await _anagraficaService.GetAllAsync();
            return View(anagrafiche);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(Anagrafica anagrafica)
        {
            if (ModelState.IsValid)
            {
                await _anagraficaService.AddAsync(anagrafica);
                return RedirectToAction(nameof(Index));
            }
            return View(anagrafica);
        }

    }
}
