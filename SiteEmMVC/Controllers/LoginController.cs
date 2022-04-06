using Microsoft.AspNetCore.Mvc;
using SiteEmMVC.Models;
using SiteEmMVC.Repositorios;

namespace SiteEmMVC.Controllers
{
    public class LoginController : Controller
    {
        private readonly IUsuarioRepositorio _usuarioRepostorio;
        public LoginController(IUsuarioRepositorio usuarioRepostorio)
        {
            _usuarioRepostorio = usuarioRepostorio;
        }
        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]

        public IActionResult Entrar(LoginModel loginModel)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    UsuarioModel usuario = _usuarioRepostorio.BuscarPorLogin(loginModel.Login);


                    if (usuario != null)
                    {
                        if (usuario.SenhaValida(loginModel.Senha))
                        {
                            return RedirectToAction("Index", "Home");
                        }

                        TempData["MensagemErro"] = $"A senha do usuário é inválida, tente novamente";

                    }

                    TempData["MensagemErro"] = $"Usuário e/ou senha invalido(s).Por Favor, tente novamente.";
                } 

                return View("Index");
            }
            catch (Exception erro)
            {
                TempData["MensagemErro"] = $"Ops, não conseguimos realizar o seu login, tente novamente, detalhe do erro:{erro.Message} !";
                return RedirectToAction("Index");
            }
        }


    }
}
