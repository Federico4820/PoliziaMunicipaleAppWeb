using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class ReportService
    {
        private readonly ContravvenzioniContext _context;

        public ReportService(ContravvenzioniContext context)
        {
            _context = context;
        }

        public async Task<List<TotaleVerbaliReport>> GetTotaleVerbaliPerTrasgressoreAsync()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => new { v.Anagrafica.IdAnagrafica, v.Anagrafica.Cognome, v.Anagrafica.Nome })
                .Select(g => new TotaleVerbaliReport
                {
                    TrasgressoreId = g.Key.IdAnagrafica,
                    Cognome = g.Key.Cognome,
                    Nome = g.Key.Nome,
                    TotaleVerbali = g.Count()
                })
                .ToListAsync();
            return result;
        }

        public async Task<List<TotalePuntiReport>> GetTotalePuntiPerTrasgressoreAsync()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafica)
                .GroupBy(v => new { v.Anagrafica.IdAnagrafica, v.Anagrafica.Cognome, v.Anagrafica.Nome })
                .Select(g => new TotalePuntiReport
                {
                    TrasgressoreId = g.Key.IdAnagrafica,
                    Cognome = g.Key.Cognome,
                    Nome = g.Key.Nome,
                    TotalePunti = g.Sum(v => v.DecurtamentoPunti)
                })
                .ToListAsync();
            return result;
        }
        
        public async Task<List<ViolazioniPuntiReport>> GetViolazioniOltre10PuntiAsync()
        {
            var result = await _context.Verbali
                .Include(v => v.Anagrafica)
                .Where(v => v.DecurtamentoPunti > 10)
                .Select(v => new ViolazioniPuntiReport
                {
                    Importo = v.Importo,
                    DataViolazione = v.DataViolazione,
                    DecurtamentoPunti = v.DecurtamentoPunti,
                    Cognome = v.Anagrafica.Cognome,
                    Nome = v.Anagrafica.Nome
                })
                .ToListAsync();
            return result;
        }

        public async Task<List<Verbale>> GetViolazioniImportoMaggioreDi400Async()
        {
            return await _context.Verbali
                .Include(v => v.Anagrafica)
                .Include(v => v.TipoViolazione)
                .Where(v => v.Importo > 400)
                .ToListAsync();
        }
    }

    public class TotaleVerbaliReport
    {
        public int TrasgressoreId { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public int TotaleVerbali { get; set; }
    }

    public class TotalePuntiReport
    {
        public int TrasgressoreId { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
        public int TotalePunti { get; set; }
    }

    public class ViolazioniPuntiReport
    {
        public decimal Importo { get; set; }
        public DateTime DataViolazione { get; set; }
        public int DecurtamentoPunti { get; set; }
        public string Cognome { get; set; }
        public string Nome { get; set; }
    }
}
