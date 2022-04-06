using SiteEmMVC.Data;
using SiteEmMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;
namespace SiteEmMVC.Repositorios
{
    public class UsuarioRepositorio : IUsuarioRepositorio
    {
        private readonly BancoContext _bancoContext;
        public UsuarioRepositorio(BancoContext bancoContext)
        {
            _bancoContext = bancoContext;
        }
        public UsuarioModel BuscarPorLogin(string login)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Login.ToUpper() == login.ToUpper());
        }


        public UsuarioModel BuscarPorID(int id)
        {
            return _bancoContext.Usuario.FirstOrDefault(x => x.Id == id);

        }


        public List<UsuarioModel> BuscarTodos()
        {
            return _bancoContext.Usuario.ToList();
        }

        public UsuarioModel Adicionar(UsuarioModel usuario)
        // Gravando no Banco de dados
        {
            usuario.DataCadastro = DateTime.Now;
            _bancoContext.Usuario.Add(usuario);
            _bancoContext.SaveChanges();
            return usuario;
        }

        public UsuarioModel Atualizar(UsuarioModel usuario)
        {
            UsuarioModel usuarioDB = BuscarPorID(usuario.Id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na Atualização do Usuário");
            usuarioDB.Nome = usuario.Nome;
            usuarioDB.Email = usuario.Email;
            usuarioDB.Login = usuario.Login;
            usuarioDB.DataAtualizacao = DateTime.Now;
            usuarioDB.Perfil = usuario.Perfil;

            _bancoContext.Usuario.Update(usuarioDB);
            _bancoContext.SaveChanges();

            return usuarioDB;

        }

        public bool Apagar(int id)
        {
            UsuarioModel usuarioDB = BuscarPorID(id);

            if (usuarioDB == null) throw new System.Exception("Houve um erro na Deleção do Usuário");

            _bancoContext.Usuario.Remove(usuarioDB);
            _bancoContext.SaveChanges();


            return true;

        }

       
    }
}
