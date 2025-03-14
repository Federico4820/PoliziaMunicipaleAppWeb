using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class TipoViolazioneService
    {
        private readonly ContravvenzioniContext _context;

        public TipoViolazioneService(ContravvenzioniContext context)
        {
            _context = context;
        }

        public async Task<List<TipoViolazione>> GetAllAsync()
        {
            return await _context.TipiViolazione.ToListAsync();
        }

        public async Task<TipoViolazione> GetByIdAsync(int id)
        {
            return await _context.TipiViolazione.FindAsync(id);
        }

        public async Task<bool> AddAsync(TipoViolazione tipoViolazione)
        {
            _context.TipiViolazione.Add(tipoViolazione);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(TipoViolazione tipoViolazione)
        {
            _context.TipiViolazione.Update(tipoViolazione);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.TipiViolazione.FindAsync(id);
            if (entity == null)
                return false;
            _context.TipiViolazione.Remove(entity);
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
