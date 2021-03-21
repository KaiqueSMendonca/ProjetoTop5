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
        Conexao cn = new Conexao();

        public List<Usuario> listar()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbUsuario " ,cn.MyConectarBD());
            var listaUsu = new List<Usuario>(); 

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Usuario tempUsu = new Usuario();

                tempUsu.cod_usuario = Convert.ToInt32(leitor["cod_usuario"]);
                tempUsu.nome_usuario = Convert.ToString(leitor["nome_usuario"]);
                tempUsu.senha_usuario = Convert.ToString(leitor["senha_usuario"]);

                listaUsu.Add(tempUsu);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaUsu;
        }

        public Usuario listarPorCd(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbUsuario " +
                "where cod_usuario=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaUsu = new List<Usuario>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            while (leitor.Read())
            {
                Usuario tempUsu = new Usuario();

                tempUsu.cod_usuario = Convert.ToInt32(leitor["cod_usuario"]);
                tempUsu.nome_usuario = Convert.ToString(leitor["nome_usuario"]);
                tempUsu.senha_usuario = Convert.ToString(leitor["senha_usuario"]);

                listaUsu.Add(tempUsu);
            }

            leitor.Close();
            cn.MyDesconectarBD();

            return listaUsu.FirstOrDefault();
        }

        public void insert(Usuario usu)
        {
            MySqlCommand cmd = new MySqlCommand("insert into tbUsuario(nome_usuario,senha_usuario) " +
                "values(@nome_usuario,@senha_usuario)", cn.MyConectarBD());
            cmd.Parameters.Add("@nome_usuario", MySqlDbType.VarChar).Value = usu.nome_usuario;
            cmd.Parameters.Add("@senha_usuario", MySqlDbType.VarChar).Value = usu.senha_usuario;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        public void update(Usuario usu)
        {
            MySqlCommand cmd = new MySqlCommand("update tbUsuario set " +
                "nome_usuario = @nome_usuario," +
                "senha_usuario = @senha_usuario " +
                "where cod_usuario = @cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = usu.cod_usuario;
            cmd.Parameters.Add("@nome_usuario", MySqlDbType.VarChar).Value = usu.nome_usuario;
            cmd.Parameters.Add("@senha_usuario", MySqlDbType.VarChar).Value = usu.senha_usuario;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }


        public void delete(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Delete from tbUsuario " +
                "where cod_usuario=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
