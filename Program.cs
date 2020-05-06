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
                Tabuleiro tab = new Tabuleiro(8, 8);

                tab.ColocarPeca(new Rei(tab, Cor.Preta), new Posicao(0, 3));
                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(0, 0));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(5, 1));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(5, 2));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(5, 3));

                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 5));
                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 2));
                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 3));
                tab.ColocarPeca(new Torre(tab, Cor.Branca), new Posicao(3, 4));
                tab.ColocarPeca(new Torre(tab, Cor.Preta), new Posicao(2, 0));


                Tela.ImprimirTabuleiro(tab);

                Console.WriteLine();


                PosicaoXadrez pos = new PosicaoXadrez('c', 5);
                Console.WriteLine(pos.toPosicao()); 
            }

            catch(TabuleiroException e)
            {
                Console.WriteLine(e.Message);
            }

            
        }

    }
}
