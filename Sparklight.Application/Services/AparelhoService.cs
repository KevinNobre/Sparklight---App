using Sparklight.Domain.Entities;
using Sparklight.Infrastructure;
using Microsoft.EntityFrameworkCore;
using Sparklight.Data;

namespace Sparklight.Services
{
    public class AparelhoService
    {
        private readonly SparklightDbContext _dbContext;

        public AparelhoService(SparklightDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public async Task<IEnumerable<Aparelho>> GetAllAparelhosAsync()
        {
            return await _dbContext.Aparelhos.ToListAsync();
        }

        public async Task<Aparelho?> GetAparelhoByIdAsync(int id)
        {
            return await _dbContext.Aparelhos.FindAsync(id);
        }

        public async Task AddAparelhoAsync(Aparelho aparelho)
        {
            _dbContext.Aparelhos.Add(aparelho);
            await _dbContext.SaveChangesAsync();
        }

        public async Task UpdateAparelhoAsync(Aparelho aparelho)
        {
            var existente = await _dbContext.Aparelhos.FindAsync(aparelho.AparelhoId);
            if (existente == null)
            {
                throw new KeyNotFoundException("Aparelho não encontrado.");
            }

            existente.Nome = aparelho.Nome;
            existente.Potencia = aparelho.Potencia;

            _dbContext.Aparelhos.Update(existente);
            await _dbContext.SaveChangesAsync();
        }

        public async Task DeleteAparelhoAsync(int id)
        {
            var aparelho = await _dbContext.Aparelhos.FindAsync(id);
            if (aparelho == null)
            {
                throw new KeyNotFoundException("Aparelho não encontrado.");
            }

            _dbContext.Aparelhos.Remove(aparelho);
            await _dbContext.SaveChangesAsync();
        }

        public async Task<IEnumerable<Aparelho>> GetAparelhosByNomeAsync(string nome)
        {
            return await _dbContext.Aparelhos
                .Where(a => a.Nome.Contains(nome))
                .ToListAsync();
        }
    }
}
