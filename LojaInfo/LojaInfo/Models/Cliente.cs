using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class Cliente
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é a chave identificadora da classe
        [Key]
        public int CodCli { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o nome do cliente !!")]
        [Display(Name = "NOME DO CLIENTE")]
        public String NomeCli { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o telefone do cliente !!")]
        [Display(Name = "TELEFONE DO CLIENTE")]
        public String TelCli { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o email do cliente !!")]
        [Display(Name = "EMAIL DO CLIENTE")]
        public String EmailCli { get; set; }
    }
}
