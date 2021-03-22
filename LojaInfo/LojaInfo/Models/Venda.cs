using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class Venda
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é a chave identificadora da classe
        [Key]
        [Display(Name = "CÓDIGO DA VENDA")]
        public int CodVenda { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar código do pedido!!")]
        [Display(Name = "CÓDIGO DO PEDIDO")]
        public int CodPed { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Display(Name = "VALOR DA VENDA")]
        public double Valor { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar a forma de pagamento!!")]
        [Display(Name = "FORMA DE PAGAMENTO")]
        public String FormaPag { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Display(Name = "DATA DA ENTREGA")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataEntrega { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Display(Name = "ENDEREÇO DA ENTREGA")]
        public String EndEntrega { get; set; }
    }
}
