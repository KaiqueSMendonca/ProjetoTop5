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
    public class PedidoDAO
    {
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os pedidos já cadastrados no banco de dados
        public List<Pedido> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbPedido ", cn.MyConectarBD());
            var lestaPed = new List<Pedido>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Pedido tempPed = new Pedido();

                tempPed.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempPed.CodFunc = Convert.ToInt32(leitor["CodFunc"]);
                tempPed.CodCli = Convert.ToInt32(leitor["CodCli"]);
                tempPed.DataPed = Convert.ToDateTime(leitor["DataPed"]);
                tempPed.ValorPed = Convert.ToDouble(leitor["ValorPed"]);

                lestaPed.Add(tempPed);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return lestaPed;
        }

        //Método para listar determinado pedido já cadastrados no banco de dados
        public Pedido listarPorCd(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbPedido " +
                "where CodPed=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var lestaPed = new List<Pedido>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Pedido tempPed = new Pedido();

                tempPed.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempPed.CodFunc = Convert.ToInt32(leitor["CodFunc"]);
                tempPed.CodCli = Convert.ToInt32(leitor["CodCli"]);
                tempPed.DataPed = Convert.ToDateTime(leitor["DataPed"]);
                tempPed.ValorPed = Convert.ToDouble(leitor["ValorPed"]);

                lestaPed.Add(tempPed);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            //Retornando apenas o primeiro item da lista ou valor nulo
            return lestaPed.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(Pedido ped)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbPedido(CodFunc,CodCli,DataPed,ValorPed) " +
                "values(@CodFunc,@CodCli,@DataPed,0)", cn.MyConectarBD());

            cmd.Parameters.Add("@CodFunc", MySqlDbType.VarChar).Value = ped.CodFunc;
            cmd.Parameters.Add("@CodCli", MySqlDbType.VarChar).Value = ped.CodCli;
            cmd.Parameters.Add("@DataPed", MySqlDbType.VarChar).Value = ped.DataPed;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para alterar registro existente no banco
        public void update(Pedido ped)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbPedido set " +
                "CodFunc = @CodFunc," +
                "CodCli = @CodCli," +
                "DataPed = @DataPed " +
                "where CodPed = @CodPed", cn.MyConectarBD());


            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = ped.CodPed;
            cmd.Parameters.Add("@CodFunc", MySqlDbType.VarChar).Value = ped.CodFunc;
            cmd.Parameters.Add("@CodCli", MySqlDbType.VarChar).Value = ped.CodCli;
            cmd.Parameters.Add("@DataPed", MySqlDbType.VarChar).Value = ped.DataPed;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();

            //Atualizando o valor do pedido
            updateValor(ped.CodPed);
        }


        public void delete(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbPedido " +
                "where CodPed=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //método para atualizar apenas o valor do pedido
        public void updateValor(int cd)
        {
            //Somando os valores de todos os itens do pedido
            ItensPedidoDAO ipDAO = new ItensPedidoDAO();
            double valor = 0;
            var listaItens = ipDAO.listarPorCodPed(cd);
            foreach(ItensPedido item in listaItens)
            {
                valor += item.ValorItem;
            }

            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbPedido set " +
                "ValorPed = @ValorPed " +
                "where CodPed = @CodPed", cn.MyConectarBD());

            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = cd;
            cmd.Parameters.Add("@ValorPed", MySqlDbType.VarChar).Value = valor;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
