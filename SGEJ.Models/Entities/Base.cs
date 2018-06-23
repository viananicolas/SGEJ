using System;
using System.ComponentModel.DataAnnotations;

namespace SGEJ.Models.Entities
{
    public abstract class Base
    {
        public int Id { get; set; }
        [Display(Name = "Data de Cadastro")]
        public DateTime DataCadastro { get; set; }
        public bool Excluido { get; set; }

        public void Excluir() => Excluido = true;
    }
}
