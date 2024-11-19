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
    public class ItemRepository : IItemRepository
    {
        private readonly SparklightDbContext _context;

        public ItemRepository(SparklightDbContext context)
        {
            _context = context;
        }

        // Buscar por ID
        public async Task<Item> GetByIdAsync(int id)
        {
            return await _context.Itens.FindAsync(id);
        }

        // Listar todos os itens
        public async Task<IEnumerable<Item>> GetAllAsync()
        {
            return await _context.Itens.ToListAsync();
        }

        // Adicionar um novo item
        public async Task AddAsync(Item item)
        {
            await _context.Itens.AddAsync(item);
            await _context.SaveChangesAsync();
        }

        // Atualizar um item existente
        public async Task UpdateAsync(Item item)
        {
            _context.Itens.Update(item);
            await _context.SaveChangesAsync();
        }

        // Remover um item
        public async Task DeleteAsync(int id)
        {
            var item = await GetByIdAsync(id);
            if (item != null)
            {
                _context.Itens.Remove(item);
                await _context.SaveChangesAsync();
            }
        }

    }
}
