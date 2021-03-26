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
    public class UsuarioDAO
    {
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os itens já cadastrados no banco de dados
        public List<Usuario> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbUsuario " ,cn.MyConectarBD());
            var listaUsu = new List<Usuario>(); 

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Usuario tempUsu = new Usuario();

                tempUsu.cod_usuario = Convert.ToInt32(leitor["cod_usuario"]);
                tempUsu.nome_usuario = Convert.ToString(leitor["nome_usuario"]);
                tempUsu.senha_usuario = Convert.ToString(leitor["senha_usuario"]);

                listaUsu.Add(tempUsu);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaUsu;
        }

        //Método para listar determinado produto já cadastrados no banco de dados
        public Usuario listarPorCd(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbUsuario " +
                "where cod_usuario=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaUsu = new List<Usuario>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Usuario tempUsu = new Usuario();

                tempUsu.cod_usuario = Convert.ToInt32(leitor["cod_usuario"]);
                tempUsu.nome_usuario = Convert.ToString(leitor["nome_usuario"]);
                tempUsu.senha_usuario = Convert.ToString(leitor["senha_usuario"]);

                listaUsu.Add(tempUsu);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaUsu.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(Usuario usu)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into tbUsuario(nome_usuario,senha_usuario) " +
                "values(@nome_usuario,@senha_usuario)", cn.MyConectarBD());
            cmd.Parameters.Add("@nome_usuario", MySqlDbType.VarChar).Value = usu.nome_usuario;
            cmd.Parameters.Add("@senha_usuario", MySqlDbType.VarChar).Value = usu.senha_usuario;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para alterar registro existente no banco
        public void update(Usuario usu)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbUsuario set " +
                "nome_usuario = @nome_usuario," +
                "senha_usuario = @senha_usuario " +
                "where cod_usuario = @cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = usu.cod_usuario;
            cmd.Parameters.Add("@nome_usuario", MySqlDbType.VarChar).Value = usu.nome_usuario;
            cmd.Parameters.Add("@senha_usuario", MySqlDbType.VarChar).Value = usu.senha_usuario;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para deletar um registro do banco
        public void delete(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbUsuario " +
                "where cod_usuario=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
