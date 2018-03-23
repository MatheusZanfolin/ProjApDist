using Newtonsoft.Json;
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
        private string URI = "http://localhost:" + portaLocal + "/api/";
        private string parametroURI;
        private int id = 1;//só vou usar na hora de consultar todos
        HttpClient cliente = new HttpClient();
        HttpResponseMessage resp = new HttpResponseMessage();

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
                var ProjetoJsonString = await resp.Content.ReadAsStringAsync();
                dgvDados.DataSource = JsonConvert.DeserializeObject<Projeto[]>(ProjetoJsonString).ToList();
            }
            else
            {
                MessageBox.Show("Erro de conexão!")
            }
        }
        private async void Selecionar(Criterio filtro, string valor)
        {
            BindingSource bsDados = new BindingSource();
            if(filtro==Criterio.Nome)
            resp = await cliente.GetAsync(URI + "/" + parametroURI);
            if (resp.IsSuccessStatusCode)
            {
                var ProjetoJsonString = await resp.Content.ReadAsStringAsync();
                bsDados.DataSource = JsonConvert.DeserializeObject<Projeto>(ProjetoJsonString);
                dgvDados.DataSource = bsDados;
            }
            else
            {
                MessageBox.Show("Falha ao obter o aluno : " + resp.StatusCode);
            }
        }
        private async void Deletar(Criterio filtro, string valor)
        {

        }
        private async void PrepararDadosGroupBox()
        {

        }
    }

}
