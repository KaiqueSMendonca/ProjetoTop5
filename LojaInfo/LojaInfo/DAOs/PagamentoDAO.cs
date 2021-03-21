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
    public class PagamentoDAO
    {
        Conexao cn = new Conexao();

        public List<Pagamento> listar()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbPagamento ", cn.MyConectarBD());
            var listaPag = new List<Pagamento>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Pagamento tempPag = new Pagamento();

                tempPag.CodPagto = Convert.ToInt32(leitor["CodPagto"]);
                tempPag.DescPgto = Convert.ToString(leitor["DescPgto"]);
                tempPag.Quantidade = Convert.ToInt32(leitor["Quantidade"]);
                tempPag.ValorTotal = Convert.ToDouble(leitor["ValorTotal"]);

                listaPag.Add(tempPag);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaPag;
        }

        public Pagamento listarPorCd(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbPagamento " +
                "where CodPagto=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaPag = new List<Pagamento>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Pagamento tempPag = new Pagamento();

                tempPag.CodPagto = Convert.ToInt32(leitor["CodPagto"]);
                tempPag.DescPgto = Convert.ToString(leitor["DescPgto"]);
                tempPag.Quantidade = Convert.ToInt32(leitor["Quantidade"]);
                tempPag.ValorTotal = Convert.ToDouble(leitor["ValorTotal"]);

                listaPag.Add(tempPag);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaPag.FirstOrDefault();
        }

        public void insert(Pagamento pag)
        {
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbPagamento(DescPgto,Quantidade,ValorTotal) " +
                "values(@DescPgto,@NomeProd,@ValorTotal)", cn.MyConectarBD());

            cmd.Parameters.Add("@DescPgto", MySqlDbType.VarChar).Value = pag.DescPgto;
            cmd.Parameters.Add("@Quantidade", MySqlDbType.VarChar).Value = pag.Quantidade;
            cmd.Parameters.Add("@ValorTotal", MySqlDbType.VarChar).Value = pag.ValorTotal;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        public void update(Pagamento prod)
        {
            MySqlCommand cmd = new MySqlCommand("update tbPagamento set " +
                "DescPgto = @DescPgto," +
                "Quantidade = @Quantidade," +
                "ValorTotal = @ValorTotal," +
                "where CodPagto = @CodPagto", cn.MyConectarBD());

            cmd.Parameters.Add("@CodPagto", MySqlDbType.VarChar).Value = prod.CodPagto;
            cmd.Parameters.Add("@DescPgto", MySqlDbType.VarChar).Value = prod.DescPgto;
            cmd.Parameters.Add("@Quantidade", MySqlDbType.VarChar).Value = prod.Quantidade;
            cmd.Parameters.Add("@ValorTotal", MySqlDbType.VarChar).Value = prod.ValorTotal;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }


        public void delete(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Delete from tbPagamento " +
                "where CodPagto=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
