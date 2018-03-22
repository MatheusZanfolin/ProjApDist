using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
        private static string URI = "";
        public frmPrincipal()
        {
            InitializeComponent();
        }

        private void frmPrincipal_Load(object sender, EventArgs e)
        {

        }

        private void gbOpcoes_Enter(object sender, EventArgs e)
        {

        }

        private void gbDados_Enter(object sender, EventArgs e)
        {

        }

        private void btnSelecionar_Click(object sender, EventArgs e)
        {

        }

        private void btnAlterar_Click(object sender, EventArgs e)
        {

        }
    }
}
