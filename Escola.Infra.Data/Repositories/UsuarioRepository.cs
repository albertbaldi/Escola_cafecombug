using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Infra.Data.Repositories;

public class UsuarioRepository : IUsuarioRepository
{
    public Task<Usuario> AddAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> DeleteAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<List<Usuario>> GetAllAsync()
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> GetByIdAsync(Guid id)
    {
        throw new NotImplementedException();
    }

    public Task<Usuario> UpdateAsync(Usuario usuario)
    {
        throw new NotImplementedException();
    }
}
