using Jogo_de_Xadrez;
using System.ComponentModel.DataAnnotations;
using tabuleiro;

namespace Jogo_de_Xadrez
{
    class Peao : Peca
    {

        public override string ToString()
        {
            return "P";
        }


        public Peao(Tabuleiro tab, Cor cor) : base(tab, cor)
        {
        }

        private bool ExisteInimigo(Posicao pos)
        {
            Peca p = Tab.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos)
        {
            return Tab.peca(pos) == null;
        }


        public override bool[,] MovimentosPossiveis()
        {
            bool[,] mat = new bool[Tab.Linhas, Tab.Colunas];
            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.BRANCA)
            {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);
                //Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (/*Tab.PosicaoValida(p2) && Livre(p2) && */ Tab.PosicaoValida(pos) && Livre(pos) && QtdDeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //COMER
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }
            }
            //PRETA
            else
            {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tab.PosicaoValida(pos) && Livre(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                //Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (/*Tab.PosicaoValida(p2) && Livre(p2) && */ Tab.PosicaoValida(pos) && Livre(pos) && QtdDeMovimentos == 0)
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                //COMER
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tab.PosicaoValida(pos) && ExisteInimigo(pos))
                {
                    mat[pos.Linha, pos.Coluna] = true;
                }

            }
            
            return mat;
        }
    }
}



