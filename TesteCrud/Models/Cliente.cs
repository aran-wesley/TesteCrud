using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace TesteCrud.Models
{
    public class Cliente
    {
        public int id { get; set; }

        [Required]
        [MaxLength(100)]
        public string Nome { get; set; }

        [Required]
        public string Email { get; set; }

        [Required]
        [Display(Name = "CPF")]
        public string Cpf { get; set; }

        [Required]
        [Display(Name = "Cliente Ativo")]
        public bool ClienteAtivo { get; set; }

        [ForeignKey("Imovel")]
        [Display(Name ="Imovel")]
        public int IdImovel { get; set; }

        public virtual Imovel Imovel { get; set; }
    }
}