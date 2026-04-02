using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Curso;

public class CursoPostDTO
{
    [Required(ErrorMessage = "O nome do curso é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome do curso deve conter no máximo 50 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
    [MaxLength(150, ErrorMessage = "A descrição do curso deve conter no máximo 150 caracteres.")]
    public string Descricao { get; set; }
}
