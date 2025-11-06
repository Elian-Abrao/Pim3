using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Npgsql;
using Pim3Semestre.util;

namespace Pim3Semestre
{
    public partial class Chat : Form
    {
        private readonly int idChamadoAtual;
        private readonly Usuario usuario;
        private bool chamadoFechado;

        public Chat(int idChamado, Usuario usuarioLogado)
        {
            InitializeComponent();
            idChamadoAtual = idChamado;
            usuario = usuarioLogado;
        }
        private void Chat_Load(object sender, EventArgs e)
        {
            CarregarStatusChamado();
            CarregarMensagens();
            flowMensagens.FlowDirection = FlowDirection.TopDown;
            flowMensagens.WrapContents = false;
            flowMensagens.AutoScroll = true;

            lblStatus.Text = (chamadoFechado ? "Chamado fechado" : "Chamado aberto") + $" - #{idChamadoAtual}";
            if (lblStatus.Text == "Chamado fechado")
            {
                txtMensagem.Enabled = false;
                btnEnviar.Enabled = false;
            }

            btnFecharReabrir.Text = chamadoFechado ? "Reabrir Chamado" : "Fechar Chamado";
            btnFecharReabrir.Visible = usuario.Cargo != "usuario";
        }

        private void CarregarMensagens()
        {
            flowMensagens.Controls.Clear();

            using var conexao = Banco.AbrirConexao();
            string query = util.Banco.Queries.CarregarMensagens;

            using var cmd = new NpgsqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("idChamado", idChamadoAtual);

            using var reader = cmd.ExecuteReader();
            while (reader.Read())
            {
                string nome = reader["nome"].ToString();
                string mensagem = reader["mensagem"].ToString();
                DateTime data = Convert.ToDateTime(reader["data_envio"]);
                // ...
                int idRemetente = Convert.ToInt32(reader["remetente_id"]);
                bool isUsuario = idRemetente == usuario.id;
                AdicionarMensagem(nome, mensagem, data, isUsuario);

            }
        }

        private void CarregarStatusChamado()
        {
            using var conexao = Banco.AbrirConexao();
            string query = util.Banco.Queries.CarregarStatus;
            using var cmd = new NpgsqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("id", idChamadoAtual);
            chamadoFechado = Convert.ToBoolean(cmd.ExecuteScalar());
        }

        private void AdicionarMensagem(string nome, string mensagem, DateTime data, bool isUsuario)
        {
            int larguraMaxima = flowMensagens.ClientSize.Width - 40;
            int larguraMensagem = (int)(larguraMaxima * 0.65);

            // Cria o painel da bolha de mensagem
            Panel msgPanel = new Panel
            {
                BackColor = isUsuario ? Color.LightGreen : Color.LightBlue,
                Padding = new Padding(8),
                Margin = new Padding(0),
                AutoSize = true,
                MaximumSize = new Size(larguraMensagem, 0),
                Anchor = AnchorStyles.Left | AnchorStyles.Right
            };

            Label lblInfo = new Label
            {
                Text = $"{nome} - {data:dd/MM/yyyy HH:mm}",
                Font = new Font("Segoe UI", 8, FontStyle.Italic),
                AutoSize = true
            };

            Label lblMsg = new Label
            {
                Text = mensagem,
                Font = new Font("Segoe UI", 10),
                AutoSize = true,
                MaximumSize = new Size(larguraMensagem - 20, 0)
            };

            msgPanel.Controls.Add(lblInfo);
            msgPanel.Controls.Add(lblMsg);
            lblMsg.Location = new Point(0, lblInfo.Bottom + 5);

            // Wrapper para ocupar 100% da largura e posicionar o msgPanel corretamente
            Panel linha = new Panel
            {
                Width = flowMensagens.ClientSize.Width - 25,
                Height = msgPanel.PreferredSize.Height + 10,
                Padding = new Padding(0),
                Margin = new Padding(5),
                BackColor = Color.Transparent
            };

            msgPanel.Location = isUsuario
                ? new Point(linha.Width - msgPanel.PreferredSize.Width - 10, 0)
                : new Point(10, 0);

            linha.Controls.Add(msgPanel);
            flowMensagens.Controls.Add(linha);
            flowMensagens.ScrollControlIntoView(linha);
        }

        private void btnEnviar_Click_1(object sender, EventArgs e)
        {
            if (chamadoFechado)
            {
                MessageBox.Show("Chamado fechado. Você não pode enviar mensagens.");
                return;
            }

            string texto = txtMensagem.Text.Trim();
            if (string.IsNullOrEmpty(texto)) return;

            using var conexao = Banco.AbrirConexao();
            string query = util.Banco.Queries.EnviarMensagem;
            using var cmd = new NpgsqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("idChamado", idChamadoAtual);
            cmd.Parameters.AddWithValue("idUsuario", usuario.id);
            cmd.Parameters.AddWithValue("mensagem", texto);
            cmd.Parameters.AddWithValue("data", DateTime.Now);
            cmd.ExecuteNonQuery();

            // **Sempre** passo 'true' aqui: a mensagem que eu acabo de enviar é do usuário logado
            AdicionarMensagem(usuario.Nome, texto, DateTime.Now, true);

            txtMensagem.Text = "";
        }

        private void btnFecharReabrir_Click_1(object sender, EventArgs e)
        {
            using var conexao = Banco.AbrirConexao();
            bool novoStatus = !chamadoFechado;

            string query = novoStatus
                ? util.Banco.Queries.FecharChamado
                : util.Banco.Queries.ReabrirChamado;

            using var cmd = new NpgsqlCommand(query, conexao);
            cmd.Parameters.AddWithValue("id", idChamadoAtual);

            if (novoStatus)
            {
                cmd.Parameters.AddWithValue("resolvidoPor", usuario.id);
                cmd.Parameters.AddWithValue("data", DateTime.Now);
            }

            cmd.ExecuteNonQuery();

            chamadoFechado = novoStatus;

            lblStatus.Text = (chamadoFechado ? "Chamado fechado" : "Chamado aberto") + $" - #{idChamadoAtual}";
            btnFecharReabrir.Text = chamadoFechado ? "Reabrir Chamado" : "Fechar Chamado";

            txtMensagem.Enabled = !chamadoFechado;
            btnEnviar.Enabled = !chamadoFechado;
        }

        private void txtMensagem_TextChanged(object sender, EventArgs e)
        {

        }

        private void txtMensagem_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true; 
                btnEnviar.PerformClick();
            }
        }
    }
}
