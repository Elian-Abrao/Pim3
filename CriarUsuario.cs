using System;
using System.Windows.Forms;
using Npgsql;
using Pim3Semestre.util;

namespace Pim3Semestre
{
    public partial class CriarUsuario : Form
    {
        public CriarUsuario()
        {
            InitializeComponent();

            // Vincula eventos
            cbbxCargo.SelectedIndexChanged += cbbxCargo_SelectedIndexChanged;
            txbxCriarNivel.KeyPress += txbxCriarNivel_KeyPress;
        }


        private void cbbxCargo_SelectedIndexChanged(object sender, EventArgs e)
        {
            // se for Suporte, libera o nível, caso contrário limpa e desabilita
            bool isSuporte = cbbxCargo.SelectedItem?.ToString() == "Suporte";
            txbxCriarNivel.Enabled = isSuporte;
            if (!isSuporte)
                txbxCriarNivel.Text = "";
        }

        private void txbxCriarNivel_KeyPress(object sender, KeyPressEventArgs e)
        {
            // permite apenas dígitos e teclas de controle (backspace, etc)
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
                e.Handled = true;
        }

        private void CriarUsuario_Load_1(object sender, EventArgs e)
        {
            // Máscara de CPF
            txbxCriarCPF.Mask = "000\\.000\\.000\\-00";

            // Nível só habilitado para Suporte
            txbxCriarNivel.Enabled = false;

            // Popula cargos (exemplo)
            cbbxCargo.Items.Clear();
            cbbxCargo.Items.Add("usuario");
            cbbxCargo.Items.Add("Suporte");
            cbbxCargo.Items.Add("admin");
            cbbxCargo.SelectedIndex = 0;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // validações básicas
            if (string.IsNullOrWhiteSpace(txbxCriarUser.Text) ||
                string.IsNullOrWhiteSpace(txbxCriarPass.Text) ||
                string.IsNullOrWhiteSpace(txbxCriarEmail.Text) ||
                !txbxCriarEmail.Text.Contains("@") ||
                !txbxCriarEmail.Text.Contains(".") ||
                !txbxCriarCPF.MaskFull)
            {
                MessageBox.Show("Preencha todos os campos obrigatórios corretamente.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // se for Suporte, o nível é obrigatório
            if (cbbxCargo.SelectedItem.ToString() == "Suporte" &&
                string.IsNullOrWhiteSpace(txbxCriarNivel.Text))
            {
                MessageBox.Show("Por favor, informe o nível para o cargo Suporte.",
                                "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // tudo validado, vamos inserir no banco
            try
            {
                using var conn = Banco.AbrirConexao();
                string sql = util.Banco.Queries.inserirUsuario;
                using var cmd = new NpgsqlCommand(sql, conn);
                cmd.Parameters.AddWithValue("cpf", txbxCriarCPF.Text.Replace(".", "").Replace("-", ""));
                cmd.Parameters.AddWithValue("nome", txbxCriarUser.Text.Trim());
                cmd.Parameters.AddWithValue("email", txbxCriarEmail.Text.Trim());
                cmd.Parameters.AddWithValue("senha", util.ValidarDados.GerarHash(txbxCriarPass.Text));
                cmd.Parameters.AddWithValue("cargo", cbbxCargo.SelectedItem.ToString());
                if (txbxCriarNivel.Enabled)
                    cmd.Parameters.AddWithValue("nivel", int.Parse(txbxCriarNivel.Text));
                else
                    cmd.Parameters.AddWithValue("nivel", DBNull.Value);
                cmd.ExecuteNonQuery();

                MessageBox.Show("Usuário criado com sucesso!",
                                "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Erro ao criar usuário: " + ex.Message,
                                "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
