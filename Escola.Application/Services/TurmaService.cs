using System;
using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Turma;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Application.Exceptions;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class TurmaService : ITurmaService
{
    private readonly ITurmaRepository _turmaRepository;
    private readonly ICursoRepository _cursoRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    public TurmaService(ITurmaRepository turmaRepository, ICursoRepository cursoRepository, IUsuarioRepository usuarioRepository)
    {
        _turmaRepository = turmaRepository;
        _cursoRepository = cursoRepository;
        _usuarioRepository = usuarioRepository;
    }

    public async Task<TurmaGetDTO> AddAsync(TurmaPostDTO turmaPostDTO)
    {
        var curso = await _cursoRepository.GetByIdAsync(turmaPostDTO.CursoId);
        if (curso == null)
            throw new NotFoundException("Curso não encontrado.");

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
            throw new NotFoundException("Turma não encontrada.");

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
            Nome = t.Nome,
            Descricao = t.Descricao,
            Curso = new CursoGetDTO
            {
                Id = t.Curso.Id,
                Nome = t.Curso.Nome,
                Descricao = t.Curso.Descricao
            },
        }).ToList();
    }

    public async Task<TurmaGetDetailDTO> GetByIdAsync(int id)
    {
        var turma = await _turmaRepository.GetByIdAsync(id);

        if (turma == null)
            throw new NotFoundException("Turma não encontrada.");

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

    public async Task<List<TurmaGetDetailDTO>> GetTurmasByUsuario(int idUsuario)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(idUsuario);
        if (usuario == null)
            throw new NotFoundException("Usuário não encontrado.");

        var turmas = await _turmaRepository.GetTurmasByUsuario(idUsuario);
        return turmas.Select(t => new TurmaGetDetailDTO
        {
            Id = t.Id,
            Nome = t.Nome,
            Descricao = t.Descricao,
            Curso = new CursoGetDTO
            {
                Id = t.Curso.Id,
                Nome = t.Curso.Nome,
                Descricao = t.Curso.Descricao
            }
        }).ToList();
    }

    public async Task<TurmaGetDTO> UpdateAsync(TurmaPutDTO turmaPutDTO)
    {
        var turma = await _turmaRepository.GetByIdAsync(turmaPutDTO.Id);
        if (turma == null)
            throw new NotFoundException("Turma não encontrada.");

        if (turmaPutDTO.CursoId != turma.CursoId)
        {
            if (await _cursoRepository.GetByIdAsync(turmaPutDTO.CursoId) == null)
                throw new NotFoundException("Curso não encontrado.");
        }

        turma.Id = turmaPutDTO.Id;
        turma.CursoId = turmaPutDTO.CursoId;
        turma.Nome = turmaPutDTO.Nome;
        turma.Descricao = turmaPutDTO.Descricao;

        var updatedTurma = await _turmaRepository.UpdateAsync(turma);

        if (updatedTurma == null)
            throw new NotFoundException("Turma não encontrada.");

        return new TurmaGetDTO
        {
            Id = updatedTurma.Id,
            CursoId = updatedTurma.CursoId,
            Nome = updatedTurma.Nome,
            Descricao = updatedTurma.Descricao
        };
    }
}
