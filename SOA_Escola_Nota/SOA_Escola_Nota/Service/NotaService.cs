using SOA_Escola_Nota.Comum;
using SOA_Escola_Nota.Entidade;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SOA_Escola_Nota.Service
{
    public class NotaService
    {
        public RepositoryBase _repositoryBase { get; set; }

        public NotaService()
        {
            _repositoryBase = new RepositoryBase(@"\SOA_Escola_Nota\SOA_Escola_Nota\Repository\NotasRepository.txt");
        }

        public bool InsertNota(Nota nota)
        {
            bool result = false;
            if (nota.Valido)
                result = _repositoryBase.Insert<Nota>(nota);
         
            return result;
        }

        public List<Nota> GetAllNota()
            => _repositoryBase.GetAll<Nota>();

        public bool DeleteNota(Nota nota)
            => _repositoryBase.Delete<Nota>(nota);

        public void UpdateNota(Nota nota)
        {
            var notaRepository = _repositoryBase.GetAll<Nota>().Find(n => n.IdProfessor == nota.IdProfessor && n.IdAluno == nota.IdAluno);

            if (notaRepository != null)
            {
                _repositoryBase.Delete<Nota>(notaRepository);
                _repositoryBase.Insert(nota);
            }
        }
    }
}
