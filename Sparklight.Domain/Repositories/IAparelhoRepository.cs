using Sparklight.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Sparklight.Domain.Repositories
{
    public interface IAparelhoRepository
    {
        Task<Aparelho> GetByIdAsync(int id);
        Task<IEnumerable<Aparelho>> GetAllAsync();
        Task AddAsync(Aparelho aparelho);
        Task UpdateAsync(Aparelho aparelho);
        Task DeleteAsync(int id);

        //Método para busca de aparelhos por nome 
        Task<IEnumerable<Aparelho>> GetByNomeAsync(string nome);
    }
}
