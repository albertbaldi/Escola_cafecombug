using System;
using Escola.Application.DTOs.Curso;
using Escola.Application.DTOs.Matricula;
using Escola.Application.DTOs.Turma;
using Escola.Application.DTOs.Usuario;
using Escola.Application.Exceptions;
using Escola.Application.Interfaces;
using Escola.Domain.Entities;
using Escola.Domain.Interfaces;

namespace Escola.Application.Services;

public class MatriculaService : IMatriculaService
{
    private readonly IMatriculaRepository _matriculaRepository;
    private readonly IUsuarioRepository _usuarioRepository;
    private readonly ITurmaRepository _turmaRepository;
    public MatriculaService(IMatriculaRepository matriculaRepository, IUsuarioRepository usuarioRepository, ITurmaRepository turmaRepository)
    {
        _matriculaRepository = matriculaRepository;
        _usuarioRepository = usuarioRepository;
        _turmaRepository = turmaRepository;
    }

    public async Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO)
    {
        var usuario = await _usuarioRepository.GetByIdAsync(matriculaPostDTO.UsuarioId);
        if (usuario == null)
            throw new NotFoundException("Usuário não encontrado.");
        var turma = await _turmaRepository.GetByIdAsync(matriculaPostDTO.TurmaId);
        if (turma == null)
            throw new NotFoundException("Turma não encontrada.");

        var matricula = new Matricula
        {
            UsuarioId = matriculaPostDTO.UsuarioId,
            TurmaId = matriculaPostDTO.TurmaId,
            DataExpiracao = matriculaPostDTO.DataExpiracao,
            DataMatricula = DateTime.UtcNow,
            Ativa = true
        };

        var createdMatricula = await _matriculaRepository.AddAsync(matricula);

        return new MatriculaGetDTO
        {
            Id = createdMatricula.Id,
            UsuarioId = createdMatricula.UsuarioId,
            TurmaId = createdMatricula.TurmaId,
            DataExpiracao = createdMatricula.DataExpiracao,
            DataMatricula = createdMatricula.DataMatricula,
            Ativa = createdMatricula.Ativa
        };
    }

    public async Task<MatriculaGetDTO> DeleteAsync(int id)
    {
        var matricula = await _matriculaRepository.DeleteAsync(id);
        if (matricula == null)
            throw new NotFoundException("Matrícula não encontrada.");

        return new MatriculaGetDTO
        {
            Id = matricula.Id,
            UsuarioId = matricula.UsuarioId,
            TurmaId = matricula.TurmaId,
            DataExpiracao = matricula.DataExpiracao,
            DataMatricula = matricula.DataMatricula,
            Ativa = matricula.Ativa
        };
    }

    public async Task<List<MatriculaGetDetailDTO>> GetAllAsync()
    {
        var matriculas = await _matriculaRepository.GetAllAsync();

        return matriculas.Select(m => new MatriculaGetDetailDTO
        {
            Id = m.Id,
            Usuario = new UsuarioGetDTO
            {
                Id = m.Usuario.Id,
                Nome = m.Usuario.Nome,
                Email = m.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = m.Turma.Id,
                Nome = m.Turma.Nome,
                Descricao = m.Turma.Descricao
            },
            DataMatricula = m.DataMatricula,
            DataExpiracao = m.DataExpiracao,
            Ativa = m.Ativa
        }).ToList();
    }

    public async Task<MatriculaGetDetailDTO> GetByIdAsync(int id)
    {
        var matricula = await _matriculaRepository.GetByIdAsync(id);

        if (matricula == null)
            throw new NotFoundException("Matrícula não encontrada.");

        return new MatriculaGetDetailDTO
        {
            Id = matricula.Id,
            Usuario = new UsuarioGetDTO
            {
                Id = matricula.Usuario.Id,
                Nome = matricula.Usuario.Nome,
                Email = matricula.Usuario.Email
            },
            Turma = new TurmaGetDTO
            {
                Id = matricula.Turma.Id,
                Nome = matricula.Turma.Nome,
                Descricao = matricula.Turma.Descricao
            },
            DataMatricula = matricula.DataMatricula,
            DataExpiracao = matricula.DataExpiracao,
            Ativa = matricula.Ativa
        };
    }

    public async Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO)
    {
        var matricula = await _matriculaRepository.GetByIdAsync(matriculaPutDTO.Id);
        if (matricula == null)
            throw new NotFoundException("Matrícula não encontrada.");

        var turma = await _turmaRepository.GetByIdAsync(matriculaPutDTO.TurmaId);
        if (turma == null)
            throw new NotFoundException("Turma não encontrada.");

        matricula.TurmaId = matriculaPutDTO.TurmaId;
        matricula.DataExpiracao = matriculaPutDTO.DataExpiracao;

        var updatedMatricula = await _matriculaRepository.UpdateAsync(matricula);

        if (updatedMatricula == null)
            throw new NotFoundException("Matrícula não encontrada.");

        return new MatriculaGetDTO
        {
            Id = updatedMatricula.Id,
            UsuarioId = updatedMatricula.UsuarioId,
            TurmaId = updatedMatricula.TurmaId,
            DataExpiracao = updatedMatricula.DataExpiracao,
            DataMatricula = updatedMatricula.DataMatricula,
            Ativa = updatedMatricula.Ativa
        };
    }
}
