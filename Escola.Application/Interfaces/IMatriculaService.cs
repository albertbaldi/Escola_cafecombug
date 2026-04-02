using System;
using Escola.Application.DTOs.Matricula;

namespace Escola.Application.Interfaces;

public interface IMatriculaService
{
    Task<MatriculaGetDetailDTO> GetByIdAsync(int id);
    Task<List<MatriculaGetDetailDTO>> GetAllAsync();
    Task<MatriculaGetDTO> AddAsync(MatriculaPostDTO matriculaPostDTO);
    Task<MatriculaGetDTO> UpdateAsync(MatriculaPutDTO matriculaPutDTO);
    Task<MatriculaGetDTO> DeleteAsync(int id);
}
