using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class Produto
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é a chave identificadora da classe
        [Key]
        public int CodProd { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o link da imagem do profuto !!")]
        [Display(Name = "LINK DA IMAGEM DO PRODUTO")]
        public String LinkImg { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o nome do profuto !!")]
        [Display(Name = "NOME DO PRODUTO")]
        public String NomeProd { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar a descrição do profuto !!")]
        [Display(Name = "DESCRIÇÃO DO PRODUTO")]
        public String DescProd { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o valor unitário do profuto !!")]
        [Display(Name = "VALOR DO PRODUTO")]   
        public double ValorUnitario { get; set; }
    }
}
