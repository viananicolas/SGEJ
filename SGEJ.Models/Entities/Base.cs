using System;

namespace SGEJ.Models.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Excluido { get; set; }

        public void Excluir() => Excluido = true;
    }
}
