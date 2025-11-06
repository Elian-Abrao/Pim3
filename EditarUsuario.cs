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
    public partial class EditarUsuario : Form
    {
        private Usuario usuario;
        public EditarUsuario(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
        }

        private void btnSalvar_Click(object sender, EventArgs e)
        {
            using (var conexao = util.Banco.AbrirConexao())
            {
                try
                {
       

                    string query = util.Banco.Queries.SalvarEditarPerfil;

                    using (var cmd = new NpgsqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("nome", txbxNomeUsuario.Text);
                        cmd.Parameters.AddWithValue("email", txbxEmail.Text);
                        cmd.Parameters.AddWithValue("senha", util.ValidarDados.GerarHash(txbxSenha.Text)); // Senha atualizada já com hash!

                        cmd.Parameters.AddWithValue("cpf", usuario.CPF); // Usa o CPF salvo no objeto Usuario!

                        int linhasAfetadas = cmd.ExecuteNonQuery();

                        if (linhasAfetadas > 0)
                        {
                            MessageBox.Show("Dados atualizados com sucesso! dados serão atualizados da próxima vez que logar", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            this.Close();
                        }
                        else
                        {
                            MessageBox.Show("Nenhum dado foi atualizado. Verifique o CPF!", "Atenção", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }

                    conexao.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao atualizar dados: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void EditarUsuario_Load(object sender, EventArgs e)
        {
            txbxNomeUsuario.Text = usuario.Nome;
            txbxEmail.Text = usuario.Email;
            txbxSenha.Text = usuario.Senha;
            txbxCPF.Text = usuario.CPF;
        }
    }
}
