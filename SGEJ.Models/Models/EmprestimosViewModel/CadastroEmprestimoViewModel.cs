using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGEJ.Models.Models.EmprestimosViewModel
{
    public class CadastroEmprestimoViewModel
    {
        public int Id { get; set; }
        [Required]
        public int Amigo { get; set; }
        [Display(Name = "Data prevista de devolução"), Required]
        public DateTime DataPrevistaDevolucao { get; set; }
        public DateTime DataCadastro { get; set; }
        [Display(Name = "Data de devolução")]
        public DateTime? DataDevolucao { get; set; }
        [Required]
        public ICollection<int> Jogos { get; set; }
    }
}