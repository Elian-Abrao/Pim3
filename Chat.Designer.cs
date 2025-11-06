namespace Pim3Semestre
{
    partial class Chat
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
            flowMensagens = new FlowLayoutPanel();
            txtMensagem = new TextBox();
            btnEnviar = new Button();
            lblStatus = new Label();
            btnFecharReabrir = new Button();
            SuspendLayout();
            // 
            // flowMensagens
            // 
            flowMensagens.Anchor = AnchorStyles.None;
            flowMensagens.Location = new Point(12, 49);
            flowMensagens.Name = "flowMensagens";
            flowMensagens.Size = new Size(578, 555);
            flowMensagens.TabIndex = 0;
            // 
            // txtMensagem
            // 
            txtMensagem.Location = new Point(12, 610);
            txtMensagem.Name = "txtMensagem";
            txtMensagem.Size = new Size(469, 23);
            txtMensagem.TabIndex = 1;
            txtMensagem.KeyPress += txtMensagem_KeyPress;
            // 
            // btnEnviar
            // 
            btnEnviar.Location = new Point(487, 609);
            btnEnviar.Name = "btnEnviar";
            btnEnviar.Size = new Size(103, 24);
            btnEnviar.TabIndex = 2;
            btnEnviar.Text = "Enviar";
            btnEnviar.UseVisualStyleBackColor = true;
            btnEnviar.Click += btnEnviar_Click_1;
            // 
            // lblStatus
            // 
            lblStatus.AutoSize = true;
            lblStatus.Font = new Font("Segoe UI", 15.75F, FontStyle.Bold, GraphicsUnit.Point, 0);
            lblStatus.Location = new Point(12, 9);
            lblStatus.Name = "lblStatus";
            lblStatus.Size = new Size(72, 30);
            lblStatus.TabIndex = 3;
            lblStatus.Text = "label1";
            // 
            // btnFecharReabrir
            // 
            btnFecharReabrir.Location = new Point(496, 9);
            btnFecharReabrir.Name = "btnFecharReabrir";
            btnFecharReabrir.Size = new Size(94, 30);
            btnFecharReabrir.TabIndex = 4;
            btnFecharReabrir.Text = "button1";
            btnFecharReabrir.UseVisualStyleBackColor = true;
            btnFecharReabrir.Click += btnFecharReabrir_Click_1;
            // 
            // Chat
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(602, 645);
            Controls.Add(btnFecharReabrir);
            Controls.Add(lblStatus);
            Controls.Add(btnEnviar);
            Controls.Add(txtMensagem);
            Controls.Add(flowMensagens);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "Chat";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Chat";
            Load += Chat_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private FlowLayoutPanel flowMensagens;
        private TextBox txtMensagem;
        private Button btnEnviar;
        private Label lblStatus;
        private Button btnFecharReabrir;
    }
}