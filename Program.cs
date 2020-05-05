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
            Tabuleiro tab = new Tabuleiro(8, 8);

            tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao (0, 3));
            tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao (0, 0));

            Tela.ImprimirTabuleiro(tab);

            Console.WriteLine();
        }

    }
}
