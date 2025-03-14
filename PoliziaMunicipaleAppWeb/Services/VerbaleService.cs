using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class VerbaleService
    {
        private readonly ContravvenzioniContext _context;

        public VerbaleService(ContravvenzioniContext context)
        {
            _context = context;
        }

        public async Task<List<Verbale>> GetAllAsync()
        {
            return await _context.Verbali
                                 .Include(v => v.Anagrafica)
                                 .Include(v => v.TipoViolazione)
                                 .ToListAsync();
        }

        public async Task<Verbale> GetByIdAsync(int id)
        {
            return await _context.Verbali
                                 .Include(v => v.Anagrafica)
                                 .Include(v => v.TipoViolazione)
                                 .FirstOrDefaultAsync(v => v.IdVerbale == id);
        }

        public async Task<bool> AddAsync(Verbale verbale)
        {
            _context.Verbali.Add(verbale);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(Verbale verbale)
        {
            _context.Verbali.Update(verbale);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Verbali.FindAsync(id);
            if (entity == null)
                return false;
            _context.Verbali.Remove(entity);
            return await SaveAsync();
        }

        private async Task<bool> SaveAsync()
        {
            try
            {
                return await _context.SaveChangesAsync() > 0;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
