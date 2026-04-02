using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Curso;

public class CursoPutDTO
{
    [Required(ErrorMessage = "O Identificador do curso é obrigatório.")]
    public int Id { get; set; }
    [Required(ErrorMessage = "O nome do curso é obrigatório.")]
    [MaxLength(50, ErrorMessage = "O nome do curso deve conter no máximo 50 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "A descrição do curso é obrigatória.")]
    [MaxLength(150, ErrorMessage = "A descrição do curso deve conter no máximo 150 caracteres.")]
    public string Descricao { get; set; }
}
