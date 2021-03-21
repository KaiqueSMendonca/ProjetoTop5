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
    public class ClienteDAO
    {
        Conexao cn = new Conexao();

        public List<Cliente> listar()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbCliente ", cn.MyConectarBD());
            var listaCli = new List<Cliente>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Cliente tempCli = new Cliente();

                tempCli.CodCli = Convert.ToInt32(leitor["CodCli"]);
                tempCli.NomeCli = Convert.ToString(leitor["NomeCli"]);
                tempCli.TelCli = Convert.ToString(leitor["TelCli"]);
                tempCli.EmailCli = Convert.ToString(leitor["EmailCli"]);

                listaCli.Add(tempCli);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaCli;
        }

        public Cliente listarPorCd(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbCliente " +
                "where CodCli=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaCli = new List<Cliente>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Cliente tempCli = new Cliente();

                tempCli.CodCli = Convert.ToInt32(leitor["CodCli"]);
                tempCli.NomeCli = Convert.ToString(leitor["NomeCli"]);
                tempCli.TelCli = Convert.ToString(leitor["TelCli"]);
                tempCli.EmailCli = Convert.ToString(leitor["EmailCli"]);

                listaCli.Add(tempCli);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaCli.FirstOrDefault();
        }

        public void insert(Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbCliente(NomeCli,TelCli,EmailCli) " +
                "values(@NomeCli,@TelCli,@EmailCli)", cn.MyConectarBD());

            cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cli.NomeCli;
            cmd.Parameters.Add("@TelCli", MySqlDbType.VarChar).Value = cli.TelCli;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = cli.EmailCli;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        public void update(Cliente cli)
        {
            MySqlCommand cmd = new MySqlCommand("update tbCliente set " +
                "NomeCli = @NomeCli," +
                "TelCli = @TelCli," +
                "EmailCli = @EmailCli," +
                "where CodCli = @CodCli", cn.MyConectarBD());

            cmd.Parameters.Add("@CodCli", MySqlDbType.VarChar).Value = cli.CodCli;
            cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cli.NomeCli;
            cmd.Parameters.Add("@TelCli", MySqlDbType.VarChar).Value = cli.TelCli;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = cli.EmailCli;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }


        public void delete(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Delete from tbCliente " +
                "where CodCli=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
