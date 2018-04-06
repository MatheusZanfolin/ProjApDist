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
            Nome       = nome;
            Descricao  = descricao;
            Ano        = ano;
        }
        public Projeto(int codProjeto, string nome, string descricao, int ano, string alunos, string professores)
        {
            if (codProjeto < 1)
                throw new ArgumentException("Projeto: Código menor que 1");

            if (string.IsNullOrEmpty(nome))
                throw new ArgumentNullException("Projeto: nome não foi fornecido");

            if (string.IsNullOrEmpty(descricao))
                throw new ArgumentNullException("Projeto: descricao não foi fornecida");

            if (ano < 1)
                throw new ArgumentException("Projeto: ano inválido");

            SetAlunos(alunos);
            SetProfessores(professores);
            CodProjeto = codProjeto;
            nome = Nome;
            Descricao = descricao;
            Ano = ano;
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
        public void SetAlunos(string alunos)
        {
            int qtdAlunos = 0;
            List<string> listaAlunos = new List<string>();
            if (listaAlunos.Count > 0) {
                string atual = listaAlunos[0].ToString();
                int i;
                for (i = 1; i < alunos.Length; i++)
                {
                    if (alunos[i] == ',')
                    {
                        listaAlunos.Add(atual);
                        atual = "";
                        qtdAlunos++;
                        continue;
                    }
                    if (alunos[i-1] == ',')
                    {

                        atual = alunos[i].ToString();
                        continue;
                    }
                    atual += alunos[i];
                }
                if (alunos[i - 1] != ',')
                {
                    listaAlunos.Add(atual);
                    atual = "";
                    qtdAlunos++;
                }
                this.Alunos = new Aluno[qtdAlunos];
                
                for(int j = 0; j < qtdAlunos; j++)
                {

                    this.Alunos[j] = Aluno.Converter(listaAlunos[j]);
                }
            }
        }
        public void SetProfessores(string professores)
        {
            int qtdProfessores = 0;
            List<string> listaProfessores = new List<string>();
            if (listaProfessores.Count > 0)
            {
                string atual = listaProfessores[0].ToString();
                int i;
                for (i = 1; i < Professores.Length; i++)
                {
                    if (professores[i] == ',')
                    {
                        listaProfessores.Add(atual);
                        atual = "";
                        qtdProfessores++;
                        continue;
                    }
                    if (professores[i - 1] == ',')
                    {
                        atual = Professores[i].ToString();
                        continue;
                    }
                    atual += Professores[i];
                }
                if (professores[i - 1] != ',')
                {
                    listaProfessores.Add(atual);
                    atual = "";
                    qtdProfessores++;
                }
                this.Professores = new string[qtdProfessores];
                for (int j = 0; j < qtdProfessores; j++)
                {
                    this.Professores[j] = listaProfessores[j];
                }
            }
        }
        public bool ContemAluno(string aluno)
        {
            for(int i=0;i< Alunos.Length; i++)
            {
                if (Alunos[i] != aluno)
                    return false;
            }
            return true;

        }
        public bool ContemProfessor(string professor)
        {
            for (int i = 0; i < Professores.Length; i++)
            {
                if (Professores[i] != professor)
                    return false;
            }
            return true;
        }
        public int CodProjeto       { get; private set; }
        public string Nome          { get; private set; }
        public string Descricao     { get; private set; }
        public int Ano              { get; private set; }
        public Aluno[] Alunos      { get; private set; }
        public Professor[] Professores { get; private set; }
    }
}