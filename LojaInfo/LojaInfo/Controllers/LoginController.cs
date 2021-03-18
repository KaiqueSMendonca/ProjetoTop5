using LojaInfo.Models;
using LojaInfo.Repositorio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace LojaInfo.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login

        // instanciando classe acoes / acoes uma classe do reposotorio para tratar as informações do banco(crud)
        Acoes acoes = new Acoes();


        // Criando a estrutura da página login
        public ActionResult Login()
        {
            return View();
        }
        // crianod o método http para verificar se o usuario e senha estão no banco 

        [HttpPost]
        public ActionResult VerificarUser(Usuario user)
        {
            // metodo que testa o usuario no banco
            acoes.TestarUsuario(user);

            if (user.nome_usuario != null && user.senha_usuario != null)
            {
                // criado um metodo de criptografia apra verificar um objeto(nome e senha) e depois criada a sessão para validação.
                FormsAuthentication.SetAuthCookie(user.nome_usuario, false);
                Session["usuarioLogado"] = user.nome_usuario.ToString();
                Session["senhaLogado"] = user.senha_usuario.ToString();

                // se o usuario e senha estiver corretos a pagina é direcionada para a página principal
                return RedirectToAction("Index", "Home");
            }
            else
            {    // caso o usuario e senha forem invalidos voltar para a tela login novamente.
                return RedirectToAction("Login", "Login");
            }
        }
        //realizando o logout da página e pegando o usuario logado
        public ActionResult Logout()
        {
            Session["usuarioLogado"] = null;
            return RedirectToAction("Login", "Login");
        }
        
    }
}