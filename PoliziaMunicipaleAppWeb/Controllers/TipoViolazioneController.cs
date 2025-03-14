using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Services;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Controllers
{
    public class TipoViolazioneController : Controller
    {
        private readonly TipoViolazioneService _tipoViolazioneService;

        public TipoViolazioneController(TipoViolazioneService tipoViolazioneService)
        {
            _tipoViolazioneService = tipoViolazioneService;
        }

        public async Task<IActionResult> Index()
        {
            var violazioni = await _tipoViolazioneService.GetAllAsync();
            return View(violazioni);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(TipoViolazione tipoViolazione)
        {
            if (ModelState.IsValid)
            {
                await _tipoViolazioneService.AddAsync(tipoViolazione);
                return RedirectToAction(nameof(Index));
            }
            return View(tipoViolazione);
        }

    }
}
