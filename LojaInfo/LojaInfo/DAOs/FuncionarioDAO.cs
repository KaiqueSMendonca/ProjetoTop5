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
    public class FuncionarioDAO
    {
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os itens já cadastrados no banco de dados
        public List<Funcionario> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbFuncionario ", cn.MyConectarBD());
            var listaFunc = new List<Funcionario>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Funcionario tempFunc = new Funcionario();

                tempFunc.CodFunc = Convert.ToInt32(leitor["CodFunc"]);
                tempFunc.NomeFunc = Convert.ToString(leitor["NomeFunc"]);
                tempFunc.TelFunc = Convert.ToString(leitor["TelFunc"]);

                listaFunc.Add(tempFunc);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaFunc;
        }

        //Método para listar determinado funcionário já cadastrados no banco de dados
        public Funcionario listarPorCd(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbFuncionario " +
                "where CodFunc=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaFunc = new List<Funcionario>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Funcionario tempFunc = new Funcionario();

                tempFunc.CodFunc = Convert.ToInt32(leitor["CodFunc"]);
                tempFunc.NomeFunc = Convert.ToString(leitor["NomeFunc"]);
                tempFunc.TelFunc = Convert.ToString(leitor["TelFunc"]);

                listaFunc.Add(tempFunc);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaFunc.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(Funcionario func)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbFuncionario(NomeFunc,TelFunc) " +
                "values(@NomeFunc,@TelFunc)", cn.MyConectarBD());

            cmd.Parameters.Add("@NomeFunc", MySqlDbType.VarChar).Value = func.NomeFunc;
            cmd.Parameters.Add("@TelFunc", MySqlDbType.VarChar).Value = func.TelFunc;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para alterar registro existente no banco
        public void update(Funcionario func)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbFuncionario set " +
                "NomeFunc = @NomeFunc," +
                "TelFunc = @TelFunc " +
                "where CodFunc = @CodFunc", cn.MyConectarBD());

            cmd.Parameters.Add("@CodFunc", MySqlDbType.VarChar).Value = func.CodFunc;
            cmd.Parameters.Add("@NomeFunc", MySqlDbType.VarChar).Value = func.NomeFunc;
            cmd.Parameters.Add("@TelFunc", MySqlDbType.VarChar).Value = func.TelFunc;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para deletar um registro do banco
        public void delete(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbFuncionario " +
                "where CodFunc=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
