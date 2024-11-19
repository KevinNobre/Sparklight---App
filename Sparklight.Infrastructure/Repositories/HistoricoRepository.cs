using Microsoft.EntityFrameworkCore;
using Sparklight.Data;
using Sparklight.Domain.Entities;
using Sparklight.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparklight.Infrastructure.Repositories
{
    public class HistoricoRepository : IHistoricoRepository
    {
        private readonly SparklightDbContext _context;

        public HistoricoRepository(SparklightDbContext context)
        {
            _context = context;
        }

        // Buscar por ID
        public async Task<Historico> GetByIdAsync(int id)
        {
            return await _context.Historicos.FindAsync(id);
        }

        // Listar todos os históricos
        public async Task<IEnumerable<Historico>> GetAllAsync()
        {
            return await _context.Historicos.ToListAsync();
        }

        // Adicionar um novo histórico
        public async Task AddAsync(Historico historico)
        {
            await _context.Historicos.AddAsync(historico);
            await _context.SaveChangesAsync();
        }

        // Atualizar um histórico
        public async Task UpdateAsync(Historico historico)
        {
            _context.Historicos.Update(historico);
            await _context.SaveChangesAsync();
        }

        // Remover um histórico
        public async Task DeleteAsync(int id)
        {
            var historico = await GetByIdAsync(id);
            if (historico != null)
            {
                _context.Historicos.Remove(historico);
                await _context.SaveChangesAsync();
            }
        }

        // Buscar históricos por ano
        public async Task<IEnumerable<Historico>> GetByAnoAsync(int ano)
        {
            return await _context.Historicos
                .Where(h => h.Ano == ano)
                .ToListAsync();
        }

        // Buscar históricos por mês e ano
        public async Task<IEnumerable<Historico>> GetByMesEAnoAsync(int mes, int ano)
        {
            return await _context.Historicos
                .Where(h => h.Mes == mes && h.Ano == ano)
                .ToListAsync();
        }
    }
}
