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
        Conexao cn = new Conexao();

        public List<Produto> listar()
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbProduto ", cn.MyConectarBD());
            var listaProd = new List<Produto>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

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

            leitor.Close();
            cn.MyDesconectarBD();

            return listaProd;
        }

        public Produto listarPorCd(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Select * from tbProduto " +
                "where CodProd=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;
            var listaProd = new List<Produto>();

            MySqlDataReader leitor;
            leitor = cmd.ExecuteReader();

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

            leitor.Close();
            cn.MyDesconectarBD();

            return listaProd.FirstOrDefault();
        }

        public void insert(Produto prod)
        {
            MySqlCommand cmd = new MySqlCommand("insert into " +
                "tbProduto(LinkImg,NomeProd,DescProd,ValorUnitario) " +
                "values(@LinkImg,@NomeProd,@DescProd,@ValorUnitario)", cn.MyConectarBD());

            cmd.Parameters.Add("@LinkImg", MySqlDbType.VarChar).Value = prod.LinkImg;
            cmd.Parameters.Add("@NomeProd", MySqlDbType.VarChar).Value = prod.NomeProd;
            cmd.Parameters.Add("@DescProd", MySqlDbType.VarChar).Value = prod.DescProd;
            cmd.Parameters.Add("@ValorUnitario", MySqlDbType.VarChar).Value = prod.ValorUnitario;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }

        public void update(Produto prod)
        {
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

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }


        public void delete(int cd)
        {
            MySqlCommand cmd = new MySqlCommand("Delete from tbProduto " +
                "where CodProd=@cd", cn.MyConectarBD());
            cmd.Parameters.Add("@cd", MySqlDbType.VarChar).Value = cd;

            cmd.ExecuteNonQuery();
            cn.MyDesconectarBD();
        }
    }
}
