using System;
using System.ComponentModel.DataAnnotations;

namespace Escola.Application.DTOs.Usuario;

public class UsuarioPostDTO
{
    [Required(ErrorMessage = "O nome do usuário é obrigatório.")]
    [MaxLength(250, ErrorMessage = "O nome do usuário deve conter no máximo 250 caracteres.")]
    public string Nome { get; set; }
    [Required(ErrorMessage = "O email do usuário é obrigatório.")]
    [EmailAddress(ErrorMessage = "O email do usuário deve ser um endereço de email válido.")]
    [MaxLength(200, ErrorMessage = "O email do usuário deve conter no máximo 200 caracteres.")]
    public string Email { get; set; }
    [Required(ErrorMessage = "A senha do usuário é obrigatória.")]
    [MinLength(8, ErrorMessage = "A senha do usuário deve conter no mínimo 8 caracteres.")]
    [MaxLength(250, ErrorMessage = "A senha do usuário deve conter no máximo 250 caracteres.")]
    public string Senha { get; set; }
}
