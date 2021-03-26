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
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os itens já cadastrados no banco de dados
        public List<Cliente> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbCliente ", cn.MyConectarBD());
            var listaCli = new List<Cliente>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Cliente tempCli = new Cliente();

                tempCli.CodCli = Convert.ToInt32(leitor["CodCli"]);
                tempCli.NomeCli = Convert.ToString(leitor["NomeCli"]);
                tempCli.TelCli = Convert.ToString(leitor["TelCli"]);
                tempCli.EmailCli = Convert.ToString(leitor["EmailCli"]);

                listaCli.Add(tempCli);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaCli;
        }

        //Método para listar determinado cliente já cadastrados no banco de dados
        public Cliente listarPorCd(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbCliente " +
                "where CodCli=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaCli = new List<Cliente>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Cliente tempCli = new Cliente();

                tempCli.CodCli = Convert.ToInt32(leitor["CodCli"]);
                tempCli.NomeCli = Convert.ToString(leitor["NomeCli"]);
                tempCli.TelCli = Convert.ToString(leitor["TelCli"]);
                tempCli.EmailCli = Convert.ToString(leitor["EmailCli"]);

                listaCli.Add(tempCli);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaCli.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(Cliente cli)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbCliente(NomeCli,TelCli,EmailCli) " +
                "values(@NomeCli,@TelCli,@EmailCli)", cn.MyConectarBD());

            cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cli.NomeCli;
            cmd.Parameters.Add("@TelCli", MySqlDbType.VarChar).Value = cli.TelCli;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = cli.EmailCli;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para alterar registro existente no banco
        public void update(Cliente cli)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbCliente set " +
                "NomeCli = @NomeCli," +
                "TelCli = @TelCli," +
                "EmailCli = @EmailCli " +
                "where CodCli = @CodCli", cn.MyConectarBD());

            cmd.Parameters.Add("@CodCli", MySqlDbType.VarChar).Value = cli.CodCli;
            cmd.Parameters.Add("@NomeCli", MySqlDbType.VarChar).Value = cli.NomeCli;
            cmd.Parameters.Add("@TelCli", MySqlDbType.VarChar).Value = cli.TelCli;
            cmd.Parameters.Add("@EmailCli", MySqlDbType.VarChar).Value = cli.EmailCli;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para deletar um registro do banco
        public void delete(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbCliente " +
                "where CodCli=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
