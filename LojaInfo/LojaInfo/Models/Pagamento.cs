using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class Pagamento
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é a chave identificadora da classe
        [Key]
        public int CodPagto { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar a descrição do produto !!")]
        [Display(Name = "DESCRIÇÃO DO PRODUTO")]
        public String DescProd { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar a quantidade do produto!!")]
        [Display(Name = "QUANTIDADE DO PRODUTO")]
        public int Quantidade { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o valor total do pagamento !!")]
        [Display(Name = "VALOR TOTAL DO PAGAMENTO")]
        public double ValorUnitario { get; set; }
    }
}
