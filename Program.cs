using Jogo_de_Xadrez;
using System;
using System.Dynamic;
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
                    try
                    {
                        Console.Clear();
                        Tela.ImprimirPartida(partida);
                       
                        Console.WriteLine();
                        Console.Write("  ORIGEM: ");
                        Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosDeOrigem(origem);
                        Console.Clear();

                        bool[,] PosicoesPossiveis = partida.tab.peca(origem).MovimentosPossiveis();

                        Tela.ImprimirTabuleiro(partida.tab, PosicoesPossiveis);

                        Console.WriteLine();
                        Console.Write("  DESTINO: ");
                        Posicao destino = Tela.LerPosicaoXadrez().toPosicao();
                        partida.ValidarPosDestino(origem, destino);


                        partida.RealizaJogada(origem, destino);

                    }
                    catch (TabuleiroException e)
                    {
                        Console.WriteLine(e.Message);
                        Console.ReadLine();
                        
                    }
                }
            }
            catch (TabuleiroException e)
            {
                Console.WriteLine(e.Message); 
                Console.ReadLine();
            }
        }
    }
}

    
