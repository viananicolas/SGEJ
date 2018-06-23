using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using SGEJ.Models.Enums;

namespace SGEJ.Models.Entities
{
    public class Jogo : Base
    {
        [Display(Name = "Título do Jogo")]
        public string NomeJogo { get; set; }
        [Display(Name = "Desenvolvedora")]
        public string Desenvolvedora { get; set; }
        [Display(Name = "Distribuidora")]
        public string Distribuidora { get; set; }
        [Display(Name = "Ano de lançamento")]
        public int AnoLancamento { get; set; }
        public Plataforma Plataforma { get; set; }
        public ICollection<EmprestimoJogo> Emprestimos { get; set; }
    }
}
