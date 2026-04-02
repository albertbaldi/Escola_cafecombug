using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Matricula;

public class MatriculaPostDTO
{
    [Required(ErrorMessage = "O Identificador do usuário é obrigatório.")]
    public int UsuarioId { get; set; }
    [Required(ErrorMessage = "O Identificador da turma é obrigatório.")]
    public int TurmaId { get; set; }
    [Required(ErrorMessage = "A data de expiração da matrícula é obrigatória.")]
    public DateTime DataExpiracao { get; set; }

}
