using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Matricula;

public class MatriculaPutDTO
{
    [Required(ErrorMessage = "O Identificador da matrícula é obrigatório.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O Identificador da turma é obrigatório.")]
    public int TurmaId { get; set; }
    [Required(ErrorMessage = "A data de expiração da matrícula é obrigatória.")]
    public DateTime DataExpiracao { get; set; }
}
