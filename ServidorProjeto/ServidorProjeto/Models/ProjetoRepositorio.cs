using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ServidorProjeto.Models
{
    public class ProjetoRepositorio : IProjetoRepositorio
    {
        List<Projeto> projetos;

        SqlConnection conexao;

        public ProjetoRepositorio()
        {
            projetos = new List<Projeto>();

            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            SqlCommand cmd = new SqlCommand("getTodosOsProjetos_sp", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
                projetos.Add(new Projeto(Convert.ToInt32(leitor["codProjeto"]), leitor["nomeProjeto"].ToString(), leitor["descricao"].ToString(), Convert.ToInt32(leitor["ano"])));

            leitor.Close();
            conexao.Close();
        }

        public void DeleteProjeto(int codProjeto)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Aluno> GetAlunos(string nomeProjeto)
        {
            List<Aluno> alunos = new List<Aluno>();

            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            SqlCommand cmd = new SqlCommand("getAlunosProjeto_sp", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nomeProjeto", nomeProjeto);

            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
                alunos.Add(new Aluno(leitor["ra"].ToString(), leitor["nome"].ToString(), leitor["email"].ToString(), Convert.ToInt32(leitor["codProjeto"])));

            leitor.Close();
            conexao.Close();

            return alunos;
        }

        public IEnumerable<Aluno> GetAlunos(int codProjeto)
        {
            List<Aluno> alunos = new List<Aluno>();

            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            SqlCommand cmd = new SqlCommand("getAlunos_sp", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codProjeto", codProjeto);

            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
                alunos.Add(new Aluno(leitor["ra"].ToString(), leitor["nome"].ToString(), leitor["email"].ToString(), Convert.ToInt32(leitor["codProjeto"])));

            leitor.Close();
            conexao.Close();

            return alunos;
        }

        public IEnumerable<Professor> GetProfessores(string nomeProjeto)
        {
            List<Professor> professores = new List<Professor>();

            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            SqlCommand cmd = new SqlCommand("getProfessoresProjeto_sp", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@nomeProjeto", nomeProjeto);

            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
                professores.Add(new Professor(Convert.ToInt32(leitor["codProfessor"]), leitor["nome"].ToString(), leitor["email"].ToString()));

            leitor.Close();
            conexao.Close();

            return professores;
        }

        public IEnumerable<Professor> GetProfessores(int codProjeto)
        {
            List<Professor> professores = new List<Professor>();

            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            SqlCommand cmd = new SqlCommand("getProfessores_sp", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codProjeto", codProjeto);

            SqlDataReader leitor = cmd.ExecuteReader();

            while (leitor.Read())
                professores.Add(new Professor(Convert.ToInt32(leitor["codProfessor"]), leitor["nome"].ToString(), leitor["email"].ToString()));

            leitor.Close();
            conexao.Close();

            return professores;
        }

        public void PostProjeto(Projeto p, IEnumerable<Aluno> alunos, IEnumerable<Professor> professores)
        {
            if (p == null)
                throw new ArgumentNullException("ProjetoRepositorio: o projeto para POST é nulo.");

            if (alunos == null)
                throw new ArgumentNullException("ProjetoRepositorio: lista de alunos para POST de projeto é nulo.");

            if (professores == null)
                throw new ArgumentNullException("ProjetoRepositorio: lista de professores para POST de projeto é nulo.");

            if (ExistemAlunos(alunos) && ExistemProfessores(professores))
            {
                conexao = new SqlConnection(Properties.Resources.ConnectionString);

                var cmd = new SqlCommand("postProjeto_sp", conexao);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@nome", p.Nome);
                cmd.Parameters.AddWithValue("@descricao", p.Descricao);
                cmd.Parameters.AddWithValue("@ano", p.Ano);

                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("ProjetoRepositorio: erro no POST de projeto.");

                conexao.Close();
            }
            else
                throw new Exception("ProjetoRepositorio: POST de projeto com alunos ou professores inexistentes.");
        }

        public void PutProjeto(Projeto p, IEnumerable<Aluno> alunos, IEnumerable<Professor> professores)
        {
            throw new NotImplementedException();
        }

        public IEnumerable<Projeto> TodosOsProjetos()
        {
            return new List<Projeto>(projetos);
        }

        private bool ExistemProfessores(IEnumerable<Professor> professores)
        {
            throw new NotImplementedException();
        }

        private bool ExistemAlunos(IEnumerable<Aluno> alunos)
        {
            throw new NotImplementedException();
        }

        public List<Projeto> Projetos
        {
            get { return new List<Projeto>(projetos); }
        }
    }
}