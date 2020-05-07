using System;

namespace tabuleiro
{
    class TabuleiroException : Exception
    {
        public TabuleiroException(string msg) : base(msg)
        {
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.Red;
        }

    }
}
