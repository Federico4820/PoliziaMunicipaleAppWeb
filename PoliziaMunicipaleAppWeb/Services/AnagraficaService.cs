using Microsoft.EntityFrameworkCore;
using PoliziaMunicipaleAppWeb.Models;

namespace PoliziaMunicipaleApp.Services
{
    public class AnagraficaService
    {
        private readonly ContravvenzioniContext _context;

        public AnagraficaService(ContravvenzioniContext context)
        {
            _context = context;
        }

        public async Task<List<Anagrafica>> GetAllAsync()
        {
            return await _context.Anagrafiche.ToListAsync();
        }

        public async Task<Anagrafica> GetByIdAsync(int id)
        {
            return await _context.Anagrafiche.FindAsync(id);
        }

        public async Task<bool> AddAsync(Anagrafica anagrafica)
        {
            _context.Anagrafiche.Add(anagrafica);
            return await SaveAsync();
        }

        public async Task<bool> UpdateAsync(Anagrafica anagrafica)
        {
            _context.Anagrafiche.Update(anagrafica);
            return await SaveAsync();
        }

        public async Task<bool> DeleteAsync(int id)
        {
            var entity = await _context.Anagrafiche.FindAsync(id);
            if (entity == null)
                return false;
            _context.Anagrafiche.Remove(entity);
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
