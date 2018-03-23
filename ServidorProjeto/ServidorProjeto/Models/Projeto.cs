using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ServidorProjeto.Models
{
    public class Projeto
    {
        public const int PROJETO_PARA_INSERIR = 0;

        public Projeto(int codProjeto, string nome, string descricao, int ano)
        {
            if (codProjeto < 1)
                throw new ArgumentException("Projeto: Código menor que 1");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("Projeto: nome não foi fornecido");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentNullException("Projeto: descricao não foi fornecida");

            if (ano < 1)
                throw new ArgumentException("Projeto: ano inválido");

            CodProjeto = codProjeto;
            nome       = Nome;
            Descricao  = descricao;
            Ano        = ano;
        }

        public Projeto(string nome, string descricao, int ano)
        {
            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("Projeto: nome não foi fornecido");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentNullException("Projeto: descricao não foi fornecida");

            if (ano < 1)
                throw new ArgumentException("Projeto: ano inválido");

            CodProjeto = PROJETO_PARA_INSERIR;
            nome = Nome;
            Descricao = descricao;
            Ano = ano;
        }

        public int CodProjeto   { get; private set; }
        public string Nome      { get; private set; }
        public string Descricao { get; private set; }
        public int Ano          { get; private set; }
    }
}