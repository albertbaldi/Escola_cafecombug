using Escola.Domain.Entities;

namespace Escola.Domain.Interfaces;

public interface ICursoRepository
{
    Task<Curso> GetByIdAsync(Guid id);
    Task<List<Curso>> GetAllAsync();
    Task<Curso> AddAsync(Curso curso);
    Task<Curso> UpdateAsync(Curso curso);
    Task<Curso> DeleteAsync(Guid id);
}