using System;
using System.Windows.Forms;
using Npgsql;
using System.Security.Cryptography;
using System.Text;

namespace Pim3Semestre
{
    public partial class TelaDeLogin : Form
    {
        private bool modoRegistro = false;

        public TelaDeLogin()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            PassWordTxBx.PasswordChar = '*'; // Senha oculta
            CPFTxBx.Mask = "000\\.000\\.000\\-00"; // Máscara CPF
        }

        private void BtnRegistro_Click(object sender, EventArgs e)
        {
            modoRegistro = !modoRegistro;

            TextoLogin.Text = modoRegistro ? "Registro" : "Login";
            BtnLogin.Text = modoRegistro ? "Criar conta" : "Entrar";
            BtnRegistro.Text = modoRegistro ? "Logar" : "Registrar-se";

            EmailTxBx.Visible = modoRegistro;
            CPFTxBx.Visible = modoRegistro;
            lblEmail.Visible = modoRegistro;
            lblCPF.Visible = modoRegistro;
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            if (modoRegistro)
            {
                RegistrarUsuario();
            }
            else
            {
                FazerLogin();
            }
        }

        private void RegistrarUsuario()
        {
            if (!util.ValidarDados.ValidarEmail(EmailTxBx.Text))
            {
                MessageBox.Show("Email inválido!", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (!util.ValidarDados.ValidarCPF(CPFTxBx.Text))
            {
                MessageBox.Show("CPF inválido! Deve ter 11 dígitos.", "Erro de validação", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conexao = util.Banco.AbrirConexao())
            {
                try
                {
                    // Verificar se já existe usuário
                    string queryCheck = util.Banco.Queries.VerificarUsuarioExistente;

                    using (var cmdCheck = new NpgsqlCommand(queryCheck, conexao))
                    {
                        cmdCheck.Parameters.AddWithValue("cpf", CPFTxBx.Text.Replace(".", "").Replace("-", ""));
                        cmdCheck.Parameters.AddWithValue("email", EmailTxBx.Text);
                        cmdCheck.Parameters.AddWithValue("nome", UserTxBx.Text);

                        var existe = cmdCheck.ExecuteScalar();

                        if (existe != null)
                        {
                            MessageBox.Show("CPF, email ou nome já cadastrado!", "Erro de Registro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Inserir novo usuário
                    string queryInsert = util.Banco.Queries.InserirUsuario;

                    using (var cmdInsert = new NpgsqlCommand(queryInsert, conexao))
                    {
                        cmdInsert.Parameters.AddWithValue("cpf", CPFTxBx.Text.Replace(".", "").Replace("-", ""));
                        cmdInsert.Parameters.AddWithValue("nome", UserTxBx.Text);
                        cmdInsert.Parameters.AddWithValue("email", EmailTxBx.Text);
                        cmdInsert.Parameters.AddWithValue("usuario", "usuario");
                        cmdInsert.Parameters.AddWithValue("senha", util.ValidarDados.GerarHash(PassWordTxBx.Text));

                        cmdInsert.ExecuteNonQuery();
                        MessageBox.Show("Conta criada com sucesso!", "Registro Completo", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpa campos
                        CPFTxBx.Text = "";
                        UserTxBx.Text = "";
                        EmailTxBx.Text = "";
                        PassWordTxBx.Text = "";

                        // Volta pro modo login
                        BtnRegistro_Click(null, null);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao registrar: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void FazerLogin()
        {
            if (string.IsNullOrWhiteSpace(UserTxBx.Text) || string.IsNullOrWhiteSpace(PassWordTxBx.Text))
            {
                MessageBox.Show("Preencha todos os campos antes de fazer login.", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (var conexao = util.Banco.AbrirConexao())
            {
                try
                {
                    string query = util.Banco.Queries.LoginUsuario;

                    using (var cmd = new NpgsqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("nome", UserTxBx.Text);
                        cmd.Parameters.AddWithValue("Senha", util.ValidarDados.GerarHash(PassWordTxBx.Text));

                        using (var reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                var usuario = new util.Usuario
                                {
                                    id = Convert.ToInt32(reader["id"]),
                                    CPF = reader["cpf"].ToString(),
                                    Nome = reader["nome"].ToString(),
                                    Email = reader["email"].ToString(),
                                    Cargo = reader["cargo"].ToString(),
                                    Senha = PassWordTxBx.Text,
                                    Nivel = reader["nivel"] != DBNull.Value ? Convert.ToInt32(reader["nivel"]) : 0

                                };

                                this.Hide();
                                HomePage home = new HomePage(usuario);
                                home.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("Nome de usuário ou senha incorretos!", "Erro de login", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao fazer login: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }



        private void CPFTxBx_TextChanged(object sender, EventArgs e)
        {
            // Não precisa fazer nada aqui no momento.
        }
    }
}
