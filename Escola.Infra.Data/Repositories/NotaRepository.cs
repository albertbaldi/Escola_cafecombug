using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Infra.Data.Repositories;

public class NotaRepository : INotaRepository
{
    public Task<Nota> AddAsync(Nota nota)
    {
        throw new NotImplementedException();
    }

    public Task<Nota> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Nota>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Nota> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Nota> UpdateAsync(Nota nota)
    {
        throw new NotImplementedException();
    }
}
