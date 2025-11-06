namespace Pim3Semestre
{
    partial class GerirUsuarios
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
            bntNovoUsuario = new Button();
            pnlUsuarios = new Panel();
            SuspendLayout();
            // 
            // bntNovoUsuario
            // 
            bntNovoUsuario.Location = new Point(678, 12);
            bntNovoUsuario.Name = "bntNovoUsuario";
            bntNovoUsuario.Size = new Size(123, 45);
            bntNovoUsuario.TabIndex = 0;
            bntNovoUsuario.Text = "Adicionar usuario";
            bntNovoUsuario.UseVisualStyleBackColor = true;
            bntNovoUsuario.Click += bntNovoUsuario_Click_1;
            // 
            // pnlUsuarios
            // 
            pnlUsuarios.AutoScroll = true;
            pnlUsuarios.BorderStyle = BorderStyle.FixedSingle;
            pnlUsuarios.Dock = DockStyle.Bottom;
            pnlUsuarios.Location = new Point(0, 86);
            pnlUsuarios.Name = "pnlUsuarios";
            pnlUsuarios.Size = new Size(813, 501);
            pnlUsuarios.TabIndex = 1;
            // 
            // GerirUsuarios
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(813, 587);
            Controls.Add(pnlUsuarios);
            Controls.Add(bntNovoUsuario);
            FormBorderStyle = FormBorderStyle.FixedToolWindow;
            Name = "GerirUsuarios";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "GerirUsuarios";
            Load += GerirUsuarios_Load_1;
            ResumeLayout(false);
        }

        #endregion

        private Button bntNovoUsuario;
        private Panel pnlUsuarios;
    }
}