using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace TesteCrud.Models
{
    [Table("Imoveis")]
    public class Imovel
    {
        public int Id { get; set; }

        [Required]
        [Display(Name ="Tipo Negócio")]
        public string TipoNegocio { get; set; }

        [Required]
        [Display(Name ="Valor Imovel")]
        public string ValorImovel { get; set; }

        [Required]
        [Display(Name ="Descrição")]
        public string Descricao { get; set; }

        [Required]
        [Display(Name ="Imovel Ativo")]
        public bool ImovelAtivo { get; set; }
    }
}