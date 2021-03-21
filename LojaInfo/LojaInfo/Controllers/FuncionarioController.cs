using LojaInfo.DAOs;
using LojaInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInfo.Controllers
{
    public class FuncionarioController : Controller
    {
        // Criando o objeto responsável por executar as ações no banco de dados
        FuncionarioDAO funcDAO = new FuncionarioDAO();

        // Action para listar todos os registros existentes
        public ActionResult Index()
        {
            return View(funcDAO.listar());
        }

        // Action para carregar a view para o cadastro de um novo registro
        public ActionResult Cadastrar()
        {
            return View();
        }

        // Action para cadastrar o novo registro no banco de dados
        [HttpPost]
        public ActionResult Cadastrar(Funcionario func)
        {
            funcDAO.insert(func);
            return RedirectToAction("Index");
        }

        // Action para carregar a view para a alteração de um registro
        public ActionResult Alterar(int cd)
        {
            return View(funcDAO.listarPorCd(cd));
        }

        // Action para executar a alteração do registro no banco de dados
        [HttpPost]
        public ActionResult Alterar(Funcionario func)
        {
            funcDAO.update(func);
            return RedirectToAction("Index");
        }

        // Action para carregar a view para o usuario confirmar a exclusão de um registro
        public ActionResult Deletar(int cd)
        {
            return View(funcDAO.listarPorCd(cd));
        }

        // Action para excluir o registro do banco de dados
        [HttpPost]
        public ActionResult Deletar(int cd, Funcionario func)
        {
            funcDAO.delete(cd);
            return RedirectToAction("Index");
        }
    }
}