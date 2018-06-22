using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace SGEJ.Models.Entities
{
    public class Jogo : Base
    {
        [Display(Name = "Título do Jogo")]
        public string NomeJogo { get; set; }
        [Display(Name = "Ano de lançamento")]
        public int AnoLancamento { get; set; }
        public ICollection<EmprestimoJogo> Emprestimos { get; set; }
    }
}
