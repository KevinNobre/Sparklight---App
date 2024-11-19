using Sparklight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparklight.Domain.Repositories
{
    public interface IHistoricoRepository
    {
        Task<Historico> GetByIdAsync(int id);
        Task<IEnumerable<Historico>> GetAllAsync();
        Task AddAsync(Historico historico);
        Task UpdateAsync(Historico historico);
        Task DeleteAsync(int id);

        // Para buscar histórico por ano
        Task<IEnumerable<Historico>> GetByAnoAsync(int ano);

        // Para buscar histórico por mês e ano
        Task<IEnumerable<Historico>> GetByMesEAnoAsync(int mes, int ano);
    }
}
