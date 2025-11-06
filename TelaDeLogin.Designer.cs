namespace Pim3Semestre
{
    partial class TelaDeLogin
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            UserTxBx = new TextBox();
            panel1 = new Panel();
            CPFTxBx = new MaskedTextBox();
            lblCPF = new Label();
            lblEmail = new Label();
            label2 = new Label();
            label1 = new Label();
            EmailTxBx = new TextBox();
            BtnRegistro = new Button();
            BtnLogin = new Button();
            TextoLogin = new Label();
            PassWordTxBx = new TextBox();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // UserTxBx
            // 
            UserTxBx.Location = new Point(45, 201);
            UserTxBx.Name = "UserTxBx";
            UserTxBx.Size = new Size(283, 23);
            UserTxBx.TabIndex = 1;
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(CPFTxBx);
            panel1.Controls.Add(lblCPF);
            panel1.Controls.Add(lblEmail);
            panel1.Controls.Add(label2);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(EmailTxBx);
            panel1.Controls.Add(BtnRegistro);
            panel1.Controls.Add(BtnLogin);
            panel1.Controls.Add(TextoLogin);
            panel1.Controls.Add(PassWordTxBx);
            panel1.Controls.Add(UserTxBx);
            panel1.Dock = DockStyle.Right;
            panel1.ImeMode = ImeMode.NoControl;
            panel1.Location = new Point(603, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(364, 598);
            panel1.TabIndex = 0;
            // 
            // CPFTxBx
            // 
            CPFTxBx.Location = new Point(46, 418);
            CPFTxBx.Mask = "000\\.000\\.000\\-00";
            CPFTxBx.Name = "CPFTxBx";
            CPFTxBx.Size = new Size(282, 23);
            CPFTxBx.TabIndex = 4;
            CPFTxBx.Visible = false;
            // 
            // lblCPF
            // 
            lblCPF.AutoSize = true;
            lblCPF.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblCPF.Location = new Point(45, 400);
            lblCPF.Name = "lblCPF";
            lblCPF.Size = new Size(27, 15);
            lblCPF.TabIndex = 10;
            lblCPF.Text = "CPF";
            lblCPF.Visible = false;
            // 
            // lblEmail
            // 
            lblEmail.AutoSize = true;
            lblEmail.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblEmail.Location = new Point(45, 328);
            lblEmail.Name = "lblEmail";
            lblEmail.Size = new Size(36, 15);
            lblEmail.TabIndex = 9;
            lblEmail.Text = "Email";
            lblEmail.Visible = false;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label2.Location = new Point(45, 254);
            label2.Name = "label2";
            label2.Size = new Size(41, 15);
            label2.TabIndex = 8;
            label2.Text = "Senha";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(45, 183);
            label1.Name = "label1";
            label1.Size = new Size(101, 15);
            label1.TabIndex = 7;
            label1.Text = "Nome de usuario";
            // 
            // EmailTxBx
            // 
            EmailTxBx.Location = new Point(45, 346);
            EmailTxBx.Name = "EmailTxBx";
            EmailTxBx.Size = new Size(283, 23);
            EmailTxBx.TabIndex = 3;
            EmailTxBx.Visible = false;
            // 
            // BtnRegistro
            // 
            BtnRegistro.BackColor = Color.Coral;
            BtnRegistro.Location = new Point(159, 470);
            BtnRegistro.Name = "BtnRegistro";
            BtnRegistro.Size = new Size(81, 42);
            BtnRegistro.TabIndex = 5;
            BtnRegistro.Text = "Registrar-se";
            BtnRegistro.UseVisualStyleBackColor = false;
            BtnRegistro.Click += BtnRegistro_Click;
            // 
            // BtnLogin
            // 
            BtnLogin.BackColor = Color.LimeGreen;
            BtnLogin.Cursor = Cursors.Hand;
            BtnLogin.Location = new Point(246, 470);
            BtnLogin.Name = "BtnLogin";
            BtnLogin.Size = new Size(82, 42);
            BtnLogin.TabIndex = 6;
            BtnLogin.Text = "Logar";
            BtnLogin.UseVisualStyleBackColor = false;
            BtnLogin.Click += BtnLogin_Click;
            // 
            // TextoLogin
            // 
            TextoLogin.AutoSize = true;
            TextoLogin.Font = new Font("Segoe UI Black", 30F);
            TextoLogin.Location = new Point(45, 92);
            TextoLogin.Name = "TextoLogin";
            TextoLogin.RightToLeft = RightToLeft.No;
            TextoLogin.Size = new Size(133, 54);
            TextoLogin.TabIndex = 0;
            TextoLogin.Text = "Login";
            // 
            // PassWordTxBx
            // 
            PassWordTxBx.AccessibleName = "";
            PassWordTxBx.Location = new Point(45, 272);
            PassWordTxBx.Name = "PassWordTxBx";
            PassWordTxBx.Size = new Size(283, 23);
            PassWordTxBx.TabIndex = 2;
            // 
            // TelaDeLogin
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            AutoValidate = AutoValidate.EnablePreventFocusChange;
            BackColor = SystemColors.ControlDark;
            ClientSize = new Size(967, 598);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "TelaDeLogin";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Tela de login";
            Load += Form1_Load;
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ResumeLayout(false);
        }

        #endregion

        private TextBox UserTxBx;
        private Panel panel1;
        private Button BtnLogin;
        private Label TextoLogin;
        private TextBox PassWordTxBx;
        private Button BtnRegistro;
        private TextBox EmailTxBx;
        private Label label1;
        private Label lblCPF;
        private Label lblEmail;
        private Label label2;
        private MaskedTextBox CPFTxBx;
    }
}
