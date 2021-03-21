using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LojaInfo.Models
{
    public class Funcionario
    {
        // Criando o modelo vindo do banco para ser tratado, campo que é a chave identificadora da classe
        [Key]
        public int CodFunc { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o nome do funcionário !!")]
        [Display(Name = "NOME DO FUNCIONÁRIO")]
        public String NomeFunc { get; set; }

        // criando o modelo vindo do banco de dados para ser tratado, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório informar o telefone do funcionário !!")]
        [Display(Name = "TELEFONE DO FUNCIONÁRIO")]
        public String TelFunc { get; set; }
    }
}
