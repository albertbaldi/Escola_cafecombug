using System;
using Escola.Application.DTOs.Nota;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class NotaService : INotaService
{
    private readonly INotaRepository _notaRepository;

    public NotaService(INotaRepository notaRepository)
    {
        _notaRepository = notaRepository;
    }

    public async Task<NotaGetDTO> AddAsync(NotaPostDTO notaPostDTO)
    {
        var nota = new Nota
        {
            MatriculaId = notaPostDTO.MatriculaId,
            ValorNota = notaPostDTO.ValorNota,
            DataNota = DateTime.UtcNow,
            Aprovado = notaPostDTO.ValorNota >= 60
        };

        var createdNota = await _notaRepository.AddAsync(nota);

        return new NotaGetDTO
        {
            Id = createdNota.Id,
            MatriculaId = createdNota.MatriculaId,
            ValorNota = createdNota.ValorNota,
            DataNota = createdNota.DataNota,
            Aprovado = createdNota.Aprovado
        };
    }

    public async Task<NotaGetDTO> DeleteAsync(int id)
    {
        var nota = await _notaRepository.GetByIdAsync(id);
        if (nota == null)
            return null;

        nota.Excluido = true;
        await _notaRepository.UpdateAsync(nota);

        return new NotaGetDTO
        {
            Id = nota.Id,
            MatriculaId = nota.MatriculaId,
            ValorNota = nota.ValorNota,
            DataNota = nota.DataNota,
            Aprovado = nota.Aprovado
        };
    }

    public async Task<List<NotaGetDTO>> GetAllAsync()
    {
        var notas = await _notaRepository.GetAllAsync();

        return notas.Select(n => new NotaGetDTO
        {
            Id = n.Id,
            MatriculaId = n.MatriculaId,
            ValorNota = n.ValorNota,
            DataNota = n.DataNota,
            Aprovado = n.Aprovado
        }).ToList();
    }

    public async Task<NotaGetDTO> GetByIdAsync(int id)
    {
        var nota = await _notaRepository.GetByIdAsync(id);

        if (nota == null)
            return null;

        return new NotaGetDTO
        {
            Id = nota.Id,
            MatriculaId = nota.MatriculaId,
            ValorNota = nota.ValorNota,
            DataNota = nota.DataNota,
            Aprovado = nota.Aprovado
        };
    }

    public async Task<NotaGetDTO> UpdateAsync(NotaPutDTO notaPutDTO)
    {
        var existingNota = await _notaRepository.GetByIdAsync(notaPutDTO.Id);
        if (existingNota == null)
            return null;

        existingNota.ValorNota = notaPutDTO.ValorNota;
        existingNota.Aprovado = notaPutDTO.ValorNota >= 60;

        var updatedNota = await _notaRepository.UpdateAsync(existingNota);

        return new NotaGetDTO
        {
            Id = updatedNota.Id,
            MatriculaId = updatedNota.MatriculaId,
            ValorNota = updatedNota.ValorNota,
            DataNota = updatedNota.DataNota,
            Aprovado = updatedNota.Aprovado
        };
    }
}
