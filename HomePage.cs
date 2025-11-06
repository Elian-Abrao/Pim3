using System.Text;
using Npgsql;
using System.Security.Cryptography;
using Pim3Semestre.util;

namespace Pim3Semestre
{
    public partial class HomePage : Form
    {
        private Usuario usuario;
        private TabPage PaginaAbrirChamadoOculta;


        public HomePage(Usuario usuario)
        {
            InitializeComponent();
            this.usuario = usuario;
            PaginaAbrirChamadoOculta = tabNovoChamado;
            tabControl1.TabPages.Remove(PaginaAbrirChamadoOculta);
            tabControl1.TabPages.Remove(PaginaOcultaChamados);
        }



        private void HomePage_FormClosed(object sender, FormClosedEventArgs e)
        {
            Application.Exit();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            lblBemVindo.Text = $"Bem-vindo, {usuario.Nome}!";


            if (usuario.Cargo != "Admin")
            {
                BtnCriarUsuario.Visible = false;
            }
            else
            {
                BtnCriarUsuario.Visible = true;
            }
        }

        private void lblBemVindo_Click(object sender, EventArgs e)
        {

        }

        private int ContarChamadosAbertos()
        {
            using var conexao = util.Banco.AbrirConexao();
            string query = usuario.Cargo == "usuario"
                ? util.Banco.Queries.contarAbertos
                : util.Banco.Queries.contarAbertosAdmin;

            using var cmd = new NpgsqlCommand(query, conexao);
            if (usuario.Cargo == "usuario")
                cmd.Parameters.AddWithValue("id", usuario.id);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int ContarChamadosFechados()
        {
            using var conexao = util.Banco.AbrirConexao();
            string query = usuario.Cargo == "usuario"
                ? util.Banco.Queries.contarFechados
                : util.Banco.Queries.contarFechadosAdmin;

            using var cmd = new NpgsqlCommand(query, conexao);
            if (usuario.Cargo == "usuario")
                cmd.Parameters.AddWithValue("id", usuario.id);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }

        private int ContarChamadosCriticos()
        {
            using var conexao = util.Banco.AbrirConexao();
            string query = usuario.Cargo == "usuario"
                ? util.Banco.Queries.contarCriticos
                : util.Banco.Queries.contarCriticosAdmin;

            using var cmd = new NpgsqlCommand(query, conexao);
            if (usuario.Cargo == "usuario")
                cmd.Parameters.AddWithValue("id", usuario.id);

            return Convert.ToInt32(cmd.ExecuteScalar());
        }


        // AREA DO MENU LATERAL ----------------------------------------------------------------
        private void button1_Click(object sender, EventArgs e) // mostrar a parte de editar perfil
        {
            EditarUsuario editarUsuario = new EditarUsuario(usuario); // <- passa o usuário logado aqui
            editarUsuario.ShowDialog();
        }


        private void button5_Click(object sender, EventArgs e) // mostrar a parte de criar chamado
        {
            if (!tabControl1.TabPages.Contains(PaginaAbrirChamadoOculta))
            {
                tabControl1.TabPages.Add(PaginaAbrirChamadoOculta);
                tabControl1.SelectedTab = PaginaAbrirChamadoOculta;
            }
            else
            {
                tabControl1.TabPages.Remove(PaginaAbrirChamadoOculta);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (!tabControl1.TabPages.Contains(PaginaOcultaChamados))
            {
                tabControl1.TabPages.Add(PaginaOcultaChamados);
                tabControl1.SelectedTab = PaginaOcultaChamados;
                CarregarChamados();

                lblChamadosAbertos.Text = ContarChamadosAbertos().ToString();
                lblChamadosFechados.Text = ContarChamadosFechados().ToString();
                lblChamadosCriticos.Text = ContarChamadosCriticos().ToString();
            }
            else
            {
                tabControl1.TabPages.Remove(PaginaOcultaChamados);
            }
        }

        private void button4_Click(object sender, EventArgs e) // deslogar
        {
            DialogResult resultado = MessageBox.Show("Deseja realmente sair?", "Sair", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (resultado == DialogResult.Yes)
            {

                this.Hide();
                TelaDeLogin telaDeLogin = new TelaDeLogin();
                telaDeLogin.ShowDialog();
                this.Close();
            }
        }

        private void BtnCriarUsuario_Click(object sender, EventArgs e)
        {
            GerirUsuarios gerirUsuarios = new GerirUsuarios();
            gerirUsuarios.ShowDialog();
        }

        // FIM DA AREA DO MENU LATERAL ----------------------------------------------------------------

        private void btnSalvar_Click(object sender, EventArgs e)
        {

        }


        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {

            string textoSelecionado = comboBox1.SelectedItem?.ToString() ?? "";


            if (textoSelecionado == "Outros")
            {
                cmbxPrioridade.Visible = true;
                lblPrioridade.Visible = true;
                txbxDescr.Visible = true;
                lblDescr.Visible = true;
                PnlHelp.Visible = false;
                lblRespostaIA.Visible = false;
                lblsubTitulo.Visible = false;
                txbxSugestao.Visible = false;
            }
            else
            {
                cmbxPrioridade.Visible = false;
                lblPrioridade.Visible = false;
                txbxDescr.Visible = false;
                lblDescr.Visible = false;
            }
        }

        private void btnEnviarChamado_Click(object sender, EventArgs e)
        {

            if (comboBox1.SelectedItem == null)
            {
                MessageBox.Show("Preencha o Título, Motivo e Prioridade antes de enviar o chamado!", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            string textoSelecionado = comboBox1.SelectedItem.ToString();

            if (textoSelecionado != "Outros")
            {
                PnlHelp.Visible = true;
                lblRespostaIA.Visible = true;
                lblsubTitulo.Visible = true;
                txbxSugestao.Visible = true;

                txbxSugestao.Text = util.RespostasChamado.ObterResposta(textoSelecionado);
            }
            else
            {
                if (string.IsNullOrWhiteSpace(txbxTitulo.Text) || string.IsNullOrWhiteSpace(comboBox1.Text) || string.IsNullOrWhiteSpace(cmbxPrioridade.Text))
                {
                    MessageBox.Show("Preencha o Título, Motivo e Prioridade antes de enviar o chamado!", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                int prioridade = cmbxPrioridade.Text.ToLower() switch
                {
                    "crítica" => 1,
                    "critica" => 1,
                    "alta" => 2,
                    "média" => 3,
                    "media" => 3,
                    "baixa" => 4,
                    _ => 4
                };

                using (var conexao = util.Banco.AbrirConexao())
                {
                    try
                    {
                        string query = util.Banco.Queries.InserirTarefa;

                        using (var cmd = new NpgsqlCommand(query, conexao))
                        {
                            cmd.Parameters.AddWithValue("titulo", txbxTitulo.Text.Trim());
                            cmd.Parameters.AddWithValue("motivo", comboBox1.Text.Trim());

                            if (string.IsNullOrWhiteSpace(txbxDescr.Text))
                                cmd.Parameters.AddWithValue("descricao", DBNull.Value);
                            else
                                cmd.Parameters.AddWithValue("descricao", txbxDescr.Text.Trim());

                            cmd.Parameters.AddWithValue("prioridade", prioridade);
                            cmd.Parameters.AddWithValue("data_criacao", DateTime.Now);
                            cmd.Parameters.AddWithValue("resolvido", false);
                            cmd.Parameters.AddWithValue("id_usuario_criador", usuario.id);

                            cmd.ExecuteNonQuery();
                            MessageBox.Show("Chamado enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                            txbxTitulo.Text = "";
                            comboBox1.SelectedIndex = -1;
                            txbxDescr.Text = "";
                            cmbxPrioridade.Text = "";
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Erro ao enviar chamado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void EnviarChamadoPadrao_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txbxTitulo.Text) || string.IsNullOrWhiteSpace(comboBox1.Text))
            {
                MessageBox.Show("Preencha o Título e o Motivo antes de enviar o chamado!", "Campos obrigatórios", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Define prioridade de acordo com o motivo (comboBox1)
            int prioridade = comboBox1.Text.ToLower() switch
            {
                "problemas com o mouse" => 3,
                "problemas com som" => 4,
                "problema com vídeo" => 2,
                "problemas com a internet" => 1,
                _ => 4 // Se não reconhecer, deixa como prioridade 4 (mais baixa)
            };

            using (var conexao = util.Banco.AbrirConexao())
            {
                try
                {
                    string query = util.Banco.Queries.InserirTarefa;

                    using (var cmd = new NpgsqlCommand(query, conexao))
                    {
                        cmd.Parameters.AddWithValue("titulo", txbxTitulo.Text.Trim());
                        cmd.Parameters.AddWithValue("motivo", comboBox1.Text.Trim());
                        cmd.Parameters.AddWithValue("descricao", DBNull.Value); // ou a descrição se tiver
                        cmd.Parameters.AddWithValue("prioridade", prioridade);
                        cmd.Parameters.AddWithValue("data_criacao", DateTime.Now);
                        cmd.Parameters.AddWithValue("resolvido", false);
                        cmd.Parameters.AddWithValue("id_usuario_criador", usuario.id); // Aqui manda o id do usuário logado!


                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Chamado enviado com sucesso!", "Sucesso", MessageBoxButtons.OK, MessageBoxIcon.Information);

                        // Limpa campos
                        txbxTitulo.Text = "";
                        comboBox1.SelectedIndex = -1;

                        PnlHelp.Visible = false;
                        lblRespostaIA.Visible = false;
                        lblsubTitulo.Visible = false;
                        txbxSugestao.Visible = false;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Erro ao enviar chamado: " + ex.Message, "Erro", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void VisualizarChamado(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int idChamado = (int)btn.Tag;

            Chat chat = new Chat(idChamado, usuario); // <- passa o usuário logado aqui
            chat.ShowDialog();
        }

        private void ResolverChamado(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            int idChamado = (int)btn.Tag;

            Chat chat = new Chat(idChamado, usuario); // <- mesmo aqui
            chat.ShowDialog();
        }



        private void CarregarChamados()
        {
            panelListaChamados.Controls.Clear();

            using (var conexao = util.Banco.AbrirConexao())
            {
                string query = usuario.Cargo == "usuario"
                    ? util.Banco.Queries.ListarChamadosUser
                    : util.Banco.Queries.ListarChamadosAdmin;

                using (var cmd = new NpgsqlCommand(query, conexao))
                {
                    if (usuario.Cargo == "usuario")
                        cmd.Parameters.AddWithValue("id_usuario", usuario.id);

                    using (var reader = cmd.ExecuteReader())
                    {
                        int y = 0;

                        while (reader.Read())
                        {
                            int prioridadeNum = Convert.ToInt32(reader["prioridade"]);
                            if (usuario.Cargo == "Suporte" && prioridadeNum < usuario.Nivel)
                                continue;

                            int idChamado = Convert.ToInt32(reader["id"]);
                            string titulo = reader["titulo"].ToString();
                            string motivo = reader["motivo"].ToString();
                            string descricao = reader.IsDBNull(reader.GetOrdinal("descricao"))
                                ? ""
                                : reader["descricao"].ToString();
                            bool resolvido = reader["resolvido"] != DBNull.Value && Convert.ToBoolean(reader["resolvido"]);
                            string statusTexto = resolvido ? "Fechado" : "Aberto";
                            string prioridadeTexto = prioridadeNum switch
                            {
                                1 => "Crítica",
                                2 => "Alta",
                                3 => "Média",
                                4 => "Baixa",
                                _ => "Desconhecida"
                            };

                            Panel novoCard = new Panel
                            {
                                Size = cardTemplate.Size,
                                BackColor = cardTemplate.BackColor,
                                BorderStyle = cardTemplate.BorderStyle,
                                Location = new Point(0, y),
                                Margin = new Padding(9)
                            };

                            int cardWidth = novoCard.Width;
                            int padding = 10;

                            Label lblTitulo = new Label
                            {
                                Text = $"{titulo} - #{idChamado}",
                                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                                Location = new Point(10, 10),
                                AutoSize = true
                            };

                            Label lblMotivo = new Label
                            {
                                Text = "Motivo: " + motivo,
                                Location = new Point(10, 30),
                                AutoSize = true
                            };

                            Label lblPrioridade = new Label
                            {
                                Text = "Prioridade: " + prioridadeTexto,
                                Location = new Point(10, 50),
                                AutoSize = true
                            };

                            Label lblStatus = new Label
                            {
                                Text = "Status: " + statusTexto,
                                Location = new Point(cardWidth - 100 - padding, padding),
                                AutoSize = true
                            };

                            Button btnAcao = new Button
                            {
                                Text = usuario.Cargo == "usuario" ? "Visualizar" : "Resolver",
                                Width = 100,
                                Tag = idChamado,
                                Location = new Point(cardWidth - 100 - padding, padding + 20)
                            };

                            if (usuario.Cargo == "usuario")
                                btnAcao.Click += VisualizarChamado;
                            else
                                btnAcao.Click += ResolverChamado;

                            int yOffset = 70;

                            if (!string.IsNullOrWhiteSpace(descricao))
                            {
                                Label lblDescricao = new Label
                                {
                                    Text = "Descrição: " + descricao,
                                    Location = new Point(10, yOffset),
                                    AutoSize = true
                                };
                                novoCard.Controls.Add(lblDescricao);
                                yOffset += lblDescricao.Height + 10;
                            }

                            if (usuario.Cargo != "usuario" && reader.FieldCount > reader.GetOrdinal("nome_criador"))
                            {
                                Label lblCriador = new Label
                                {
                                    Text = "Criado por: " + reader["nome_criador"].ToString(),
                                    Location = new Point(10, yOffset),
                                    AutoSize = true
                                };
                                novoCard.Controls.Add(lblCriador);
                                yOffset += lblCriador.Height + 10;
                            }

                            novoCard.Controls.Add(lblTitulo);
                            novoCard.Controls.Add(lblMotivo);
                            novoCard.Controls.Add(lblPrioridade);
                            novoCard.Controls.Add(lblStatus);
                            novoCard.Controls.Add(btnAcao);

                            panelListaChamados.Controls.Add(novoCard);
                            y += novoCard.Height + 10;
                        }
                    }
                }
            }
        }

        private void PaginaOcultaChamados_Click(object sender, EventArgs e)
        {

        }

        private void txbxNomeUsuario_TextChanged(object sender, EventArgs e)
        {

        }

        private void pnlFiltro_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
