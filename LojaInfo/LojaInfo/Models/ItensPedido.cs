using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class ItensPedido
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é uma das chaves identificadoras da classe
        [Required(ErrorMessage = "Obrigatório informar o código do pedido!!")]
        [Display(Name = "CÓDIGO DO PEDIDO")]
        public int CodPed { get; set; }

        // Criando o modelo vindo do banco para ser tratado, campo que é uma das chaves identificadoras da classe
        [Required(ErrorMessage = "Obrigatório informar o código do produto!!")]
        [Display(Name = "PRODUTO")]
        public int CodProd { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar a quantidade do item!!")]
        [Display(Name = "QUANTIDADE DO ITEM")]
        public int Qtitem { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Display(Name = "VALOR DO ITEM")]
        public double ValorItem { get; set; }

        public String LinkImg { get; set; }
        public String NomeProd { get; set; }
    }
}
