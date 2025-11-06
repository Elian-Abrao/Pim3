namespace Pim3Semestre
{
    partial class CriarUsuario
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            txbxCriarUser = new TextBox();
            txbxCriarPass = new TextBox();
            txbxCriarCPF = new MaskedTextBox();
            txbxCriarEmail = new TextBox();
            cbbxCargo = new ComboBox();
            txbxCriarNivel = new TextBox();
            button1 = new Button();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label1.Location = new Point(25, 59);
            label1.Name = "label1";
            label1.Size = new Size(57, 21);
            label1.TabIndex = 0;
            label1.Text = "Nome";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label2.Location = new Point(25, 119);
            label2.Name = "label2";
            label2.Size = new Size(57, 21);
            label2.TabIndex = 1;
            label2.Text = "Senha";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label3.Location = new Point(25, 185);
            label3.Name = "label3";
            label3.Size = new Size(38, 21);
            label3.TabIndex = 2;
            label3.Text = "CPF";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label4.Location = new Point(25, 248);
            label4.Name = "label4";
            label4.Size = new Size(53, 21);
            label4.TabIndex = 3;
            label4.Text = "Email";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label5.Location = new Point(25, 372);
            label5.Name = "label5";
            label5.Size = new Size(51, 21);
            label5.TabIndex = 4;
            label5.Text = "Nivel";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 12F, FontStyle.Bold);
            label6.Location = new Point(25, 314);
            label6.Name = "label6";
            label6.Size = new Size(55, 21);
            label6.TabIndex = 5;
            label6.Text = "Cargo";
            // 
            // txbxCriarUser
            // 
            txbxCriarUser.Location = new Point(25, 83);
            txbxCriarUser.Name = "txbxCriarUser";
            txbxCriarUser.Size = new Size(412, 23);
            txbxCriarUser.TabIndex = 6;
            // 
            // txbxCriarPass
            // 
            txbxCriarPass.Location = new Point(25, 143);
            txbxCriarPass.Name = "txbxCriarPass";
            txbxCriarPass.Size = new Size(412, 23);
            txbxCriarPass.TabIndex = 7;
            // 
            // txbxCriarCPF
            // 
            txbxCriarCPF.Location = new Point(25, 209);
            txbxCriarCPF.Name = "txbxCriarCPF";
            txbxCriarCPF.Size = new Size(412, 23);
            txbxCriarCPF.TabIndex = 8;
            // 
            // txbxCriarEmail
            // 
            txbxCriarEmail.Location = new Point(25, 272);
            txbxCriarEmail.Name = "txbxCriarEmail";
            txbxCriarEmail.Size = new Size(412, 23);
            txbxCriarEmail.TabIndex = 9;
            // 
            // cbbxCargo
            // 
            cbbxCargo.DropDownStyle = ComboBoxStyle.DropDownList;
            cbbxCargo.FormattingEnabled = true;
            cbbxCargo.Items.AddRange(new object[] { "usuario", "Suporte", "Admin" });
            cbbxCargo.Location = new Point(25, 338);
            cbbxCargo.Name = "cbbxCargo";
            cbbxCargo.Size = new Size(412, 23);
            cbbxCargo.TabIndex = 10;
            cbbxCargo.SelectedIndexChanged += cbbxCargo_SelectedIndexChanged;
            // 
            // txbxCriarNivel
            // 
            txbxCriarNivel.Enabled = false;
            txbxCriarNivel.Location = new Point(25, 396);
            txbxCriarNivel.Name = "txbxCriarNivel";
            txbxCriarNivel.Size = new Size(412, 23);
            txbxCriarNivel.TabIndex = 11;
            // 
            // button1
            // 
            button1.Location = new Point(340, 500);
            button1.Name = "button1";
            button1.Size = new Size(97, 48);
            button1.TabIndex = 12;
            button1.Text = "Criar";
            button1.UseVisualStyleBackColor = true;
            button1.Click += button1_Click;
            // 
            // CriarUsuario
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(458, 569);
            Controls.Add(button1);
            Controls.Add(txbxCriarNivel);
            Controls.Add(cbbxCargo);
            Controls.Add(txbxCriarEmail);
            Controls.Add(txbxCriarCPF);
            Controls.Add(txbxCriarPass);
            Controls.Add(txbxCriarUser);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "CriarUsuario";
            Text = "CriarUsuario";
            Load += CriarUsuario_Load_1;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private TextBox txbxCriarUser;
        private TextBox txbxCriarPass;
        private MaskedTextBox txbxCriarCPF;
        private TextBox txbxCriarEmail;
        private ComboBox cbbxCargo;
        private TextBox txbxCriarNivel;
        private Button button1;
    }
}