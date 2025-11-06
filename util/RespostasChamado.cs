using System;
using System.Collections.Generic;

namespace Pim3Semestre.util
{
    internal class RespostasChamado
    {
        private static readonly List<string> ProblemasMouse = new List<string>
        {
            "🔌 Verifique se o cabo do mouse está bem conectado à entrada USB.",
            "🧹 Limpe a parte inferior do mouse, especialmente o sensor óptico, para evitar falhas de movimento.",
            "🔋 Se for um mouse sem fio, confira se as pilhas ou a bateria estão carregadas.",
            "🔁 Tente conectar o mouse em outra porta USB ou testar em outro computador para identificar se o problema é no mouse ou no PC."
        };

        private static readonly List<string> ProblemasSom = new List<string>
        {
            "🔇 Verifique se o volume do seu computador e dos aplicativos está ativado e ajustado corretamente.",
            "🎧 Se estiver usando fones de ouvido, confirme se eles estão conectados na entrada certa e funcionando.",
            "🖥️ Confira se o dispositivo de saída de áudio correto está selecionado nas configurações de som do sistema.",
            "🔄 Reinicie seu computador para resolver eventuais travamentos nos drivers de áudio."
        };

        private static readonly List<string> ProblemasVideo = new List<string>
        {
            "🖥️ Verifique se o cabo de vídeo (HDMI, DisplayPort, VGA) está bem encaixado no monitor e no computador.",
            "🌟 Atualize os drivers da placa de vídeo para garantir o melhor desempenho visual.",
            "🔌 Certifique-se de que o monitor está ligado e configurado para a entrada correta (HDMI, DisplayPort, etc).",
            "🖼️ Ajuste a resolução nas configurações de vídeo caso a imagem esteja distorcida ou borrada."
        };

        private static readonly List<string> ProblemasInternet = new List<string>
        {
            "📶 Verifique se o Wi-Fi está ativado no seu computador ou dispositivo.",
            "📡 Tente se aproximar do roteador para melhorar a qualidade do sinal.",
            "🔄 Reinicie o modem e o roteador desconectando da tomada por 10 segundos e conectando novamente.",
            "🧹 Limpe redes antigas ou que não funcionam corretamente da lista de redes conhecidas do dispositivo."
        };

        private static readonly Random random = new Random();

        public static string ObterResposta(string tipoProblema)
        {
            tipoProblema = tipoProblema.ToLower(); // Deixa minúsculo pra facilitar comparar
            List<string> lista = tipoProblema switch
            {
                "problemas com o mouse" => ProblemasMouse,
                "problemas com som" => ProblemasSom,
                "problema com vídeo" => ProblemasVideo,
                "problemas com a internet" => ProblemasInternet,
                _ => null
            };

            if (lista == null || lista.Count == 0)
            {
                return "Tipo de problema não reconhecido.";
            }

            int index = random.Next(lista.Count);
            return lista[index];
        }
    }
}
