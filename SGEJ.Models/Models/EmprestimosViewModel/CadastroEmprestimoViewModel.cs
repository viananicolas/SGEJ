using System.Collections.Generic;

namespace SGEJ.Models.Models.EmprestimosViewModel
{
    public class CadastroEmprestimoViewModel
    {
        public string Nome { get; set; }
        public ICollection<int> Emprestimo { get; set; }
    }
}