using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces;

public interface ITurmaRepository
{
    Task<Turma> GetByIdAsync(Guid id);
    Task<List<Turma>> GetAllAsync();
    Task<Turma> AddAsync(Turma turma);
    Task<Turma> UpdateAsync(Turma turma);
    Task<Turma> DeleteAsync(Guid id);
}
