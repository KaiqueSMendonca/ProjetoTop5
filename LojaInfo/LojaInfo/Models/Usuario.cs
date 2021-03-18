using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace LojaInfo.Models
{
    public class Usuario
    {
    public  int cod_usuario { get; set; }

        // criando o modelo vindo do banco de dados para ser tratad, campo obrigatório e mostrar o texto indicado
    [Required(ErrorMessage ="Obrigatório digitar um nome !!")]
    [Display(Name ="NOME DO USUÁRIO")]
    public string nome_usuario { get; set; }

        // criando o modelo vindo do banco de dados para ser tratad, campo obrigatório e mostrar o texto indicado
        [Required(ErrorMessage = "Obrigatório digitar uma senha !!")]
     [Display(Name = "SENHA DO USUÁRIO")]
      public string senha_usuario { get; set; }
    }
}