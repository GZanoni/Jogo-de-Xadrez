using Jogo_de_Xadrez;
using System;
using tabuleiro;
using Jogo_de_Xadrez;

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

                    Console.Write("Origem: ");
                    Posicao origem = Tela.LerPosicaoXadrez().toPosicao();
                    Console.Write("Destino: ");
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
