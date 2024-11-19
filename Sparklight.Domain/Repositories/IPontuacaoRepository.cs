using Sparklight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparklight.Domain.Repositories
{
    public interface IPontuacaoRepository
    {
        Task<Pontuacao> GetByIdAsync(int id);
        Task<IEnumerable<Pontuacao>> GetAllAsync();
        Task AddAsync(Pontuacao pontuacao);
        Task UpdateAsync(Pontuacao pontuacao);
        Task DeleteAsync(int id);

        // Métodos específicos
        Task<IEnumerable<Pontuacao>> GetByUsuarioAsync(int usuarioId);

    }
}
