using Jogo_de_Xadrez;
using System;
using tabuleiro;


namespace Xadrez
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                PartidaDeXadrez partida = new PartidaDeXadrez();

                while (!partida.Terminada)
                {
                    Console.Clear();
                    Tela.ImprimirTabuleiro(partida.tab);

                    
                    Console.WriteLine();
                    Console.Write("  ORIGEM: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    Console.Clear();
                    
                    bool[,] PosicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();
                    
                    Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);
                    
                    Console.WriteLine();
                    Console.Write("  DESTINO: ");
                    Posicao destino = Tela.LerPosicaoXadrez().toPosicao();


                    partida.ExecutaMovimento(origem, destino);

                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }


        }

    }
}
