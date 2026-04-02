using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Turma;

public class TurmaPostDTO
{
    [Required(ErrorMessage = "O Identificador do curso é obrigatório.")]
    public int CursoId { get; set; }
    [Required(ErrorMessage = "O nome da turma é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome da turma deve conter no máximo 50 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descrição da turma é obrigatória.")]
    [MaxLength(150, ErrorMessage = "A descrição da turma deve conter no máximo 150 caracteres.")]
    public string Descricao { get; set; }
}
