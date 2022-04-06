using ControleDeContatos.Models;
using Microsoft.EntityFrameworkCore;
using SiteEmMVC.Models;
using System;
using System.Collections.Generic;
using System.Linq;



namespace SiteEmMVC.Data
{
    public class BancoContext : DbContext
    {
        public BancoContext(DbContextOptions<BancoContext> options) : base(options)
        {
        }
        public DbSet<ContatoModel> Contatos { get; set; }
        public DbSet<UsuarioModel> Usuario { get; set; }
    }
}
