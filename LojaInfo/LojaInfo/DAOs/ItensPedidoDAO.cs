using LojaInfo.Models;
using LojaInfo.Repositorio;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.DAOs
{
    public class ItensPedidoDAO
    {
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os itens já cadastrados no banco de dados
        public List<ItensPedido> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from vw_carrinho ", cn.MyConectarBD());
            var listaitens = new List<ItensPedido>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                ItensPedido tempItem = new ItensPedido();

                tempItem.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempItem.CodProd = Convert.ToInt32(leitor["CodProd"]);
                tempItem.NomeProd = Convert.ToString(leitor["NomeProd"]);
                tempItem.LinkImg = Convert.ToString(leitor["LinkImg"]);
                tempItem.Qtitem = Convert.ToInt32(leitor["Qtitem"]);
                tempItem.ValorItem = Convert.ToDouble(leitor["ValorItem"]);

                listaitens.Add(tempItem);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaitens;
        }

        //Método para listar os itens de determinado pedido já cadastrados no banco de dados
        public List<ItensPedido> listarPorCodPed(int CodPed)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from vw_carrinho " +
                "where CodPed=@CodPed", cn.MyConectarBD());
            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = CodPed;

            var listaitens = new List<ItensPedido>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                ItensPedido tempItem = new ItensPedido();

                tempItem.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempItem.CodProd = Convert.ToInt32(leitor["CodProd"]);
                tempItem.NomeProd = Convert.ToString(leitor["NomeProd"]);
                tempItem.LinkImg = Convert.ToString(leitor["LinkImg"]);
                tempItem.Qtitem = Convert.ToInt32(leitor["Qtitem"]);
                tempItem.ValorItem = Convert.ToDouble(leitor["ValorItem"]);

                listaitens.Add(tempItem);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaitens;
        }

        //Método para listar um determinado item já cadastrados no banco de dados
        public ItensPedido listarPorCd(int CodPed, int CodProd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from vw_carrinho " +
                "where CodPed=@CodPed and CodProd=@CodProd", cn.MyConectarBD());
            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = CodPed;
            cmd.Parameters.Add("@CodProd", MySqlDbType.VarChar).Value = CodProd;
            var listaitens = new List<ItensPedido>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                ItensPedido tempItem = new ItensPedido();

                tempItem.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempItem.CodProd = Convert.ToInt32(leitor["CodProd"]);
                tempItem.NomeProd = Convert.ToString(leitor["NomeProd"]);
                tempItem.LinkImg = Convert.ToString(leitor["LinkImg"]);
                tempItem.Qtitem = Convert.ToInt32(leitor["Qtitem"]);
                tempItem.ValorItem = Convert.ToDouble(leitor["ValorItem"]);

                listaitens.Add(tempItem);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            //Retornando apenas o primeiro item da lista ou valor nulo
            return listaitens.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(ItensPedido item)
        {
            //Gerando o valor do item a partir do valor do produto
            ProdutoDAO prodDAO = new ProdutoDAO();
            Produto prod = prodDAO.listarPorCd(item.CodPed);
            item.ValorItem = prod.ValorUnitario * item.Qtitem;

            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbItensPedido(CodPed,CodProd,Qtitem,ValorItem) " +
                "values(@CodPed,@CodProd,@Qtitem,@ValorItem)", cn.MyConectarBD());

            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = item.CodPed;
            cmd.Parameters.Add("@CodProd", MySqlDbType.VarChar).Value = item.CodProd;
            cmd.Parameters.Add("@Qtitem", MySqlDbType.VarChar).Value = item.Qtitem;
            cmd.Parameters.Add("@ValorItem", MySqlDbType.VarChar).Value = item.ValorItem;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

            //Atualizando o valor do pedido
            PedidoDAO pedDAO = new PedidoDAO();
            pedDAO.updateValor(item.CodPed);
        }

        //Método para alterar registro existente no banco
        public void update(ItensPedido item)
        {
            //Gerando o valor do item a partir do valor do produto
            ProdutoDAO prodDAO = new ProdutoDAO();
            Produto prod = prodDAO.listarPorCd(item.CodPed);
            item.ValorItem = prod.ValorUnitario * item.Qtitem;

            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbItensPedido set " +
                "Qtitem = @Qtitem," +
                "ValorItem = @ValorItem " +
                "where CodPed = @CodPed " +
                "and CodProd=@CodProd", cn.MyConectarBD());

            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = item.CodPed;
            cmd.Parameters.Add("@CodProd", MySqlDbType.VarChar).Value = item.CodProd;
            cmd.Parameters.Add("@Qtitem", MySqlDbType.VarChar).Value = item.Qtitem;
            cmd.Parameters.Add("@ValorItem", MySqlDbType.VarChar).Value = item.ValorItem;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

            //Atualizando o valor do pedido
            PedidoDAO pedDAO = new PedidoDAO();
            pedDAO.updateValor(item.CodPed);
        }

        //Método para deletar um registro do banco
        public void delete(int CodPed, int CodProd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbItensPedido " +
                "where CodPed=@CodPed and CodProd=@CodProd", cn.MyConectarBD());
            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = CodPed;
            cmd.Parameters.Add("@CodProd", MySqlDbType.VarChar).Value = CodProd;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

            //Atualizando o valor do pedido
            PedidoDAO pedDAO = new PedidoDAO();
            pedDAO.updateValor(CodPed);
        }
    }
}
