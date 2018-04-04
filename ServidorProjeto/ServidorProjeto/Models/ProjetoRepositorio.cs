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
            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            var cmd = new SqlCommand("deletaProjeto_sp", conexao);

            cmd.CommandType = CommandType.StoredProcedure;

            cmd.Parameters.AddWithValue("@codProjeto", codProjeto);

            conexao.Close();

            projetos.RemoveAll(x => x.CodProjeto == codProjeto);
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
                    throw new Exception("ProjetoRepositorio: erro de BD no POST de projeto.");

                conexao.Close();
            }
            else
                throw new Exception("ProjetoRepositorio: POST de projeto com alunos ou professores inexistentes.");

            projetos.Add(p);
        }

        public void PutProjeto(Projeto p, IEnumerable<Aluno> alunos, IEnumerable<Professor> professores)
        {
            if (p == null)
                throw new ArgumentNullException("ProjetoRepositorio: o projeto para PUT é nulo.");

            if (alunos == null)
                throw new ArgumentNullException("ProjetoRepositorio: lista de alunos para PUT de projeto é nulo.");

            if (professores == null)
                throw new ArgumentNullException("ProjetoRepositorio: lista de professores para PUT de projeto é nulo.");

            if (!projetos.Exists(x => x.CodProjeto == p.CodProjeto))
                throw new Exception("ProjetoRepositorio: alteração de projeto com código inválido");

            conexao = new SqlConnection(Properties.Resources.ConnectionString);

            var alteraProj = new SqlCommand("alteraProjeto_sp", conexao);

            alteraProj.Parameters.AddWithValue("@codProjeto" , p.CodProjeto);
            alteraProj.Parameters.AddWithValue("@nomeProjeto", p.Nome);
            alteraProj.Parameters.AddWithValue("@descricao"  , p.Descricao);
            alteraProj.Parameters.AddWithValue("@ano"        , p.Ano);

            if (alteraProj.ExecuteNonQuery() < 1)
                throw new Exception("ProjetoRepositorio: erro de BD no PUT de projeto (alteração de projeto).");

            conexao.Close();

            foreach (Aluno a in alunos)
            {
                conexao = new SqlConnection(Properties.Resources.ConnectionString);

                var cmd = new SqlCommand("relacionaProjetoAluno_sp", conexao);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codProjeto", p.CodProjeto);
                cmd.Parameters.AddWithValue("@ra", a.RA);

                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("ProjetoRepositorio: erro de BD no PUT de projeto (alteração de aluno).");

                conexao.Close();
            }

            foreach (Professor prof in professores)
            {
                conexao = new SqlConnection(Properties.Resources.ConnectionString);

                var cmd = new SqlCommand("relacionaProjetoProfessor_sp", conexao);

                cmd.CommandType = CommandType.StoredProcedure;

                cmd.Parameters.AddWithValue("@codProjeto", p.CodProjeto);
                cmd.Parameters.AddWithValue("@codProfessor", prof.CodProfessor);

                if (cmd.ExecuteNonQuery() < 1)
                    throw new Exception("ProjetoRepositorio: erro de BD no PUT de projeto (alteração de professor).");

                conexao.Close();
            }

            projetos.RemoveAll(x => x.CodProjeto == p.CodProjeto);

            projetos.Add(p);
        }

        public IEnumerable<Projeto> TodosOsProjetos()
        {
            return new List<Projeto>(projetos);
        }

        private bool ExistemProfessores(IEnumerable<Professor> professores)
        {
            return true; //TODO
        }

        private bool ExistemAlunos(IEnumerable<Aluno> alunos)
        {
            return true; //TODO
        }

        public List<Projeto> Projetos
        {
            get { return new List<Projeto>(projetos); }
        }
    }
}