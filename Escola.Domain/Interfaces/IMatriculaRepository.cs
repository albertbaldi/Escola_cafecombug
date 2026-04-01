using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces;

public interface IMatriculaRepository
{
    Task<Matricula> GetByIdAsync(Guid id);
    Task<List<Matricula>> GetAllAsync();
    Task<Matricula> AddAsync(Matricula matricula);
    Task<Matricula> UpdateAsync(Matricula matricula);
    Task<Matricula> DeleteAsync(Guid id);
}
