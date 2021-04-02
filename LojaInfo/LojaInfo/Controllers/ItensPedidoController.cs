using LojaInfo.DAOs;
using LojaInfo.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace LojaInfo.Controllers
{
    public class ItensPedidoController : Controller
    {

        // Criando o objeto responsável por executar as ações no banco de dados
        ItensPedidoDAO ipDAO = new ItensPedidoDAO();
        ProdutoDAO prodDAO = new ProdutoDAO();

        // Action para listar todos os registros existentes
        public ActionResult Index(int CodPed)
        {
            ViewData["CodPed"] = CodPed;
            return View(ipDAO.listarPorCodPed(CodPed));
        }

        // Action para carregar a view para o cadastro de um novo registro
        public ActionResult Cadastrar(int CodPed)
        {
            ViewBag.prods = prodDAO.listar();
            ViewData["CodPed"] = CodPed;
            return View();
        }

        // Action para cadastrar o novo registro no banco de dados
        [HttpPost]
        public ActionResult Cadastrar(ItensPedido ip)
        {
            ipDAO.insert(ip);
            return RedirectToAction("Index", new { CodPed = ip.CodPed });
        }

        // Action para carregar a view para a alteração de um registro
        public ActionResult Alterar(int CodPed, int CodProd)
        {
            ViewBag.prods = prodDAO.listar();
            return View(ipDAO.listarPorCd(CodPed, CodProd));
        }

        // Action para executar a alteração do registro no banco de dados
        [HttpPost]
        public ActionResult Alterar(ItensPedido ip)
        {
            ipDAO.update(ip);
            return RedirectToAction("Index", new { CodPed = ip.CodPed });
        }

        // Action para carregar a view para o usuario confirmar a exclusão de um registro
        public ActionResult Deletar(int CodPed, int CodProd)
        {
            return View(ipDAO.listarPorCd(CodPed, CodProd));
        }

        // Action para excluir o registro do banco de dados
        [HttpPost]
        public ActionResult Deletar(int CodPed, int CodProd, ItensPedido ip)
        {
            ipDAO.delete(CodPed, CodProd);
            return RedirectToAction("Index", new { CodPed = ip.CodPed });
        }
    }
}