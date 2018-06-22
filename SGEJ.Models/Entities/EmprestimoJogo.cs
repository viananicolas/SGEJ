namespace SGEJ.Models.Entities
{
    public class EmprestimoJogo : Base
    {
        public Jogo Jogo { get; set; }
        public Emprestimo Emprestimo { get; set; }
    }
}