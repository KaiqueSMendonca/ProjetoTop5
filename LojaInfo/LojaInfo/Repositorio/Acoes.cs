using LojaInfo.Models;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


namespace LojaInfo.Repositorio
{
    public class Acoes
    {
        // instanciando a classe conexão do banco
        Conexao con = new Conexao();
        MySqlCommand cmd = new MySqlCommand();

        // criando o metodo para testar o usuario e senha no banco
        public Usuario TestarUsuario(Usuario user)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbUsuario " +
                "where nome_usuario=@usuario and senha_usuario=@senha", con.MyConectarBD());
            cmd.Parameters.Add("@usuario", MySqlDbType.VarChar).Value = user.nome_usuario;
            cmd.Parameters.Add("@senha", MySqlDbType.VarChar).Value = user.senha_usuario;

            MySqlDataReader leitor;

            leitor = cmd.ExecuteReader();
            if (leitor.HasRows)
            {
                while (leitor.Read())
                {
                    Usuario dto = new Usuario();
                    dto.nome_usuario = Convert.ToString(leitor["nome_usuario"]);
                    dto.senha_usuario = Convert.ToString(leitor["senha_usuario"]);
                }
            }
            else
            {
                user.nome_usuario = null;
                user.senha_usuario = null;
            }

            return user;
        }

    }

}
 
