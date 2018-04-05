using Newtonsoft.Json;
using ServidorProjeto.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ClienteRestful
{
    /*
     •	GET para consultar todos os projetos, por nome do projeto
     •	GET , onde o código do projeto é passado como parâmetro e consulta todos os alunos e professores relacionados ao projeto
     •	GET , onde o nome do projeto é passado como parâmetro e consulta todos os alunos e professores relacionados ao projeto.
     •	POST para incluir um novo projeto, já relacionado com alunos e professores.
     •	PUT, para alterar nome do projeto, alunos e professores relacionados.
     •	DELETE, para excluir projeto.
     •	Consultar Projetos.
     •	Consultar projeto por código.
     •	Consultar projeto por nome.
     •	Inserir projeto, incluindo os alunos e professores relacionados.
     •	Alterar nome do projeto, alunos e professores relacionados.
     •	Excluir projeto
     •	Receber informações no formato Json do servidor API e converter para um objeto reconhecido por componente
     •	Enviar informações no formato Json ao servidor API

         */
    public partial class frmPrincipal : Form
    {
        private static string portaLocal = "11515";
        private static string URI = "http://localhost:" + portaLocal + "/api/";
        private string parametroURI;
        private int id = 1;//só vou usar na hora de consultar todos
        HttpClient cliente = new HttpClient();
        HttpResponseMessage resp = new HttpResponseMessage();
        private Projeto atual;
        enum Criterio
        {
            Codigo,
            Nome
        };
        enum Operacao
        {
            Select,
            Update,
            Insert,
            Delete,
            Todos
        };

        public frmPrincipal()
        {
            InitializeComponent();
            gbCriterios.Visible = false;
            gbDados.Visible = false;
            dgvDados.Visible = false;
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {
            try
            {
                string valorCriterio = txtCriterio.Text;
                switch (OperacaoSelecionada())
                {
                    case Operacao.Select:
                        Selecionar(CriterioSelecionado(), valorCriterio);
                        break;
                    case Operacao.Delete:
                        Deletar(CriterioSelecionado(), valorCriterio);
                        break;
                }

            }
            catch
            {

            }

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {
            try
            {
                switch (OperacaoSelecionada())
                {
                    case Operacao.Update:

                        break;
                    case Operacao.Insert:

                        break;
                }
            }
            catch
            {

            }
        }

        private void btnEscolher_Click(object sender, EventArgs e)
        {
            try
            {
                switch (OperacaoSelecionada()) {
                    case Operacao.Select:
                        gbCriterios.Text = "Selecione por um critério....";
                        gbCriterios.Visible = true;
                        break;
                    case Operacao.Update:
                        gbDados.Text = "Atualize algumas das informações abaixo:";
                        btnAlterar.Text = "Atualizar";
                        PrepararDadosGroupBox();
                        gbDados.Visible = true;
                        break;
                    case Operacao.Insert:
                        gbDados.Text = "Preencha as informações abaixo:";
                        btnAlterar.Text = "Inserir";
                        PrepararDadosGroupBox();
                        gbDados.Visible = true;
                        break;
                    case Operacao.Delete:
                        gbCriterios.Text = "Exclua por um critério....";
                        gbCriterios.Visible = true;
                        break;
                    case Operacao.Todos:
                        SelecionarTodos();
                        break;
                }
            }
            catch
            {

            }
        }

        private Operacao OperacaoSelecionada()
        {
            if (rbSelecionar.Checked)
                return Operacao.Select;
            if (rbAlterar.Checked)
                return Operacao.Update;
            if (rbInserir.Checked)
                return Operacao.Insert;
            if (rbDeletar.Checked)
                return Operacao.Delete;
            if (rbTodos.Checked)
                return Operacao.Todos;
            throw new Exception("Nenhum critério foi selecionado!");
        }

        private Criterio CriterioSelecionado()
        {
            if (rbCódigo.Checked)
                return Criterio.Codigo;
            if (rbNome.Checked)
                return Criterio.Nome;
            throw new Exception("Nenhum critério foi selecionado!");
        }
        private async void SelecionarTodos()
        {
            resp = await cliente.GetAsync(URI);
            if (resp.IsSuccessStatusCode)
            {
                LimparTabela();
                var ProjetoJsonString = await resp.Content.ReadAsStringAsync();
                dgvDados.DataSource = JsonConvert.DeserializeObject<Projeto[]>(ProjetoJsonString).ToList();
            }
            else
            {
                MessageBox.Show("Erro de conexão!");
            }
        }
        private async void Selecionar(Criterio filtro, string valor)
        {
            BindingSource bsDados = new BindingSource();
            if (filtro == Criterio.Nome)
            {
                parametroURI = valor; //esta linha está errada

            }
            if (filtro == Criterio.Codigo)
            {
                parametroURI = valor;//esta linha está errada

            }
            resp = await cliente.GetAsync(URI + "/" + parametroURI);
            if (resp.IsSuccessStatusCode)
            {

                LimparTabela();
                var ProjetoJsonString = await resp.Content.ReadAsStringAsync();
                bsDados.DataSource = JsonConvert.DeserializeObject<Projeto>(ProjetoJsonString);
                dgvDados.DataSource = bsDados;
            }
            else
            {
                throw new Exception("Falha ao obter o aluno : " + resp.StatusCode);
            }

        }
        private async void Deletar(Criterio filtro, string valor)
        {

            if (filtro == Criterio.Nome) //esta parte está errada
                parametroURI = valor;
            if (filtro == Criterio.Codigo)
                parametroURI = valor;
            resp = await cliente.DeleteAsync(URI + "/" + parametroURI);
            if (resp.IsSuccessStatusCode)
            {
                MessageBox.Show("Aluno foi excluído!");
            }
            else
            {
                MessageBox.Show("Falha ao excluir o aluno : " + resp.StatusCode);
            }
        }
        private async void PrepararDadosGroupBox()
        {

        }

        private void txtNome_Leave(object sender, EventArgs e)
        {
            try
            {
                string nome = txtNome.Text;

                try
                {
                    //verificações
                    Selecionar(Criterio.Nome, nome);
                    atual = OrganizarProjeto();
                    LimparTabela();
                    
                    SelecionarAlunosAsync();
                    SelecionarProfessoresAsync();
                }
                catch
                {
                    MessageBox.Show("Não foi possível encontrar este projeto! Por favor, verifique o nome e tente novamente!")
                }

            }
            catch
            {
                MessageBox.Show("Não foi possível encontrar este projeto! Por favor, verifique o nome e tente novamente!")
            }
        }
        private void LimparTabela()
        {
            int numLinhas = dgvDados.Rows.Count;
            for (int i = numLinhas - 1; i >= 0; i--)
                dgvDados.Rows.RemoveAt(i);
        }
        private Projeto OrganizarProjeto()
        {
            Projeto p = new Projeto(Convert.ToInt32(dgvDados.Rows[0].Cells[0].Value),  //codProjeto
                                     dgvDados.Rows[0].Cells[1].Value.ToString(),       //nome
                                     dgvDados.Rows[0].Cells[2].Value.ToString(),       //descrição
                                     Convert.ToInt32(dgvDados.Rows[0].Cells[3].Value), //ano
                                     dgvDados.Rows[0].Cells[4].Value.ToString(),       //alunos
                                     dgvDados.Rows[0].Cells[5].Value.ToString());      //professores
            return p;
        }
        private async Task SelecionarAlunosAsync()
        {
            
            cbxAluno0.Items[0] = atual.Alunos[0];
            cbxAluno1.Items[0] = atual.Alunos[1];
            cbxAluno2.Items[0] = atual.Alunos[2];
            int indAluno = 1;
            BindingSource bsDados = new BindingSource();
            parametroURI = parametroURI;
            resp = await cliente.GetAsync(URI + "/" + parametroURI);
            if (resp.IsSuccessStatusCode)
            {

                LimparTabela();
                var ProjetoJsonString = await resp.Content.ReadAsStringAsync();
                bsDados.DataSource = JsonConvert.DeserializeObject<Aluno[]>(ProjetoJsonString);
                for(bsDados.Position = 1; bsDados.Position < bsDados.Count; bsDados.Position++)
                {
                    if (!atual.ContemAluno(((Aluno)bsDados.Current).ToString()))
                    {
                        cbxAluno0.Items[indAluno] = bsDados.Current.ToString();
                        cbxAluno1.Items[indAluno] = bsDados.Current.ToString();
                        cbxAluno2.Items[indAluno] = bsDados.Current.ToString();
                        indAluno++;
                    }
                }
            }
            else
            {
                throw new Exception("Falha ao obter o aluno : " + resp.StatusCode);
            }
        }
        private async Task SelecionarProfessoresAsync()
        {
            cbxProf0.Items[0] = atual.Professores[0];
            cbxProf1.Items[0] = atual.Professores[1];
            int indProf = 1;
            BindingSource bsDados = new BindingSource();
            parametroURI = parametroURI;
            resp = await cliente.GetAsync(URI + "/" + parametroURI);
            if (resp.IsSuccessStatusCode)
            {

                LimparTabela();
                var ProjetoJsonString = await resp.Content.ReadAsStringAsync();
                bsDados.DataSource = JsonConvert.DeserializeObject<Professor[]>(ProjetoJsonString);
                for (bsDados.Position = 1; bsDados.Position < bsDados.Count; bsDados.Position++)
                {
                    if (!atual.ContemAluno(((Professor)bsDados.Current).ToString()))
                    {
                        cbxProf0.Items[indProf] = bsDados.Current.ToString();
                        cbxProf1.Items[indProf] = bsDados.Current.ToString();
                        indProf++;
                    }
                }
            }
            else
            {
                throw new Exception("Falha ao obter o professor : " + resp.StatusCode);
            }
        }

        private void cbxAluno0_Leave(object sender, EventArgs e)
        {

        }

        private void cbxProf0_Leave(object sender, EventArgs e)
        {
            int comboAlt = 1s;
            string novoProf = cbxProf1.SelectedItem.ToString();
            if (sender.Equals(cbxProf0)) {
                comboAlt = 0;
                novoProf = cbxProf0.SelectedItem.ToString();
            }

        }
    }
}
