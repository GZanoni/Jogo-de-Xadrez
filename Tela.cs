using System;
using tabuleiro;

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
                for (int j = 0; j < tab.Colunas; j++)
                {
                    if (i == j )
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
                        Console.Write(tab.peca(i, j) + " ");
                    }
                }
                Console.WriteLine();
                Console.BackgroundColor = fundoOrig;
            }



        }

    }
}
