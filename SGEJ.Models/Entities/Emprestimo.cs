using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGEJ.Models.Entities
{
    public class Emprestimo : Base
    {
        [Display(Name = "Data prevista de devolução")]
        public DateTime DataPrevistaDevolucao { get; set; }
        [Display(Name = "Data de devolução")]
        public DateTime? DataDevolucao { get; set; }
        public ICollection<EmprestimoJogo> Emprestimos { get; set; }
    }
}
