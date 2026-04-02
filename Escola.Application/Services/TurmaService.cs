using System;
using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class TurmaService : ITurmaService
{
    private readonly ITurmaRepository _turmaRepository;
    public TurmaService(ITurmaRepository turmaRepository)
    {
        _turmaRepository = turmaRepository;
    }

    public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO)
    {
        var turma = new Turma
        {
            CursoId = turmaPostDTO.CursoId,
            Nome = turmaPostDTO.Nome,
            Descricao = turmaPostDTO.Descricao
        };

        await _turmaRepository.AddAsync(turma);

        return new TurmaGetDTO
        {
            Id = turma.Id,
            CursoId = turma.CursoId,
            Nome = turma.Nome,
            Descricao = turma.Descricao
        };
    }

    public async Task<TurmaGetDTO> DeleteAsync(int id)
    {
        var deletedTurma = await _turmaRepository.DeleteAsync(id);

        if (deletedTurma == null)
            return null;

        return new TurmaGetDTO
        {
            Id = deletedTurma.Id,
            CursoId = deletedTurma.CursoId,
            Nome = deletedTurma.Nome,
            Descricao = deletedTurma.Descricao
        };
    }

    public async Task<List<TurmaGetDetailDTO>> GetAllAsync()
    {
        var turmas = await _turmaRepository.GetAllAsync();

        return turmas.Select(t => new TurmaGetDetailDTO
        {
            Id = t.Id,
            Curso = new CursoGetDTO
            {
                Id = t.Curso.Id,
                Nome = t.Curso.Nome,
                Descricao = t.Curso.Descricao
            },
            Nome = t.Nome,
            Descricao = t.Descricao
        }).ToList();
    }

    public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
    {
        var turma = await _turmaRepository.GetByIdAsync(id);

        if (turma == null)
            return null;

        return new TurmaGetDetailDTO
        {
            Id = turma.Id,
            Curso = new CursoGetDTO
            {
                Id = turma.Curso.Id,
                Nome = turma.Curso.Nome,
                Descricao = turma.Curso.Descricao
            },
            Nome = turma.Nome,
            Descricao = turma.Descricao
        };
    }

    public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO)
    {
        var turma = new Turma
        {
            Id = turmaPutDTO.Id,
            CursoId = turmaPutDTO.CursoId,
            Nome = turmaPutDTO.Nome,
            Descricao = turmaPutDTO.Descricao
        };

        var updatedTurma = await _turmaRepository.UpdateAsync(turma);

        if (updatedTurma == null)
            return null;

        return new TurmaGetDTO
        {
            Id = updatedTurma.Id,
            CursoId = updatedTurma.CursoId,
            Nome = updatedTurma.Nome,
            Descricao = updatedTurma.Descricao
        };
    }
}
