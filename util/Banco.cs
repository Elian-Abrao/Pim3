using Npgsql;
using System;

namespace Pim3Semestre.util
{
    internal static class Banco
    {
        private static readonly string connString = "Host=localhost;Port=5432;Username=postgres;Password=123;Database=postgres;";

        public static NpgsqlConnection AbrirConexao()
        {
            var conexao = new NpgsqlConnection(connString);
            conexao.Open();
            return conexao;
        }

        public static class Queries
        {
            // 🔍 VALIDAÇÕES
            public const string VerificarUsuarioExistente = @"
                SELECT 1
                FROM ""user""
                WHERE cpf = @cpf
                   OR email = @email
                   OR nome = @nome
                LIMIT 1;
            ";

            // ➕ INSERÇÕES
            public const string InserirUsuario = @"
                INSERT INTO ""user"" (cpf, nome, email, senha, cargo)
                VALUES (@cpf, @nome, @email, @senha, @usuario);
            ";

            public const string InserirTarefa = @"
                INSERT INTO chamados (
                    titulo, motivo, descricao, prioridade, 
                    data_criacao, resolvido, id_usuario_criador
                )
                VALUES (
                    @titulo, @motivo, @descricao, @prioridade, 
                    @data_criacao, @resolvido, @id_usuario_criador
                );
            ";

            // 🔐 LOGIN
            public const string LoginUsuario = @"
                SELECT id, cpf, nome, email, cargo, senha, nivel
                FROM ""user""
                WHERE nome = @nome AND senha = @Senha
                LIMIT 1;
            ";

            // 🛠️ ATUALIZAÇÕES
            public const string SalvarEditarPerfil = @"
                UPDATE ""user""
                SET nome = @nome,
                    email = @email,
                    senha = @senha
                WHERE cpf = @cpf;
            ";

            // 📊 CONTADORES
            public const string contarCriticos = @"
                SELECT COUNT(*)
                FROM chamados 
                WHERE prioridade = 1 AND id_usuario_criador = @id;
            ";

            public const string contarCriticosAdmin = @"
                SELECT COUNT(*)
                FROM chamados 
                WHERE prioridade = 1;
            ";

            public const string contarFechados = @"
                SELECT COUNT(*)
                FROM chamados 
                WHERE resolvido = true AND id_usuario_criador = @id;
            ";

            public const string contarFechadosAdmin = @"
                SELECT COUNT(*)
                FROM chamados 
                WHERE resolvido = true;
            ";

            public const string contarAbertos = @"
                SELECT COUNT(*)
                FROM chamados 
                WHERE resolvido = false AND id_usuario_criador = @id;
            ";

            public const string contarAbertosAdmin = @"
                SELECT COUNT(*)
                FROM chamados 
                WHERE resolvido = false;
            ";

            // 📄 LISTAGEM DE CHAMADOS
            public const string ListarChamadosUser = @"
                SELECT id, titulo, motivo, prioridade, resolvido, descricao
                FROM chamados 
                WHERE id_usuario_criador = @id_usuario 
                ORDER BY data_criacao DESC;
            ";

            public const string ListarChamadosAdmin = @"
                SELECT 
                    chamados.id, titulo, motivo, descricao, prioridade, resolvido, 
                    u.nome AS nome_criador
                FROM chamados
                INNER JOIN ""user"" u ON u.id = chamados.id_usuario_criador
                ORDER BY data_criacao DESC;
            ";

            public const string CarregarMensagens = @"
                SELECT 
                    m.mensagem, m.data_envio, u.nome, u.id AS remetente_id
                FROM mensagens_chat m
                INNER JOIN ""user"" u ON u.id = m.id_usuario
                WHERE m.id_chamado = @idChamado
                ORDER BY m.data_envio ASC;
            ";

            public const string CarregarStatus = @"
                SELECT resolvido 
                FROM chamados 
                WHERE id = @id;
            ";

            public const string EnviarMensagem = @"
                INSERT INTO mensagens_chat (
                    id_chamado, id_usuario, mensagem, data_envio
                ) 
                VALUES (
                    @idChamado, @idUsuario, @mensagem, @data
                );
            ";

            public const string FecharChamado = @"
                UPDATE chamados 
                SET resolvido = TRUE, 
                    id_usuario_resolvedor = @resolvidoPor, 
                    data_resolucao = @data 
                WHERE id = @id;
            ";

            public const string ReabrirChamado = @"
                UPDATE chamados 
                SET resolvido = FALSE, 
                    id_usuario_resolvedor = NULL, 
                    data_resolucao = NULL 
                WHERE id = @id;
            ";

            public const string AtualizarUsuario = @"
                UPDATE ""user""
                SET nome = @nome,
                    email = @email,
                    cpf = @cpf,
                    cargo = @cargo,
                    nivel = @nivel
                WHERE id = @id;
            ";

            public const string DeletarUsuario = @"
                DELETE FROM ""user"" 
                WHERE id = @id;
            ";

            public const string PuxarDado = @"
                SELECT id, nome, email, cpf, cargo, nivel 
                FROM ""user"" 
                ORDER BY nome;
            ";

            public const string inserirUsuario = @"
                INSERT INTO ""user"" (
                    cpf, nome, email, senha, cargo, nivel
                ) 
                VALUES (
                    @cpf, @nome, @email, @senha, @cargo, @nivel
                );
            ";
        }
    }
}
