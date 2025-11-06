namespace Pim3Semestre
{
    partial class EditarUsuario
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
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label7 = new Label();
            label1 = new Label();
            txbxCPF = new MaskedTextBox();
            txbxEmail = new TextBox();
            txbxSenha = new TextBox();
            txbxNomeUsuario = new TextBox();
            btnSalvar = new Button();
            SuspendLayout();
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label10.Location = new Point(33, 299);
            label10.Name = "label10";
            label10.Size = new Size(37, 21);
            label10.TabIndex = 19;
            label10.Text = "CPF";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label9.Location = new Point(33, 228);
            label9.Name = "label9";
            label9.Size = new Size(48, 21);
            label9.TabIndex = 18;
            label9.Text = "Email";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label8.Location = new Point(33, 164);
            label8.Name = "label8";
            label8.Size = new Size(53, 21);
            label8.TabIndex = 17;
            label8.Text = "Senha";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label7.Location = new Point(33, 99);
            label7.Name = "label7";
            label7.Size = new Size(53, 21);
            label7.TabIndex = 16;
            label7.Text = "Nome";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 18F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(33, 26);
            label1.Name = "label1";
            label1.Size = new Size(150, 32);
            label1.TabIndex = 15;
            label1.Text = "Editar perfil";
            // 
            // txbxCPF
            // 
            txbxCPF.Location = new Point(33, 319);
            txbxCPF.Mask = "000\\.000\\.000\\-00";
            txbxCPF.Name = "txbxCPF";
            txbxCPF.ReadOnly = true;
            txbxCPF.Size = new Size(337, 23);
            txbxCPF.TabIndex = 14;
            // 
            // txbxEmail
            // 
            txbxEmail.Location = new Point(33, 252);
            txbxEmail.Name = "txbxEmail";
            txbxEmail.Size = new Size(337, 23);
            txbxEmail.TabIndex = 13;
            // 
            // txbxSenha
            // 
            txbxSenha.Location = new Point(33, 188);
            txbxSenha.Name = "txbxSenha";
            txbxSenha.Size = new Size(337, 23);
            txbxSenha.TabIndex = 12;
            // 
            // txbxNomeUsuario
            // 
            txbxNomeUsuario.Location = new Point(33, 123);
            txbxNomeUsuario.Name = "txbxNomeUsuario";
            txbxNomeUsuario.Size = new Size(337, 23);
            txbxNomeUsuario.TabIndex = 11;
            // 
            // btnSalvar
            // 
            btnSalvar.Location = new Point(246, 380);
            btnSalvar.Name = "btnSalvar";
            btnSalvar.Size = new Size(124, 43);
            btnSalvar.TabIndex = 20;
            btnSalvar.Text = "Salvar dados";
            btnSalvar.UseVisualStyleBackColor = true;
            btnSalvar.Click += btnSalvar_Click;
            // 
            // EditarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(404, 451);
            Controls.Add(btnSalvar);
            Controls.Add(label10);
            Controls.Add(label9);
            Controls.Add(label8);
            Controls.Add(label7);
            Controls.Add(label1);
            Controls.Add(txbxCPF);
            Controls.Add(txbxEmail);
            Controls.Add(txbxSenha);
            Controls.Add(txbxNomeUsuario);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "EditarUsuario";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "EditarUsuario";
            Load += EditarUsuario_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label10;
        private Label label9;
        private Label label8;
        private Label label7;
        private Label label1;
        private MaskedTextBox txbxCPF;
        private TextBox txbxEmail;
        private TextBox txbxSenha;
        private TextBox txbxNomeUsuario;
        private Button btnSalvar;
    }
}