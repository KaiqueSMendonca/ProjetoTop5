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
    public class VendaDAO
    {
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os itens já cadastrados no banco de dados
        public List<Venda> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbVenda ", cn.MyConectarBD());
            var listaVenda = new List<Venda>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Venda tempVend = new Venda();

                tempVend.CodVenda = Convert.ToInt32(leitor["CodVenda"]);
                tempVend.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempVend.Valor = Convert.ToDouble(leitor["Valor"]);
                tempVend.FormaPag = Convert.ToString(leitor["FormaPag"]);
                tempVend.DataEntrega = Convert.ToDateTime(leitor["DataEntrega"]);
                tempVend.EndEntrega = Convert.ToString(leitor["EndEntrega"]);

                listaVenda.Add(tempVend);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaVenda;
        }

        //Método para listar uma determinada venda já cadastrados no banco de dados
        public Venda listarPorCd(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbVenda " +
                "where CodVenda=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaVenda = new List<Venda>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Venda tempVend = new Venda();

                tempVend.CodVenda = Convert.ToInt32(leitor["CodVenda"]);
                tempVend.CodPed = Convert.ToInt32(leitor["CodPed"]);
                tempVend.Valor = Convert.ToDouble(leitor["Valor"]);
                tempVend.FormaPag = Convert.ToString(leitor["FormaPag"]);
                tempVend.DataEntrega = Convert.ToDateTime(leitor["DataEntrega"]);
                tempVend.EndEntrega = Convert.ToString(leitor["EndEntrega"]);

                listaVenda.Add(tempVend);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            //Retornando apenas o primeiro item da lista ou valor nulo
            return listaVenda.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(Venda venda)
        {
            //Gerando o valor da venda a partir do valor do pedido
            PedidoDAO pedDAO = new PedidoDAO();
            Pedido ped = pedDAO.listarPorCd(venda.CodPed);
            venda.Valor = ped.ValorPed;

            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbVenda(CodPed,Valor,FormaPag,DataEntrega,EndEntrega) " +
                "values(@CodPed,@Valor,@FormaPag,@DataEntrega,@EndEntrega)", cn.MyConectarBD());

            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = venda.CodPed;
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar).Value = venda.Valor;
            cmd.Parameters.Add("@FormaPag", MySqlDbType.VarChar).Value = venda.FormaPag;
            cmd.Parameters.Add("@DataEntrega", MySqlDbType.VarChar).Value = venda.DataEntrega;
            cmd.Parameters.Add("@EndEntrega", MySqlDbType.VarChar).Value = venda.EndEntrega;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para alterar registro existente no banco
        public void update(Venda venda)
        {
            //Gerando o valor da venda a partir do valor do 
            PedidoDAO pedDAO = new PedidoDAO();
            Pedido ped = pedDAO.listarPorCd(venda.CodPed);
            venda.Valor = ped.ValorPed;

            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbVenda set " +
                "CodPed = @CodPed," +
                "Valor = @Valor," +
                "FormaPag = @FormaPag," +
                "DataEntrega = @DataEntrega," +
                "EndEntrega = @EndEntrega " +
                "where CodVenda = @CodVenda", cn.MyConectarBD());

            cmd.Parameters.Add("@CodVenda", MySqlDbType.VarChar).Value = venda.CodVenda;
            cmd.Parameters.Add("@CodPed", MySqlDbType.VarChar).Value = venda.CodPed;
            cmd.Parameters.Add("@Valor", MySqlDbType.VarChar).Value = venda.Valor;
            cmd.Parameters.Add("@FormaPag", MySqlDbType.VarChar).Value = venda.FormaPag;
            cmd.Parameters.Add("@DataEntrega", MySqlDbType.VarChar).Value = venda.DataEntrega;
            cmd.Parameters.Add("@EndEntrega", MySqlDbType.VarChar).Value = venda.EndEntrega;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para deletar um registro do banco
        public void delete(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbVenda " +
                "where CodVenda=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
