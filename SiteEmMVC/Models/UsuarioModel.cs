using SiteEmMVC.Enum;
using System.ComponentModel.DataAnnotations;

namespace SiteEmMVC.Models
{
    public class UsuarioModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Digite o nome do usuário")]
        public string Nome { get; set; }

        [Required(ErrorMessage = "Digite o login do usuário")]
        public string Login { get; set; }

        [Required(ErrorMessage = "Digite o email do usuário")]
        [EmailAddress(ErrorMessage = "O email informado não é válido!")]
        public string Email { get; set; }

        [Required(ErrorMessage = "Informe o Perfil do usuário")]
        public PerfilEnum Perfil { get; set; }

        [Required(ErrorMessage = "Digite a senha do usuário")]
        public string Senha { get; set; }
        public DateTime DataCadastro{ get; set; }
        public DateTime? DataAtualizacao{ get; set; }

        public bool SenhaValida(string senha)
        {
            return Senha == senha;
        }


    }
}
