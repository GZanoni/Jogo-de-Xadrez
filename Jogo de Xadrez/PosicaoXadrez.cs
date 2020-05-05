using tabuleiro;

namespace Jogo_de_Xadrez
{
    class PosicaoXadrez
    {
        public char Coluna { get; set; }
        public int Linhas { get; set; }

        public PosicaoXadrez(char coluna, int linhas)
        {
            Coluna = coluna;
            Linhas = linhas;
        }

        public Posicao toPosicao()
        {
            return new Posicao(8 - Linhas, Coluna - 'a');
        }

        public override string ToString()
        {
            return "" + Coluna + Linhas;
        }
    }
}
