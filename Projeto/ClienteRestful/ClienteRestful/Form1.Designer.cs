namespace ClienteRestful
{
    partial class frmPrincipal
    {
        /// <summary>
        /// Variável de designer necessária.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpar os recursos que estão sendo usados.
        /// </summary>
        /// <param name="disposing">true se for necessário descartar os recursos gerenciados; caso contrário, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código gerado pelo Windows Form Designer

        /// <summary>
        /// Método necessário para suporte ao Designer - não modifique 
        /// o conteúdo deste método com o editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            this.dgvDados = new System.Windows.Forms.DataGridView();
            this.codProjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nomeProjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.descProjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.anoProjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.alunosProjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.profProjeto = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.gbOpcoes = new System.Windows.Forms.GroupBox();
            this.rbDeletar = new System.Windows.Forms.RadioButton();
            this.rbSelecionar = new System.Windows.Forms.RadioButton();
            this.rbInserir = new System.Windows.Forms.RadioButton();
            this.rbAlterar = new System.Windows.Forms.RadioButton();
            this.gbCriterios = new System.Windows.Forms.GroupBox();
            this.btnSelecionar = new System.Windows.Forms.Button();
            this.txtCriterio = new System.Windows.Forms.TextBox();
            this.lblCriterio = new System.Windows.Forms.Label();
            this.rbCódigo = new System.Windows.Forms.RadioButton();
            this.rbNome = new System.Windows.Forms.RadioButton();
            this.gbDados = new System.Windows.Forms.GroupBox();
            this.btnAlterar = new System.Windows.Forms.Button();
            this.cbxProf1 = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.cbxProf0 = new System.Windows.Forms.ComboBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cbxAluno2 = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.cbxAluno1 = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cbxAluno0 = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.btnEscolher = new System.Windows.Forms.Button();
            this.rbTodos = new System.Windows.Forms.RadioButton();
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).BeginInit();
            this.gbOpcoes.SuspendLayout();
            this.gbCriterios.SuspendLayout();
            this.gbDados.SuspendLayout();
            this.SuspendLayout();
            // 
            // dgvDados
            // 
            this.dgvDados.AllowUserToAddRows = false;
            this.dgvDados.AllowUserToDeleteRows = false;
            this.dgvDados.AllowUserToOrderColumns = true;
            this.dgvDados.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvDados.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.codProjeto,
            this.nomeProjeto,
            this.descProjeto,
            this.anoProjeto,
            this.alunosProjeto,
            this.profProjeto});
            this.dgvDados.Location = new System.Drawing.Point(12, 229);
            this.dgvDados.Name = "dgvDados";
            this.dgvDados.ReadOnly = true;
            this.dgvDados.Size = new System.Drawing.Size(681, 250);
            this.dgvDados.TabIndex = 0;
            // 
            // codProjeto
            // 
            this.codProjeto.HeaderText = "Código do Projeto";
            this.codProjeto.Name = "codProjeto";
            this.codProjeto.ReadOnly = true;
            // 
            // nomeProjeto
            // 
            this.nomeProjeto.HeaderText = "Nome do Projeto";
            this.nomeProjeto.Name = "nomeProjeto";
            this.nomeProjeto.ReadOnly = true;
            // 
            // descProjeto
            // 
            this.descProjeto.HeaderText = "Descrição";
            this.descProjeto.Name = "descProjeto";
            this.descProjeto.ReadOnly = true;
            // 
            // anoProjeto
            // 
            this.anoProjeto.HeaderText = "Ano";
            this.anoProjeto.Name = "anoProjeto";
            this.anoProjeto.ReadOnly = true;
            // 
            // alunosProjeto
            // 
            this.alunosProjeto.HeaderText = "Alunos";
            this.alunosProjeto.Name = "alunosProjeto";
            this.alunosProjeto.ReadOnly = true;
            // 
            // profProjeto
            // 
            this.profProjeto.HeaderText = "Professores";
            this.profProjeto.Name = "profProjeto";
            this.profProjeto.ReadOnly = true;
            // 
            // gbOpcoes
            // 
            this.gbOpcoes.Controls.Add(this.rbTodos);
            this.gbOpcoes.Controls.Add(this.btnEscolher);
            this.gbOpcoes.Controls.Add(this.rbDeletar);
            this.gbOpcoes.Controls.Add(this.rbSelecionar);
            this.gbOpcoes.Controls.Add(this.rbInserir);
            this.gbOpcoes.Controls.Add(this.rbAlterar);
            this.gbOpcoes.Location = new System.Drawing.Point(12, 11);
            this.gbOpcoes.Name = "gbOpcoes";
            this.gbOpcoes.Size = new System.Drawing.Size(200, 168);
            this.gbOpcoes.TabIndex = 1;
            this.gbOpcoes.TabStop = false;
            this.gbOpcoes.Text = "Selecione uma opção....";
            // 
            // rbDeletar
            // 
            this.rbDeletar.AutoSize = true;
            this.rbDeletar.Location = new System.Drawing.Point(15, 88);
            this.rbDeletar.Name = "rbDeletar";
            this.rbDeletar.Size = new System.Drawing.Size(108, 17);
            this.rbDeletar.TabIndex = 5;
            this.rbDeletar.Text = "Excluir um projeto";
            this.rbDeletar.UseVisualStyleBackColor = true;
            // 
            // rbSelecionar
            // 
            this.rbSelecionar.AutoSize = true;
            this.rbSelecionar.Checked = true;
            this.rbSelecionar.Location = new System.Drawing.Point(15, 19);
            this.rbSelecionar.Name = "rbSelecionar";
            this.rbSelecionar.Size = new System.Drawing.Size(127, 17);
            this.rbSelecionar.TabIndex = 2;
            this.rbSelecionar.TabStop = true;
            this.rbSelecionar.Text = "Selecionar um projeto";
            this.rbSelecionar.UseVisualStyleBackColor = true;
            // 
            // rbInserir
            // 
            this.rbInserir.AutoSize = true;
            this.rbInserir.Location = new System.Drawing.Point(15, 65);
            this.rbInserir.Name = "rbInserir";
            this.rbInserir.Size = new System.Drawing.Size(105, 17);
            this.rbInserir.TabIndex = 4;
            this.rbInserir.Text = "Inserir um projeto";
            this.rbInserir.UseVisualStyleBackColor = true;
            // 
            // rbAlterar
            // 
            this.rbAlterar.AutoSize = true;
            this.rbAlterar.Location = new System.Drawing.Point(15, 42);
            this.rbAlterar.Name = "rbAlterar";
            this.rbAlterar.Size = new System.Drawing.Size(107, 17);
            this.rbAlterar.TabIndex = 3;
            this.rbAlterar.Text = "Alterar um projeto";
            this.rbAlterar.UseVisualStyleBackColor = true;
            // 
            // gbCriterios
            // 
            this.gbCriterios.Controls.Add(this.btnSelecionar);
            this.gbCriterios.Controls.Add(this.txtCriterio);
            this.gbCriterios.Controls.Add(this.lblCriterio);
            this.gbCriterios.Controls.Add(this.rbCódigo);
            this.gbCriterios.Controls.Add(this.rbNome);
            this.gbCriterios.Location = new System.Drawing.Point(218, 11);
            this.gbCriterios.Name = "gbCriterios";
            this.gbCriterios.Size = new System.Drawing.Size(200, 168);
            this.gbCriterios.TabIndex = 2;
            this.gbCriterios.TabStop = false;
            this.gbCriterios.Text = "Selecione por um critério....";
            // 
            // btnSelecionar
            // 
            this.btnSelecionar.Location = new System.Drawing.Point(49, 139);
            this.btnSelecionar.Name = "btnSelecionar";
            this.btnSelecionar.Size = new System.Drawing.Size(75, 23);
            this.btnSelecionar.TabIndex = 6;
            this.btnSelecionar.Text = "Enviar";
            this.btnSelecionar.UseVisualStyleBackColor = true;
            this.btnSelecionar.Click += new System.EventHandler(this.btnSelecionar_Click);
            // 
            // txtCriterio
            // 
            this.txtCriterio.Location = new System.Drawing.Point(15, 104);
            this.txtCriterio.Name = "txtCriterio";
            this.txtCriterio.Size = new System.Drawing.Size(179, 20);
            this.txtCriterio.TabIndex = 5;
            // 
            // lblCriterio
            // 
            this.lblCriterio.AutoSize = true;
            this.lblCriterio.Location = new System.Drawing.Point(12, 88);
            this.lblCriterio.Name = "lblCriterio";
            this.lblCriterio.Size = new System.Drawing.Size(84, 13);
            this.lblCriterio.TabIndex = 4;
            this.lblCriterio.Text = "Valor do Critério:";
            // 
            // rbCódigo
            // 
            this.rbCódigo.AutoSize = true;
            this.rbCódigo.Location = new System.Drawing.Point(15, 22);
            this.rbCódigo.Name = "rbCódigo";
            this.rbCódigo.Size = new System.Drawing.Size(109, 17);
            this.rbCódigo.TabIndex = 2;
            this.rbCódigo.TabStop = true;
            this.rbCódigo.Text = "Código do Projeto";
            this.rbCódigo.UseVisualStyleBackColor = true;
            // 
            // rbNome
            // 
            this.rbNome.AutoSize = true;
            this.rbNome.Location = new System.Drawing.Point(15, 54);
            this.rbNome.Name = "rbNome";
            this.rbNome.Size = new System.Drawing.Size(104, 17);
            this.rbNome.TabIndex = 3;
            this.rbNome.TabStop = true;
            this.rbNome.Text = "Nome do Projeto";
            this.rbNome.UseVisualStyleBackColor = true;
            // 
            // gbDados
            // 
            this.gbDados.Controls.Add(this.btnAlterar);
            this.gbDados.Controls.Add(this.cbxProf1);
            this.gbDados.Controls.Add(this.label6);
            this.gbDados.Controls.Add(this.cbxProf0);
            this.gbDados.Controls.Add(this.label5);
            this.gbDados.Controls.Add(this.cbxAluno2);
            this.gbDados.Controls.Add(this.label4);
            this.gbDados.Controls.Add(this.cbxAluno1);
            this.gbDados.Controls.Add(this.label3);
            this.gbDados.Controls.Add(this.cbxAluno0);
            this.gbDados.Controls.Add(this.label2);
            this.gbDados.Controls.Add(this.textBox1);
            this.gbDados.Controls.Add(this.label1);
            this.gbDados.Location = new System.Drawing.Point(424, 11);
            this.gbDados.Name = "gbDados";
            this.gbDados.Size = new System.Drawing.Size(269, 212);
            this.gbDados.TabIndex = 3;
            this.gbDados.TabStop = false;
            this.gbDados.Text = "Preencha as informações abaixo:";
            // 
            // btnAlterar
            // 
            this.btnAlterar.Location = new System.Drawing.Point(85, 183);
            this.btnAlterar.Name = "btnAlterar";
            this.btnAlterar.Size = new System.Drawing.Size(75, 23);
            this.btnAlterar.TabIndex = 7;
            this.btnAlterar.Text = "Alterar";
            this.btnAlterar.UseVisualStyleBackColor = true;
            this.btnAlterar.Click += new System.EventHandler(this.btnAlterar_Click);
            // 
            // cbxProf1
            // 
            this.cbxProf1.FormattingEnabled = true;
            this.cbxProf1.Location = new System.Drawing.Point(109, 152);
            this.cbxProf1.Name = "cbxProf1";
            this.cbxProf1.Size = new System.Drawing.Size(121, 21);
            this.cbxProf1.TabIndex = 15;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(15, 155);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(63, 13);
            this.label6.TabIndex = 14;
            this.label6.Text = "Professor 2:";
            // 
            // cbxProf0
            // 
            this.cbxProf0.FormattingEnabled = true;
            this.cbxProf0.Location = new System.Drawing.Point(109, 125);
            this.cbxProf0.Name = "cbxProf0";
            this.cbxProf0.Size = new System.Drawing.Size(121, 21);
            this.cbxProf0.TabIndex = 13;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(15, 128);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(63, 13);
            this.label5.TabIndex = 12;
            this.label5.Text = "Professor 1:";
            // 
            // cbxAluno2
            // 
            this.cbxAluno2.FormattingEnabled = true;
            this.cbxAluno2.Location = new System.Drawing.Point(109, 98);
            this.cbxAluno2.Name = "cbxAluno2";
            this.cbxAluno2.Size = new System.Drawing.Size(121, 21);
            this.cbxAluno2.TabIndex = 11;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(15, 101);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(46, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "Aluno 3:";
            // 
            // cbxAluno1
            // 
            this.cbxAluno1.FormattingEnabled = true;
            this.cbxAluno1.Location = new System.Drawing.Point(109, 71);
            this.cbxAluno1.Name = "cbxAluno1";
            this.cbxAluno1.Size = new System.Drawing.Size(121, 21);
            this.cbxAluno1.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(15, 74);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(46, 13);
            this.label3.TabIndex = 8;
            this.label3.Text = "Aluno 2:";
            // 
            // cbxAluno0
            // 
            this.cbxAluno0.FormattingEnabled = true;
            this.cbxAluno0.Location = new System.Drawing.Point(109, 44);
            this.cbxAluno0.Name = "cbxAluno0";
            this.cbxAluno0.Size = new System.Drawing.Size(121, 21);
            this.cbxAluno0.TabIndex = 7;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(15, 47);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(46, 13);
            this.label2.TabIndex = 6;
            this.label2.Text = "Aluno 1:";
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(109, 18);
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(121, 20);
            this.textBox1.TabIndex = 5;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(15, 22);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 4;
            this.label1.Text = "Nome do projeto:";
            // 
            // btnEscolher
            // 
            this.btnEscolher.Location = new System.Drawing.Point(47, 139);
            this.btnEscolher.Name = "btnEscolher";
            this.btnEscolher.Size = new System.Drawing.Size(75, 23);
            this.btnEscolher.TabIndex = 6;
            this.btnEscolher.Text = "Escolher";
            this.btnEscolher.UseVisualStyleBackColor = true;
            this.btnEscolher.Click += new System.EventHandler(this.btnEscolher_Click);
            // 
            // rbTodos
            // 
            this.rbTodos.AutoSize = true;
            this.rbTodos.Location = new System.Drawing.Point(15, 112);
            this.rbTodos.Name = "rbTodos";
            this.rbTodos.Size = new System.Drawing.Size(158, 17);
            this.rbTodos.TabIndex = 7;
            this.rbTodos.TabStop = true;
            this.rbTodos.Text = "Selecionar todos os projetos";
            this.rbTodos.UseVisualStyleBackColor = true;
            // 
            // frmPrincipal
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(716, 539);
            this.Controls.Add(this.gbDados);
            this.Controls.Add(this.gbCriterios);
            this.Controls.Add(this.gbOpcoes);
            this.Controls.Add(this.dgvDados);
            this.Name = "frmPrincipal";
            this.Text = "Iniciando....";
            this.Load += new System.EventHandler(this.frmPrincipal_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgvDados)).EndInit();
            this.gbOpcoes.ResumeLayout(false);
            this.gbOpcoes.PerformLayout();
            this.gbCriterios.ResumeLayout(false);
            this.gbCriterios.PerformLayout();
            this.gbDados.ResumeLayout(false);
            this.gbDados.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataGridView dgvDados;
        private System.Windows.Forms.GroupBox gbOpcoes;
        private System.Windows.Forms.RadioButton rbDeletar;
        private System.Windows.Forms.RadioButton rbSelecionar;
        private System.Windows.Forms.RadioButton rbInserir;
        private System.Windows.Forms.RadioButton rbAlterar;
        private System.Windows.Forms.GroupBox gbCriterios;
        private System.Windows.Forms.TextBox txtCriterio;
        private System.Windows.Forms.Label lblCriterio;
        private System.Windows.Forms.RadioButton rbCódigo;
        private System.Windows.Forms.RadioButton rbNome;
        private System.Windows.Forms.GroupBox gbDados;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DataGridViewTextBoxColumn codProjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn nomeProjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn descProjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn anoProjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn alunosProjeto;
        private System.Windows.Forms.DataGridViewTextBoxColumn profProjeto;
        private System.Windows.Forms.Button btnSelecionar;
        private System.Windows.Forms.Button btnAlterar;
        private System.Windows.Forms.ComboBox cbxProf1;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox cbxProf0;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cbxAluno2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox cbxAluno1;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox cbxAluno0;
        private System.Windows.Forms.Button btnEscolher;
        private System.Windows.Forms.RadioButton rbTodos;
    }
}

