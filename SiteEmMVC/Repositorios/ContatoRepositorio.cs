using ControleDeContatos.Models;
using SiteEmMVC.Data;
using SiteEmMVC.Models;

namespace SiteEmMVC.Repositorios
{
    public class ContatoRepositorio : IContatoRepositorio
    {
        private readonly BancoContext _bancoContext;
        public ContatoRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }

        public ContatoModel ListarID(int id)
        {
            return _bancoContext.Contatos.FirstOrDefault(x => x.Id == id);

        }
         

        public List<ContatoModel> BuscarTodos()
        {
            return _bancoContext.Contatos.ToList();
        }

        public ContatoModel Adicionar(ContatoModel contato)
        // Gravando no Banco de dados
        {
            _bancoContext.Contatos.Add(contato);
            _bancoContext.SaveChanges();
            return contato;
        }

        public ContatoModel Atualizar(ContatoModel contato)
        {
            ContatoModel contatoDB = ListarID(contato.Id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na Atualização do contato");
            contatoDB.Nome = contato.Nome;
            contatoDB.Email = contato.Email;
            contatoDB.Celular = contato.Celular;    

            _bancoContext.Contatos.Update(contatoDB);
            _bancoContext.SaveChanges();

            return contatoDB;
                
        }

        public bool Apagar(int id)
        {
            ContatoModel contatoDB = ListarID(id);

            if (contatoDB == null) throw new System.Exception("Houve um erro na Deleção do contato");
            
            _bancoContext.Contatos.Remove(contatoDB);
            _bancoContext.SaveChanges();

            return true;
    
        }
    }
}
