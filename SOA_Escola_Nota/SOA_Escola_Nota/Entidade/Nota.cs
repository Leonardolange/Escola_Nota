
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Entidade
{
    public class Nota 
    {
        public Nota(decimal Valor, int idAluno, int idProfessor)
        {
            Valor = Valor;  
            IdAluno = idAluno;  
            IdProfessor = idProfessor;
        }

        public decimal Valor { get; set; }
        public int IdAluno { get; set; }
        public int IdProfessor { get; set; }
        public bool Valido
        {
            get { return ValidarNota(); }
            private set {  }
        }

        private bool ValidarNota()
            => Valor >= 0 && Valor <= 10;  
    }
}
