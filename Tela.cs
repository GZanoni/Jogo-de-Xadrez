using System;
using tabuleiro;
using Jogo_de_Xadrez;

namespace Xadrez
{
    class Tela
    {
        public static void ImprimirTabuleiro(Tabuleiro tab)
        {
            ConsoleColor fundoOrig = Console.BackgroundColor;
            ConsoleColor fundoAlt = ConsoleColor.White;

            for (int i = 0; i < tab.Linhas; i++)
            {
                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write(8 - i + " ");
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (i == j)
                    {
                        Console.BackgroundColor = fundoAlt;

                    }
                    else if (i % 2 == 0 && j == 0)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else if (i % 2 == 1 && j == 1)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else if (i % 2 == 0 && j == 2)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else if (i % 2 == 1 && j == 3)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else if (i % 2 == 0 && j == 4)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }
                    else if (i % 2 == 1 && j == 5)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else if (i % 2 == 0 && j == 6)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else if (i % 2 == 1 && j == 7)
                    {
                        Console.BackgroundColor = fundoAlt;
                    }

                    else
                    {
                        Console.BackgroundColor = fundoOrig;
                    }


                    if (tab.peca(i, j) == null)
                    {
                        Console.Write("  ");

                    }
                    else
                    {
                        ImprimirPecas(tab.peca(i, j));
                        Console.Write(" ");
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = fundoOrig;
            }

            Console.WriteLine("  a b c d e f g h");
        }

        public static PosicaoXadrez LerPosicaoXadrez()
        {
            string s = Console.ReadLine();
            char coluna = s[0];
            int linha = int.Parse(s[1] + "");
            return new PosicaoXadrez(coluna, linha);
        }

        public static void ImprimirPecas(Peca p)
        {
            if (p.Cor == Cor.Branca)
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write(p);
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.Write(p);
            }

            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}
