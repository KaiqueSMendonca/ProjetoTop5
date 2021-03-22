using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class Pedido
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é a chave identificadora da classe
        [Key]
        [Display(Name = "CÓDIGO DO PEDIDO")]
        public int CodPed { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar código do funcionário!!")]
        [Display(Name = "CÓDIGO DO FUNCIONÁRIO")]
        public String CodFunc { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar código do cliente!!")]
        [Display(Name = "CÓDIGO DO CLIENTE")]
        public String CodCli { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar a data do pedido !!")]
        [Display(Name = "DATA DO PEDIDO")]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime DataPed { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Display(Name = "VALOR DO PEDIDOD")]
        public double ValorPed { get; set; }
    }
}
