using ControleDeContatos.Models;
using SiteEmMVC.Models;
using System.Collections.Generic;

namespace SiteEmMVC.Repositorios
{
    public interface IUsuarioRepositorio
    {
        UsuarioModel BuscarPorLogin(string login);
        UsuarioModel BuscarPorID(int id);
        List<UsuarioModel> BuscarTodos();
        UsuarioModel Adicionar(UsuarioModel usuario);
        UsuarioModel Atualizar(UsuarioModel usuario);

        bool Apagar(int id);
        
    }
}
