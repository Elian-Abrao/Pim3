namespace Pim3Semestre
{
    partial class HomePage
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            panel1 = new Panel();
            button5 = new Button();
            lblBemVindo = new Label();
            btnLogoff = new Button();
            BtnCriarUsuario = new Button();
            button2 = new Button();
            btnEditarPerfil = new Button();
            pictureBox1 = new PictureBox();
            tabControl1 = new TabControl();
            Inicio = new TabPage();
            tabNovoChamado = new TabPage();
            PnlHelp = new Panel();
            EnviarChamadoPadrao = new Button();
            txbxSugestao = new TextBox();
            lblsubTitulo = new Label();
            lblRespostaIA = new Label();
            panel3 = new Panel();
            label1 = new Label();
            btnEnviarChamado = new Button();
            lblPrioridade = new Label();
            cmbxPrioridade = new ComboBox();
            txbxDescr = new TextBox();
            lblDescr = new Label();
            txbxTitulo = new TextBox();
            label3 = new Label();
            label2 = new Label();
            comboBox1 = new ComboBox();
            PaginaOcultaChamados = new TabPage();
            panelListaChamados = new Panel();
            cardTemplate = new Panel();
            lblChamadosCriticos = new Label();
            lblChamadosAbertos = new Label();
            lblChamadosFechados = new Label();
            label6 = new Label();
            label5 = new Label();
            label4 = new Label();
            Titulo = new Label();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            tabControl1.SuspendLayout();
            tabNovoChamado.SuspendLayout();
            PnlHelp.SuspendLayout();
            panel3.SuspendLayout();
            PaginaOcultaChamados.SuspendLayout();
            panelListaChamados.SuspendLayout();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = Color.FromArgb(224, 224, 224);
            panel1.Controls.Add(button5);
            panel1.Controls.Add(lblBemVindo);
            panel1.Controls.Add(btnLogoff);
            panel1.Controls.Add(BtnCriarUsuario);
            panel1.Controls.Add(button2);
            panel1.Controls.Add(btnEditarPerfil);
            panel1.Controls.Add(pictureBox1);
            panel1.Dock = DockStyle.Left;
            panel1.Location = new Point(0, 0);
            panel1.Margin = new Padding(3, 4, 3, 4);
            panel1.Name = "panel1";
            panel1.Size = new Size(335, 845);
            panel1.TabIndex = 0;
            panel1.Paint += panel1_Paint;
            // 
            // button5
            // 
            button5.BackColor = Color.Transparent;
            button5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button5.Location = new Point(14, 553);
            button5.Margin = new Padding(3, 4, 3, 4);
            button5.Name = "button5";
            button5.Size = new Size(297, 59);
            button5.TabIndex = 5;
            button5.Text = "Criar chamado";
            button5.UseVisualStyleBackColor = false;
            button5.Click += button5_Click;
            // 
            // lblBemVindo
            // 
            lblBemVindo.Anchor = AnchorStyles.Top | AnchorStyles.Bottom;
            lblBemVindo.AutoSize = true;
            lblBemVindo.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblBemVindo.ImageAlign = ContentAlignment.TopCenter;
            lblBemVindo.Location = new Point(14, 241);
            lblBemVindo.MaximumSize = new Size(297, 107);
            lblBemVindo.Name = "lblBemVindo";
            lblBemVindo.Size = new Size(159, 41);
            lblBemVindo.TabIndex = 4;
            lblBemVindo.Text = "Bem vindo";
            lblBemVindo.TextAlign = ContentAlignment.TopCenter;
            lblBemVindo.Click += lblBemVindo_Click;
            // 
            // btnLogoff
            // 
            btnLogoff.BackColor = Color.Transparent;
            btnLogoff.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnLogoff.ImageAlign = ContentAlignment.BottomCenter;
            btnLogoff.Location = new Point(14, 757);
            btnLogoff.Margin = new Padding(3, 4, 3, 4);
            btnLogoff.Name = "btnLogoff";
            btnLogoff.Size = new Size(297, 59);
            btnLogoff.TabIndex = 3;
            btnLogoff.Text = "Deslogar";
            btnLogoff.UseVisualStyleBackColor = false;
            btnLogoff.Click += button4_Click;
            // 
            // BtnCriarUsuario
            // 
            BtnCriarUsuario.BackColor = Color.Transparent;
            BtnCriarUsuario.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            BtnCriarUsuario.Location = new Point(14, 633);
            BtnCriarUsuario.Margin = new Padding(3, 4, 3, 4);
            BtnCriarUsuario.Name = "BtnCriarUsuario";
            BtnCriarUsuario.Size = new Size(297, 59);
            BtnCriarUsuario.TabIndex = 2;
            BtnCriarUsuario.Text = "Gerir usuários";
            BtnCriarUsuario.UseVisualStyleBackColor = false;
            BtnCriarUsuario.Click += BtnCriarUsuario_Click;
            // 
            // button2
            // 
            button2.BackColor = Color.Transparent;
            button2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            button2.Location = new Point(14, 472);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(297, 59);
            button2.TabIndex = 1;
            button2.Text = "Chamados";
            button2.UseVisualStyleBackColor = false;
            button2.Click += button2_Click;
            // 
            // btnEditarPerfil
            // 
            btnEditarPerfil.BackColor = Color.Transparent;
            btnEditarPerfil.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            btnEditarPerfil.Location = new Point(14, 377);
            btnEditarPerfil.Margin = new Padding(3, 4, 3, 4);
            btnEditarPerfil.Name = "btnEditarPerfil";
            btnEditarPerfil.Size = new Size(297, 59);
            btnEditarPerfil.TabIndex = 0;
            btnEditarPerfil.Text = "Editar perfil";
            btnEditarPerfil.UseVisualStyleBackColor = false;
            btnEditarPerfil.Click += button1_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackgroundImage = Properties.Resources.Logo;
            pictureBox1.BackgroundImageLayout = ImageLayout.Zoom;
            pictureBox1.Location = new Point(-39, -29);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(392, 375);
            pictureBox1.TabIndex = 6;
            pictureBox1.TabStop = false;
            pictureBox1.UseWaitCursor = true;
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(Inicio);
            tabControl1.Controls.Add(tabNovoChamado);
            tabControl1.Controls.Add(PaginaOcultaChamados);
            tabControl1.Dock = DockStyle.Left;
            tabControl1.Location = new Point(335, 0);
            tabControl1.Margin = new Padding(3, 4, 3, 4);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(1067, 845);
            tabControl1.TabIndex = 1;
            // 
            // Inicio
            // 
            Inicio.Location = new Point(4, 29);
            Inicio.Margin = new Padding(3, 4, 3, 4);
            Inicio.Name = "Inicio";
            Inicio.Padding = new Padding(3, 4, 3, 4);
            Inicio.Size = new Size(1059, 812);
            Inicio.TabIndex = 0;
            Inicio.Text = "Página inicial";
            Inicio.UseVisualStyleBackColor = true;
            // 
            // tabNovoChamado
            // 
            tabNovoChamado.BackColor = Color.White;
            tabNovoChamado.Controls.Add(PnlHelp);
            tabNovoChamado.Controls.Add(panel3);
            tabNovoChamado.Location = new Point(4, 29);
            tabNovoChamado.Margin = new Padding(3, 4, 3, 4);
            tabNovoChamado.Name = "tabNovoChamado";
            tabNovoChamado.Padding = new Padding(3, 4, 3, 4);
            tabNovoChamado.Size = new Size(1059, 812);
            tabNovoChamado.TabIndex = 2;
            tabNovoChamado.Text = "Novo chamado";
            // 
            // PnlHelp
            // 
            PnlHelp.BackColor = Color.FromArgb(224, 224, 224);
            PnlHelp.Controls.Add(EnviarChamadoPadrao);
            PnlHelp.Controls.Add(txbxSugestao);
            PnlHelp.Controls.Add(lblsubTitulo);
            PnlHelp.Controls.Add(lblRespostaIA);
            PnlHelp.Location = new Point(529, 15);
            PnlHelp.Margin = new Padding(3, 4, 3, 4);
            PnlHelp.Name = "PnlHelp";
            PnlHelp.Size = new Size(488, 783);
            PnlHelp.TabIndex = 10;
            PnlHelp.Visible = false;
            // 
            // EnviarChamadoPadrao
            // 
            EnviarChamadoPadrao.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            EnviarChamadoPadrao.Location = new Point(270, 680);
            EnviarChamadoPadrao.Margin = new Padding(3, 4, 3, 4);
            EnviarChamadoPadrao.Name = "EnviarChamadoPadrao";
            EnviarChamadoPadrao.Size = new Size(191, 73);
            EnviarChamadoPadrao.TabIndex = 13;
            EnviarChamadoPadrao.Text = "Confirmar envio";
            EnviarChamadoPadrao.UseVisualStyleBackColor = true;
            EnviarChamadoPadrao.Click += EnviarChamadoPadrao_Click;
            // 
            // txbxSugestao
            // 
            txbxSugestao.Enabled = false;
            txbxSugestao.Font = new Font("Segoe UI Emoji", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            txbxSugestao.Location = new Point(50, 180);
            txbxSugestao.Margin = new Padding(3, 4, 3, 4);
            txbxSugestao.Multiline = true;
            txbxSugestao.Name = "txbxSugestao";
            txbxSugestao.Size = new Size(385, 341);
            txbxSugestao.TabIndex = 12;
            txbxSugestao.Visible = false;
            // 
            // lblsubTitulo
            // 
            lblsubTitulo.AutoSize = true;
            lblsubTitulo.Font = new Font("Segoe UI", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            lblsubTitulo.Location = new Point(50, 128);
            lblsubTitulo.Name = "lblsubTitulo";
            lblsubTitulo.Size = new Size(183, 32);
            lblsubTitulo.TabIndex = 11;
            lblsubTitulo.Text = "Você ja tentou...";
            lblsubTitulo.Visible = false;
            // 
            // lblRespostaIA
            // 
            lblRespostaIA.AutoSize = true;
            lblRespostaIA.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblRespostaIA.Location = new Point(50, 33);
            lblRespostaIA.Name = "lblRespostaIA";
            lblRespostaIA.Size = new Size(427, 50);
            lblRespostaIA.TabIndex = 10;
            lblRespostaIA.Text = "Resposta gerada por IA";
            lblRespostaIA.Visible = false;
            // 
            // panel3
            // 
            panel3.BackColor = Color.FromArgb(224, 224, 224);
            panel3.Controls.Add(label1);
            panel3.Controls.Add(btnEnviarChamado);
            panel3.Controls.Add(lblPrioridade);
            panel3.Controls.Add(cmbxPrioridade);
            panel3.Controls.Add(txbxDescr);
            panel3.Controls.Add(lblDescr);
            panel3.Controls.Add(txbxTitulo);
            panel3.Controls.Add(label3);
            panel3.Controls.Add(label2);
            panel3.Controls.Add(comboBox1);
            panel3.Location = new Point(9, 15);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(488, 783);
            panel3.TabIndex = 1;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(80, 128);
            label1.Name = "label1";
            label1.Size = new Size(229, 32);
            label1.TabIndex = 10;
            label1.Text = "Titulo do chamado";
            label1.Click += label1_Click;
            // 
            // btnEnviarChamado
            // 
            btnEnviarChamado.Font = new Font("Segoe UI Black", 24F, FontStyle.Bold, GraphicsUnit.Point, 0);
            btnEnviarChamado.Location = new Point(80, 668);
            btnEnviarChamado.Margin = new Padding(3, 4, 3, 4);
            btnEnviarChamado.Name = "btnEnviarChamado";
            btnEnviarChamado.Size = new Size(342, 77);
            btnEnviarChamado.TabIndex = 9;
            btnEnviarChamado.Text = "Abrir chamado";
            btnEnviarChamado.UseVisualStyleBackColor = true;
            btnEnviarChamado.Click += btnEnviarChamado_Click;
            // 
            // lblPrioridade
            // 
            lblPrioridade.AutoSize = true;
            lblPrioridade.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblPrioridade.Location = new Point(80, 575);
            lblPrioridade.Name = "lblPrioridade";
            lblPrioridade.Size = new Size(282, 32);
            lblPrioridade.TabIndex = 8;
            lblPrioridade.Text = "Prioridade do chamado";
            lblPrioridade.Visible = false;
            // 
            // cmbxPrioridade
            // 
            cmbxPrioridade.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbxPrioridade.FormattingEnabled = true;
            cmbxPrioridade.Items.AddRange(new object[] { "Crítica", "Alta", "Média", "Baixa" });
            cmbxPrioridade.Location = new Point(80, 612);
            cmbxPrioridade.Margin = new Padding(3, 4, 3, 4);
            cmbxPrioridade.Name = "cmbxPrioridade";
            cmbxPrioridade.Size = new Size(341, 28);
            cmbxPrioridade.TabIndex = 7;
            cmbxPrioridade.Visible = false;
            // 
            // txbxDescr
            // 
            txbxDescr.Location = new Point(80, 388);
            txbxDescr.Margin = new Padding(3, 4, 3, 4);
            txbxDescr.Multiline = true;
            txbxDescr.Name = "txbxDescr";
            txbxDescr.Size = new Size(341, 157);
            txbxDescr.TabIndex = 6;
            txbxDescr.Visible = false;
            // 
            // lblDescr
            // 
            lblDescr.AutoSize = true;
            lblDescr.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblDescr.Location = new Point(80, 351);
            lblDescr.Name = "lblDescr";
            lblDescr.Size = new Size(273, 32);
            lblDescr.TabIndex = 5;
            lblDescr.Text = "Descrição do chamado";
            lblDescr.Visible = false;
            // 
            // txbxTitulo
            // 
            txbxTitulo.Location = new Point(80, 168);
            txbxTitulo.Margin = new Padding(3, 4, 3, 4);
            txbxTitulo.Name = "txbxTitulo";
            txbxTitulo.Size = new Size(341, 27);
            txbxTitulo.TabIndex = 4;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label3.Location = new Point(80, 245);
            label3.Name = "label3";
            label3.Size = new Size(244, 32);
            label3.TabIndex = 2;
            label3.Text = "Motivo do chamado";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 21.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(80, 33);
            label2.Name = "label2";
            label2.Size = new Size(390, 50);
            label2.TabIndex = 1;
            label2.Text = "Abrir novo chamado ";
            // 
            // comboBox1
            // 
            comboBox1.DropDownStyle = ComboBoxStyle.DropDownList;
            comboBox1.FormattingEnabled = true;
            comboBox1.Items.AddRange(new object[] { "Problemas com o mouse", "Problemas com som", "Problema com vídeo", "Problemas com a internet", "Outros" });
            comboBox1.Location = new Point(80, 283);
            comboBox1.Margin = new Padding(3, 4, 3, 4);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(341, 28);
            comboBox1.TabIndex = 0;
            comboBox1.SelectedIndexChanged += comboBox1_SelectedIndexChanged;
            // 
            // PaginaOcultaChamados
            // 
            PaginaOcultaChamados.Controls.Add(panelListaChamados);
            PaginaOcultaChamados.Controls.Add(lblChamadosCriticos);
            PaginaOcultaChamados.Controls.Add(lblChamadosAbertos);
            PaginaOcultaChamados.Controls.Add(lblChamadosFechados);
            PaginaOcultaChamados.Controls.Add(label6);
            PaginaOcultaChamados.Controls.Add(label5);
            PaginaOcultaChamados.Controls.Add(label4);
            PaginaOcultaChamados.Location = new Point(4, 29);
            PaginaOcultaChamados.Margin = new Padding(3, 4, 3, 4);
            PaginaOcultaChamados.Name = "PaginaOcultaChamados";
            PaginaOcultaChamados.Padding = new Padding(3, 4, 3, 4);
            PaginaOcultaChamados.Size = new Size(1059, 812);
            PaginaOcultaChamados.TabIndex = 3;
            PaginaOcultaChamados.Text = "Chamados";
            PaginaOcultaChamados.UseVisualStyleBackColor = true;
            PaginaOcultaChamados.Click += PaginaOcultaChamados_Click;
            // 
            // panelListaChamados
            // 
            panelListaChamados.AutoScroll = true;
            panelListaChamados.BackColor = Color.Transparent;
            panelListaChamados.BackgroundImageLayout = ImageLayout.None;
            panelListaChamados.Controls.Add(cardTemplate);
            panelListaChamados.Location = new Point(9, 129);
            panelListaChamados.Margin = new Padding(3, 4, 3, 4);
            panelListaChamados.Name = "panelListaChamados";
            panelListaChamados.Size = new Size(1038, 667);
            panelListaChamados.TabIndex = 7;
            // 
            // cardTemplate
            // 
            cardTemplate.BackColor = SystemColors.ScrollBar;
            cardTemplate.Location = new Point(3, 4);
            cardTemplate.Margin = new Padding(3, 4, 3, 4);
            cardTemplate.Name = "cardTemplate";
            cardTemplate.Size = new Size(1017, 159);
            cardTemplate.TabIndex = 6;
            cardTemplate.Visible = false;
            // 
            // lblChamadosCriticos
            // 
            lblChamadosCriticos.AutoSize = true;
            lblChamadosCriticos.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold);
            lblChamadosCriticos.Location = new Point(914, 59);
            lblChamadosCriticos.Name = "lblChamadosCriticos";
            lblChamadosCriticos.Size = new Size(72, 60);
            lblChamadosCriticos.TabIndex = 5;
            lblChamadosCriticos.Text = "12";
            // 
            // lblChamadosAbertos
            // 
            lblChamadosAbertos.AutoSize = true;
            lblChamadosAbertos.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold);
            lblChamadosAbertos.Location = new Point(505, 59);
            lblChamadosAbertos.Name = "lblChamadosAbertos";
            lblChamadosAbertos.Size = new Size(72, 60);
            lblChamadosAbertos.TabIndex = 4;
            lblChamadosAbertos.Text = "12";
            // 
            // lblChamadosFechados
            // 
            lblChamadosFechados.AutoSize = true;
            lblChamadosFechados.Font = new Font("Segoe UI Black", 26.25F, FontStyle.Bold);
            lblChamadosFechados.Location = new Point(123, 59);
            lblChamadosFechados.Name = "lblChamadosFechados";
            lblChamadosFechados.Size = new Size(72, 60);
            lblChamadosFechados.TabIndex = 3;
            lblChamadosFechados.Text = "12";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label6.Location = new Point(840, 25);
            label6.Name = "label6";
            label6.Size = new Size(225, 32);
            label6.TabIndex = 2;
            label6.Text = "Chamados Críticos";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label5.Location = new Point(432, 25);
            label5.Name = "label5";
            label5.Size = new Size(230, 32);
            label5.TabIndex = 1;
            label5.Text = "Chamados Abertos";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 14.25F, FontStyle.Bold);
            label4.Location = new Point(51, 25);
            label4.Name = "label4";
            label4.Size = new Size(244, 32);
            label4.TabIndex = 0;
            label4.Text = "Chamados Fechados";
            // 
            // Titulo
            // 
            Titulo.Location = new Point(0, 0);
            Titulo.Name = "Titulo";
            Titulo.Size = new Size(100, 23);
            Titulo.TabIndex = 0;
            // 
            // HomePage
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1400, 845);
            Controls.Add(tabControl1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Margin = new Padding(3, 4, 3, 4);
            Name = "HomePage";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Página Inicial";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            tabControl1.ResumeLayout(false);
            tabNovoChamado.ResumeLayout(false);
            PnlHelp.ResumeLayout(false);
            PnlHelp.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            PaginaOcultaChamados.ResumeLayout(false);
            PaginaOcultaChamados.PerformLayout();
            panelListaChamados.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Button btnLogoff;
        private Button BtnCriarUsuario;
        private Button button2;
        private Button btnEditarPerfil;
        private Label lblBemVindo;
        private TabControl tabControl1;
        private TabPage Inicio;
        private Button button5;
        private TabPage tabNovoChamado;
        private ComboBox comboBox1;
        private Panel panel3;
        private Label label2;
        private TextBox txbxDescr;
        private Label lblDescr;
        private TextBox txbxTitulo;
        private Label Titulo;
        private Label label3;
        private Button btnEnviarChamado;
        private Label lblPrioridade;
        private ComboBox cmbxPrioridade;
        private Panel PnlHelp;
        private Button EnviarChamadoPadrao;
        private TextBox txbxSugestao;
        private Label lblsubTitulo;
        private Label lblRespostaIA;
        private Label lblChamadosCriticos;
        private Label lblChamadosAbertos;
        private Label lblChamadosFechados;
        private Label label6;
        private Label label5;
        private Label label4;
        private Panel cardTemplate;
        private Panel panelListaChamados;
        private TabPage PaginaOcultaChamados;
        private PictureBox pictureBox1;
        private Label label1;
    }
}