using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServidorProjeto.Models
{
    interface IProjetoRepositorio
    {
        IEnumerable<Projeto> TodosOsProjetos();

        IEnumerable<Aluno> GetAlunos(string nomeProjeto);

        IEnumerable<Aluno> GetAlunos(int codProjeto);

        IEnumerable<Professor> GetProfessores(string nomeProjeto);

        IEnumerable<Professor> GetProfessores(int codProjeto);

        void PostProjeto(Projeto p, IEnumerable<Aluno> alunos, IEnumerable<Professor> professores);

        void PutProjeto(Projeto p, IEnumerable<Aluno> alunos, IEnumerable<Professor> professores);

        void DeleteProjeto(int codProjeto);
    }
}
