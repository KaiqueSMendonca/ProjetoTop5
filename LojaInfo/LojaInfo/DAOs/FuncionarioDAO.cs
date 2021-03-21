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
        Conexao cn = new Conexao();

        public List<Funcionario> listar()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbFuncionario ", cn.MyConectarBD());
            var listaFunc = new List<Funcionario>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Funcionario tempFunc = new Funcionario();

                tempFunc.CodFunc = Convert.ToInt32(leitor["CodPagto"]);
                tempFunc.NomeFunc = Convert.ToString(leitor["DescPgto"]);
                tempFunc.TelFunc = Convert.ToString(leitor["Quantidade"]);

                listaFunc.Add(tempFunc);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaFunc;
        }

        public Funcionario listarPorCd(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbFuncionario " +
                "where CodFunc=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaFunc = new List<Funcionario>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Funcionario tempFunc = new Funcionario();

                tempFunc.CodFunc = Convert.ToInt32(leitor["CodPagto"]);
                tempFunc.NomeFunc = Convert.ToString(leitor["DescPgto"]);
                tempFunc.TelFunc = Convert.ToString(leitor["Quantidade"]);

                listaFunc.Add(tempFunc);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaFunc.FirstOrDefault();
        }

        public void insert(Funcionario func)
        {
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbFuncionario(NomeFunc,TelFunc) " +
                "values(@NomeFunc,@TelFunc)", cn.MyConectarBD());

            cmd.Parameters.Add("@NomeFunc", MySqlDbType.VarChar).Value = func.NomeFunc;
            cmd.Parameters.Add("@TelFunc", MySqlDbType.VarChar).Value = func.TelFunc;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        public void update(Funcionario func)
        {
            MySqlCommand cmd = new MySqlCommand("update tbFuncionario set " +
                "NomeFunc = @NomeFunc," +
                "TelFunc = @TelFunc," +
                "where CodFunc = @CodFunc", cn.MyConectarBD());

            cmd.Parameters.Add("@CodFunc", MySqlDbType.VarChar).Value = func.CodFunc;
            cmd.Parameters.Add("@NomeFunc", MySqlDbType.VarChar).Value = func.NomeFunc;
            cmd.Parameters.Add("@TelFunc", MySqlDbType.VarChar).Value = func.TelFunc;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }


        public void delete(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Delete from tbFuncionario " +
                "where CodFunc=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
