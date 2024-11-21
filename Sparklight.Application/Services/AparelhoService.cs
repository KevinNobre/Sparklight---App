using Sparklight.Domain.Entities;
using Sparklight.Domain.Repositories;


namespace Sparklight.Services
{
    public class AparelhoService
    {
        private readonly IAparelhoRepository _aparelhoRepository;

        public AparelhoService(IAparelhoRepository aparelhoRepository)
        {
            _aparelhoRepository = aparelhoRepository;
        }

        // Obter aparelho pelo ID
        public async Task<Aparelho> GetAparelhoByIdAsync(int id)
        {
            return await _aparelhoRepository.GetByIdAsync(id);
        }

        // Obter todos os aparelhos
        public async Task<IEnumerable<Aparelho>> GetAllAparelhosAsync()
        {
            return await _aparelhoRepository.GetAllAsync();
        }

        // Adicionar um novo aparelho
        public async Task AddAparelhoAsync(Aparelho aparelho)
        {
            // Lógica adicional, se necessária (ex.: validações)
            if (string.IsNullOrWhiteSpace(aparelho.Nome))
            {
                throw new ArgumentException("O nome do aparelho não pode ser vazio.");
            }

            if (aparelho.Potencia <= 0)
            {
                throw new ArgumentException("A potência do aparelho deve ser maior que zero.");
            }

            await _aparelhoRepository.AddAsync(aparelho);
        }

        // Atualizar um aparelho existente
        public async Task UpdateAparelhoAsync(Aparelho aparelho)
        {
            // Lógica adicional, se necessária (ex.: validações)
            var existingAparelho = await _aparelhoRepository.GetByIdAsync(aparelho.AparelhoId);
            if (existingAparelho == null)
            {
                throw new KeyNotFoundException("O aparelho não foi encontrado.");
            }

            await _aparelhoRepository.UpdateAsync(aparelho);
        }

        // Deletar um aparelho pelo ID
        public async Task DeleteAparelhoAsync(int id)
        {
            var aparelho = await _aparelhoRepository.GetByIdAsync(id);
            if (aparelho == null)
            {
                throw new KeyNotFoundException("O aparelho não foi encontrado.");
            }

            await _aparelhoRepository.DeleteAsync(id);
        }

        // Buscar aparelhos por nome
        public async Task<IEnumerable<Aparelho>> GetAparelhosByNomeAsync(string nome)
        {
            if (string.IsNullOrWhiteSpace(nome))
            {
                throw new ArgumentException("O nome para a busca não pode ser vazio.");
            }

            return await _aparelhoRepository.GetByNomeAsync(nome);
        }
    }
}
