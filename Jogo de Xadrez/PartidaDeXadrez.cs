using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;
using tabuleiro;

namespace Jogo_de_Xadrez
{
    class PartidaDeXadrez
    {
        public Tabuleiro tab { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }
        public bool Terminada { get; private set; }
        private HashSet<Peca> Pecas;
        private HashSet<Peca> capturadas;
        public bool Xeque { get; private set; }

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.BRANCA;
            Pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            Xeque = false;
            Terminada = false;
            ColocarPecas();

        }

        private Cor Adversaria(Cor cor)
        {
            if (cor == Cor.BRANCA)
            {
                return Cor.PRETA;
            }
            else
            {
                return Cor.BRANCA;
            }
        }

        private Peca Rei(Cor cor)
        {
            foreach (Peca x in PecasEmJogo(cor))
            {
                if (x is Rei)
                {
                    return x;
                }
            }
            return null;
        }

        public bool EstaEmXeque(Cor cor)
        {
            Peca R = Rei(cor);
            if (R == null)
            {
                throw new TabuleiroException("  Nao tem rei da cor " + cor + " no tabuleiro!");
            }

            foreach (Peca x in PecasEmJogo(Adversaria(cor)))
            {
                bool[,] mat = x.MovimentosPossiveis();
                if (mat[R.Posicao.Linha, R.Posicao.Coluna])
                {
                    return true;
                }
            }
            return false;
        }


        public bool TesteXequemate(Cor cor)
        {
            if (!EstaEmXeque(cor))
            {
                return false;
            }

            foreach (Peca x in PecasEmJogo(cor))
            {
                bool[,] mat = x.MovimentosPossiveis();
                for (int i = 0; i < tab.Linhas; i++)
                {
                    for (int j = 0; j < tab.Colunas; j++)
                    {
                        if (mat[i, j])
                        {
                            Posicao origem = x.Posicao;
                            Posicao destino = new Posicao(i, j);
                            Peca pecaCapturada = ExecutaMovimento(origem, destino);
                            bool testeXeque = EstaEmXeque(cor);
                            DesfazMovimento(origem, destino, pecaCapturada);
                            if (!testeXeque)
                            {
                                return false;
                            }
                        }
                    }
                }
            }
            return true;

        }


        public void RetirarPeca(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdDeMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
        }

        public void ValidarPosDeOrigem(Posicao pos)
        {
            if (tab.peca(pos) == null)
            {
                throw new TabuleiroException("  NÃO EXISTE PEÇA NA POSIÇÃO DE ORIGEM ESCOLHIDA!");
            }
            if (JogadorAtual != tab.peca(pos).Cor)
            {
                throw new TabuleiroException("  A PEÇA DE ORIGEM ESCOLHIDA NÃO É SUA!");
            }
            if (!tab.peca(pos).ExisteMovimento())
            {
                throw new TabuleiroException("  NÃO EXISTE MOVIMENTO VALIDO PARA A PEÇA DE ORIGEM!");
            }
        }

        public void ValidarPosDestino(Posicao origem, Posicao destino)
        {
            if (!tab.peca(origem).MovimentoPossivel(destino))
            {
                throw new TabuleiroException("  POSIÇÃO DE DESTINO INVALIDA!");
            }
        }

        public void ColocarNovaPeca(char coluna, int linha, Peca peca)
        {
            tab.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).toPosicao());
            Pecas.Add(peca);
        }

        public HashSet<Peca> pecasCapturadas(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in Pecas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }

        public Peca ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdDeMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }

            return pecaCapturada;
        }

        public void DesfazMovimento(Posicao origem, Posicao destino, Peca pecaCapturada)
        {
            Peca p = tab.RetirarPeca(destino);
            p.DecrementarQtdDeMovimentos();

            if (pecaCapturada != null)
            {
                tab.ColocarPeca(pecaCapturada, destino);
                capturadas.Remove(pecaCapturada);
            }
            tab.ColocarPeca(p, origem);
        }


        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            Peca pecaCapturada = ExecutaMovimento(origem, destino);
            if (EstaEmXeque(JogadorAtual))
            {
                DesfazMovimento(origem, destino, pecaCapturada);
                throw new TabuleiroException("  VOCE NAO PODE SE COLOCAR EM XEQUE!");
            }

            if (EstaEmXeque(Adversaria(JogadorAtual)))
            {
                Xeque = true;
            }
            else
            {
                Xeque = false;
            }

            if (TesteXequemate(Adversaria(JogadorAtual)))
            {
                Terminada = true;
            }
            else
            {
                Turno++;
                MudaJogador(JogadorAtual);
            }

        }

        private void MudaJogador(Cor jogadorAtual)
        {
            if (JogadorAtual == Cor.BRANCA)
            {
                JogadorAtual = Cor.PRETA;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                JogadorAtual = Cor.BRANCA;

            }
        }

        private void ColocarPecas()
        {
            //Brancas
            ColocarNovaPeca('a', 1, new Torre(tab, Cor.BRANCA));
            ColocarNovaPeca('h', 1, new Torre(tab, Cor.BRANCA));
            ColocarNovaPeca('c', 1, new Bispo(tab, Cor.BRANCA));
            ColocarNovaPeca('f', 1, new Bispo(tab, Cor.BRANCA));
            ColocarNovaPeca('d', 1, new Rei(tab, Cor.BRANCA));
            ColocarNovaPeca('b', 1, new Cavalo(tab, Cor.BRANCA));
            ColocarNovaPeca('g', 1, new Cavalo(tab, Cor.BRANCA));
            ColocarNovaPeca('e', 1, new Rainha(tab, Cor.BRANCA));
            ColocarNovaPeca('a', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('b', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('c', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('d', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('e', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('f', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('g', 2, new Peao(tab, Cor.BRANCA));
            ColocarNovaPeca('h', 2, new Peao(tab, Cor.BRANCA));


            //Pretas
            ColocarNovaPeca('a', 8, new Torre(tab, Cor.PRETA));
            ColocarNovaPeca('h', 8, new Torre(tab, Cor.PRETA));
            ColocarNovaPeca('c', 8, new Bispo(tab, Cor.PRETA));
            ColocarNovaPeca('f', 8, new Bispo(tab, Cor.PRETA));
            ColocarNovaPeca('d', 8, new Rei(tab, Cor.PRETA));
            ColocarNovaPeca('b', 8, new Cavalo(tab, Cor.PRETA));
            ColocarNovaPeca('g', 8, new Cavalo(tab, Cor.PRETA));
            ColocarNovaPeca('e', 8, new Rainha(tab, Cor.PRETA));
            ColocarNovaPeca('a', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('b', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('c', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('d', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('e', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('f', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('g', 7, new Peao(tab, Cor.PRETA));
            ColocarNovaPeca('h', 7, new Peao(tab, Cor.PRETA));

        }

    }
}