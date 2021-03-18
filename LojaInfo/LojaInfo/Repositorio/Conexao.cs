using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace LojaInfo.Repositorio
{
    // classe conexão do banco de dados
    public class Conexao
    {
        MySqlConnection cn = new MySqlConnection("Server=localhost; DataBase=BDLOJAINFO; user=root;pwd=1234567");
        public static string msg;

        // conecta no banco
        public MySqlConnection MyConectarBD()
        {
            try
            {
                cn.Open();

            }
            catch (Exception erro)
            {
                msg = "Erro ao se conectar " + erro.Message;
            }
            return cn;
        }

        // desconecta do banco
        public MySqlConnection MyDesconectarBD()
        {
            try
            {
                cn.Close();
            }
            catch(Exception erro)
            {
                msg = "Erro ao se conectar" + erro.Message;
            }
            return cn;
        }
    }
}
