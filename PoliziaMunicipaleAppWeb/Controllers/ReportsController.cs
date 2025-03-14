using Microsoft.AspNetCore.Mvc;
using PoliziaMunicipaleApp.Services;

namespace PoliziaMunicipaleApp.Controllers
{
    public class ReportsController : Controller
    {
        private readonly ReportService _reportService;

        public ReportsController(ReportService reportService)
        {
            _reportService = reportService;
        }

        public IActionResult Index()
        {
            return View();
        }

        public async Task<IActionResult> TotaleVerbaliPerTrasgressore()
        {
            var report = await _reportService.GetTotaleVerbaliPerTrasgressoreAsync();
            return View(report);
        }

        public async Task<IActionResult> TotalePuntiPerTrasgressore()
        {
            var report = await _reportService.GetTotalePuntiPerTrasgressoreAsync();
            return View(report);
        }

        public async Task<IActionResult> ViolazioniOltre10Punti()
        {
            var report = await _reportService.GetViolazioniOltre10PuntiAsync();
            return View(report);
        }

        public async Task<IActionResult> ViolazioniImportoMaggioreDi400()
        {
            var report = await _reportService.GetViolazioniImportoMaggioreDi400Async();
            return View(report);
        }
    }
}
