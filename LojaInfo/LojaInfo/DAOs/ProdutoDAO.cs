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
    public class ProdutoDAO
    {
        //Instanciando conexão
        Conexao cn = new Conexao();

        //Método para listar os itens já cadastrados no banco de dados
        public List<Produto> listar()
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbProduto ", cn.MyConectarBD());
            var listaProd = new List<Produto>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Produto tempProd = new Produto();

                tempProd.CodProd = Convert.ToInt32(leitor["CodProd"]);
                tempProd.LinkImg = Convert.ToString(leitor["LinkImg"]);
                tempProd.NomeProd = Convert.ToString(leitor["NomeProd"]);
                tempProd.DescProd = Convert.ToString(leitor["DescProd"]);
                tempProd.ValorUnitario = Convert.ToDouble(leitor["ValorUnitario"]);

                listaProd.Add(tempProd);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaProd;
        }

        //Método para listar determinado produto já cadastrados no banco de dados
        public Produto listarPorCd(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Select * from tbProduto " +
                "where CodProd=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaProd = new List<Produto>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

            //Passando os registros encontrados no banco para um objeto e posteriormente para uma lista
            while (leitor.Read())
            {
                Produto tempProd = new Produto();

                tempProd.CodProd = Convert.ToInt32(leitor["CodProd"]);
                tempProd.LinkImg = Convert.ToString(leitor["LinkImg"]);
                tempProd.NomeProd = Convert.ToString(leitor["NomeProd"]);
                tempProd.DescProd = Convert.ToString(leitor["DescProd"]);
                tempProd.ValorUnitario = Convert.ToDouble(leitor["ValorUnitario"]);

                listaProd.Add(tempProd);
            }

            //fechando o reader e a conexão com banco
            leitor.Close();
            cn.MyDesconectarBD();

            return listaProd.FirstOrDefault();
        }

        //Método para inserir um registro na tabela do banco de dados
        public void insert(Produto prod)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbProduto(LinkImg,NomeProd,DescProd,ValorUnitario) " +
                "values(@LinkImg,@NomeProd,@DescProd,@ValorUnitario)", cn.MyConectarBD());

            cmd.Parameters.Add("@LinkImg", MySqlDbType.VarChar).Value = prod.LinkImg;
            cmd.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = prod.NomeProd;
            cmd.Parameters.Add("@DescProd", MySqlDbType.VarChar).Value = prod.DescProd;
            cmd.Parameters.Add("@ValorUnitario", MySqlDbType.VarChar).Value = prod.ValorUnitario;

            //fechando o reader e a conexão com banco
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para alterar registro existente no banco
        public void update(Produto prod)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("update tbProduto set " +
                "LinkImg = @LinkImg," +
                "NomeProd = @NomeProd," +
                "DescProd = @DescProd," +
                "ValorUnitario = @ValorUnitario " +
                "where CodProd = @CodProd", cn.MyConectarBD());

            cmd.Parameters.Add("@CodProd", MySqlDbType.VarChar).Value = prod.CodProd;
            cmd.Parameters.Add("@LinkImg", MySqlDbType.VarChar).Value = prod.LinkImg;
            cmd.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = prod.NomeProd;
            cmd.Parameters.Add("@DescProd", MySqlDbType.VarChar).Value = prod.DescProd;
            cmd.Parameters.Add("@ValorUnitario", MySqlDbType.VarChar).Value = prod.ValorUnitario;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        //Método para deletar um registro do banco
        public void delete(int cd)
        {
            //Montando o comando SQL
            MySqlCommand cmd = new MySqlCommand("Delete from tbProduto " +
                "where CodProd=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            //Executando o comando e fechando a conexão
            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
