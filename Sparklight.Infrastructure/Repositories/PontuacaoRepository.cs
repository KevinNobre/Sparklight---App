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
    public class PontuacaoRepository : IPontuacaoRepository
    {
        private readonly SparklightDbContext _context;

        public PontuacaoRepository(SparklightDbContext context)
        {
            _context = context;
        }

        // Buscar pontuação por ID
        public async Task<Pontuacao> GetByIdAsync(int id)
        {
            return await _context.Pontuacoes.FindAsync(id);
        }

        // Listar todas as pontuações
        public async Task<IEnumerable<Pontuacao>> GetAllAsync()
        {
            return await _context.Pontuacoes.ToListAsync();
        }

        // Adicionar uma nova pontuação
        public async Task AddAsync(Pontuacao pontuacao)
        {
            await _context.Pontuacoes.AddAsync(pontuacao);
            await _context.SaveChangesAsync();
        }

        // Atualizar uma pontuação existente
        public async Task UpdateAsync(Pontuacao pontuacao)
        {
            _context.Pontuacoes.Update(pontuacao);
            await _context.SaveChangesAsync();
        }

        // Remover uma pontuação
        public async Task DeleteAsync(int id)
        {
            var pontuacao = await GetByIdAsync(id);
            if (pontuacao != null)
            {
                _context.Pontuacoes.Remove(pontuacao);
                await _context.SaveChangesAsync();
            }
        }

        // Buscar pontuações por usuário
        public async Task<IEnumerable<Pontuacao>> GetByUsuarioAsync(int usuarioId)
        {
            return await _context.Pontuacoes
                .Where(p => p.UsuarioId == usuarioId)
                .ToListAsync();
        }

    }
}
