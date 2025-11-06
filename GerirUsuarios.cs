using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using Npgsql;
using Pim3Semestre.util;

namespace Pim3Semestre
{
    public partial class GerirUsuarios : Form
    {
        private bool emEdicao = false;

        public GerirUsuarios()
        {
            InitializeComponent();

        }
        private void GerirUsuarios_Load_1(object sender, EventArgs e)
        {

            CarregarUsuarios();

        }


        private void CarregarUsuarios()
        {
            pnlUsuarios.Controls.Clear();

            using var conexao = Banco.AbrirConexao();
            string query = util.Banco.Queries.PuxarDado;

            using var cmd = new NpgsqlCommand(query, conexao);
            using var reader = cmd.ExecuteReader();

            int y = 10;

            while (reader.Read())
            {
                int idUsuario = Convert.ToInt32(reader["id"]);

                Panel card = new Panel
                {
                    BorderStyle = BorderStyle.FixedSingle,
                    Size = new Size(pnlUsuarios.Width - 30, 150),
                    Location = new Point(10, y),
                    Tag = idUsuario
                };

                TextBox txtNome = CriarTextBox(card, "Nome:", reader["nome"].ToString(), 10, 10);
                TextBox txtEmail = CriarTextBox(card, "Email:", reader["email"].ToString(), 10, 40);
                TextBox txtCPF = CriarTextBox(card, "CPF:", reader["cpf"].ToString(), 10, 70);
                TextBox txtCargo = CriarTextBox(card, "Cargo:", reader["cargo"].ToString(), 10, 100);
                TextBox txtNivel = CriarTextBox(card, "Nível:", reader["nivel"].ToString(), 250, 100);

                Button btnEditar = new Button
                {
                    Text = "Editar",
                    Location = new Point(card.Width - 220, 10),
                    Width = 90
                };

                Button btnSalvar = new Button
                {
                    Text = "Salvar",
                    Location = new Point(card.Width - 220, 10),
                    Width = 90,
                    Visible = false
                };

                Button btnApagar = new Button
                {
                    Text = "Apagar",
                    Location = new Point(card.Width - 120, 10),
                    Width = 90
                };

                btnEditar.Click += (s, e) =>
                {
                    if (emEdicao)
                    {
                        MessageBox.Show("Finalize a edição atual antes de editar outro usuário.");
                        return;
                    }

                    txtNome.ReadOnly = txtEmail.ReadOnly = txtCPF.ReadOnly = txtCargo.ReadOnly = txtNivel.ReadOnly = false;
                    btnEditar.Visible = false;
                    btnSalvar.Visible = true;
                    btnApagar.Visible = false;
                    emEdicao = true;
                };

                btnSalvar.Click += (s, e) =>
                {
                    using var conexao2 = Banco.AbrirConexao();
                    string updateQuery = util.Banco.Queries.AtualizarUsuario;

                    using var cmdUpdate = new NpgsqlCommand(updateQuery, conexao2);
                    cmdUpdate.Parameters.AddWithValue("nome", txtNome.Text);
                    cmdUpdate.Parameters.AddWithValue("email", txtEmail.Text);
                    cmdUpdate.Parameters.AddWithValue("cpf", txtCPF.Text);
                    cmdUpdate.Parameters.AddWithValue("cargo", txtCargo.Text);

                    // aqui, nível pode ser nulo:
                    if (int.TryParse(txtNivel.Text, out var nivel))
                        cmdUpdate.Parameters.AddWithValue("nivel", nivel);
                    else
                        cmdUpdate.Parameters.AddWithValue("nivel", DBNull.Value);

                    cmdUpdate.Parameters.AddWithValue("id", idUsuario);
                    cmdUpdate.ExecuteNonQuery();

                    // volta leitura apenas
                    txtNome.ReadOnly = txtEmail.ReadOnly = txtCPF.ReadOnly = txtCargo.ReadOnly = txtNivel.ReadOnly = true;
                    btnEditar.Visible = true;
                    btnSalvar.Visible = false;
                    btnApagar.Visible = true;
                    emEdicao = false;

                    MessageBox.Show("Usuário atualizado com sucesso!");
                };

                btnApagar.Click += (s, e) =>
                {
                    var confirm = MessageBox.Show("Deseja mesmo excluir este usuário?", "Confirmação", MessageBoxButtons.YesNo);
                    if (confirm == DialogResult.Yes)
                    {
                        using var conexao2 = Banco.AbrirConexao();
                        string deleteQuery = util.Banco.Queries.DeletarUsuario;

                        using var cmdDelete = new NpgsqlCommand(deleteQuery, conexao2);
                        cmdDelete.Parameters.AddWithValue("id", idUsuario);
                        cmdDelete.ExecuteNonQuery();

                        pnlUsuarios.Controls.Remove(card);
                        MessageBox.Show("Usuário excluído com sucesso!");
                    }
                };

                card.Controls.Add(btnEditar);
                card.Controls.Add(btnSalvar);
                card.Controls.Add(btnApagar);

                pnlUsuarios.Controls.Add(card);
                y += card.Height + 10;
            }
        }

        private TextBox CriarTextBox(Panel container, string label, string valor, int x, int y)
        {
            Label lbl = new Label
            {
                Text = label,
                Location = new Point(x, y),
                AutoSize = true
            };

            TextBox txt = new TextBox
            {
                Text = valor,
                Location = new Point(x + 60, y - 3),
                Width = 160,
                ReadOnly = true
            };

            container.Controls.Add(lbl);
            container.Controls.Add(txt);
            return txt;
        }

        private void BntNovoUsuario_Click(object sender, EventArgs e)
        {
            CriarUsuario criarUsuario = new CriarUsuario();
            criarUsuario.ShowDialog();
        }

        private void bntNovoUsuario_Click_1(object sender, EventArgs e)
        {
            CriarUsuario criarUsuario = new CriarUsuario();
            criarUsuario.ShowDialog();
        }
    }
}
