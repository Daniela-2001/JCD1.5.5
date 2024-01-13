namespace JCD1._5._5
{
    internal class Program
    {
        static char[] tabuleiro = { '1', '2', '3', '4', '5', '6', '7', '8', '9' };
        static int jogadorAtual = 1; // 1 para X, 2 para O

        static void Main()
        {
            do
            {
                Console.Clear();
                ExibirTabuleiro();

                // Obter as coordenadas da jogada do usuário
                Console.WriteLine($"\nJogador {jogadorAtual}, é a sua vez.");
                Console.Write("Digite a linha (1, 2 ou 3): ");
                int linha = int.Parse(Console.ReadLine()) - 1;

                Console.Write("Digite a coluna (1, 2 ou 3): ");
                int coluna = int.Parse(Console.ReadLine()) - 1;

                // Validar a jogada
                if (ValidarJogada(linha, coluna))
                {
                    // Realizar a jogada e alternar o jogador
                    RealizarJogada(linha, coluna);
                    jogadorAtual = (jogadorAtual == 1) ? 2 : 1;
                }
                else
                {
                    Console.WriteLine("Jogada inválida. Tente novamente.");
                    Console.ReadLine(); // Aguardar uma tecla antes de continuar
                }

            } while (VerificarFimDeJogo() == 0);

            Console.Clear();
            ExibirTabuleiro();
            Console.WriteLine("\nFim do jogo!");
            if (VerificarFimDeJogo() == -1)
                Console.WriteLine("Empate!");
            else
                Console.WriteLine($"Parabéns, Jogador {VerificarFimDeJogo()}! Você venceu!");
        }

        static void ExibirTabuleiro()
        {
            Console.WriteLine($" {tabuleiro[0]} | {tabuleiro[1]} | {tabuleiro[2]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tabuleiro[3]} | {tabuleiro[4]} | {tabuleiro[5]} ");
            Console.WriteLine("---|---|---");
            Console.WriteLine($" {tabuleiro[6]} | {tabuleiro[7]} | {tabuleiro[8]} ");
        }

        static bool ValidarJogada(int linha, int coluna)
        {
            int posicao = linha * 3 + coluna;
            return (posicao >= 0 && posicao < 9 && tabuleiro[posicao] != 'X' && tabuleiro[posicao] != 'O');
        }

        static void RealizarJogada(int linha, int coluna)
        {
            int posicao = linha * 3 + coluna;
            tabuleiro[posicao] = (jogadorAtual == 1) ? 'X' : 'O';
        }

        static int VerificarFimDeJogo()
        {
            // Verificar linhas, colunas e diagonais
            for (int i = 0; i < 3; i++)
            {
                // Verificar linhas e colunas
                if ((tabuleiro[i * 3] == tabuleiro[i * 3 + 1] && tabuleiro[i * 3 + 1] == tabuleiro[i * 3 + 2]) ||
                    (tabuleiro[i] == tabuleiro[i + 3] && tabuleiro[i + 3] == tabuleiro[i + 6]))
                    return (tabuleiro[i * 3] == 'X') ? 1 : 2;
            }

            // Verificar diagonais
            if ((tabuleiro[0] == tabuleiro[4] && tabuleiro[4] == tabuleiro[8]) ||
                (tabuleiro[2] == tabuleiro[4] && tabuleiro[4] == tabuleiro[6]))
                return (tabuleiro[4] == 'X') ? 1 : 2;

            // Verificar empate
            foreach (char c in tabuleiro)
            {
                if (c != 'X' && c != 'O')
                    return 0; // Jogo ainda não terminou
            }

            return -1; // Empate
        }
    }
}