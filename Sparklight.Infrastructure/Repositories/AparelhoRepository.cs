﻿using Microsoft.EntityFrameworkCore;
using Sparklight.Data;
using Sparklight.Domain.Entities;
using Sparklight.Domain.Repositories;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Sparklight.Infrastructure.Repositories
{
    public class AparelhoRepository : IAparelhoRepository
    {
        private readonly SparklightDbContext _context;

        public AparelhoRepository(SparklightDbContext context)
        {
            _context = context;
        }

        public async Task<Aparelho> GetByIdAsync(int id)
        {
            return await _context.Aparelhos.FindAsync(id);
        }

        public async Task<IEnumerable<Aparelho>> GetAllAsync()
        {
            return await _context.Aparelhos.ToListAsync();
        }

        public async Task AddAsync(Aparelho aparelho)
        {
            await _context.Aparelhos.AddAsync(aparelho);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateAsync(Aparelho aparelho)
        {
            _context.Aparelhos.Update(aparelho);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteAsync(int id)
        {
            var aparelho = await GetByIdAsync(id);
            if (aparelho != null)
            {
                _context.Aparelhos.Remove(aparelho);
                await _context.SaveChangesAsync();
            }
        }

        public async Task<IEnumerable<Aparelho>> GetByNomeAsync(string nome)
        {
            return await _context.Aparelhos
                .Where(a => EF.Functions.Like(a.Nome, $"%{nome}%"))
                .ToListAsync();
        }
    }
}
