using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorProjeto.Models
{
    public class Aluno
    {
        public const int SEM_PROJETO = 0;

        public Aluno(string ra, string nome, string email, int codProjeto)
        {
            if (string.IsNullOrEmpty(ra))
                throw new Exception("Aluno: RA fornecido é nulo.");

            if (string.IsNullOrEmpty(nome))
                throw new Exception("Aluno: Nome fornecido é nulo.");

            if (string.IsNullOrEmpty(email))
                throw new Exception("Aluno: E-mail fornecido é nulo.");
            
            if (codProjeto < 0)
                throw new ArgumentException("Aluno: Código de projeto inválido");

            RA         = ra;
            Nome       = nome;
            Email      = email;
            CodProjeto = codProjeto;
        }

        public Aluno(string ra, string nome, string email)
        {
            if (string.IsNullOrEmpty(ra))
                throw new Exception("Aluno: RA fornecido é nulo.");

            if (string.IsNullOrEmpty(nome))
                throw new Exception("Aluno: Nome fornecido é nulo.");

            if (string.IsNullOrEmpty(email))
                throw new Exception("Aluno: E-mail fornecido é nulo.");

            RA = ra;
            Nome = nome;
            Email = email;
            CodProjeto = SEM_PROJETO;
        }
        public string ToString()
        {
            return Nome;
        }
        public string RA { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
        public Int32 CodProjeto { get; private set; }
    }
}