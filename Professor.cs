using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorProjeto.Models
{
    public class Professor
    {
        public Professor(int codProfessor, string nome, string email)
        {
            if (codProfessor < 1)
                throw new ArgumentException("Aluno: Código de projeto inválido");

            if (string.IsNullOrEmpty(nome))
                throw new Exception("Professor: Nome fornecido é nulo.");

            if (string.IsNullOrEmpty(email))
                throw new Exception("Professor: E-mail fornecido é nulo.");

            CodProfessor = codProfessor;
            Nome         = nome;
            Email        = email;
        }
        public Professor(int codProfessor, string nome)
        {
            if (codProfessor < 1)
                throw new ArgumentException("Aluno: Código de projeto inválido");

            if (string.IsNullOrEmpty(nome))
                throw new Exception("Professor: Nome fornecido é nulo.");

            CodProfessor = codProfessor;
            Nome = nome;
        }
        public string ToString()
        {
            return Nome + ' ' + CodProfessor;
        }
        public static Professor Converter(string prof)
        {
            string nome = "";
            string cod = "";
            bool addandoNome = true;
            for (int i = 0; i < prof.Length; i++)
            {
                if (prof[i] == ' ')
                {
                    addandoNome = false;
                }
                else
                {
                    if (addandoNome)
                    {
                        nome += prof[i];
                    }
                    else
                    {
                        cod += prof[i];
                    }

                }

            }
            return new Professor(Convert.ToInt32(cod), nome);
        }
        public int CodProfessor { get; private set; }
        public string Nome { get; private set; }
        public string Email { get; private set; }
    }
}