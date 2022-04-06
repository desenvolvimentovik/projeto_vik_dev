using ControleDeContatos.Models;
using SiteEmMVC.Models;
using System.Collections.Generic;

namespace SiteEmMVC.Repositorios
{
    public interface IContatoRepositorio
    {
        ContatoModel ListarID(int id);
        List<ContatoModel> BuscarTodos();
        ContatoModel Adicionar(ContatoModel contato);
        ContatoModel Atualizar(ContatoModel contato);

        bool Apagar(int id);
    }
}
