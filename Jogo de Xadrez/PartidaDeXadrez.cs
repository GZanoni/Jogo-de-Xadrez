using System;
using System.Collections.Generic;
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

        public PartidaDeXadrez()
        {
            tab = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
            Terminada = false;
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
            if (!tab.peca(origem).PodeMoverPara(destino))
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
                if(x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            return aux;
        }

        public HashSet<Peca> PecasEmJogo(Cor cor)
        {
            HashSet<Peca> aux = new HashSet<Peca>();
            foreach (Peca x in capturadas)
            {
                if (x.Cor == cor)
                {
                    aux.Add(x);
                }
            }
            aux.ExceptWith(pecasCapturadas(cor));
            return aux;
        }


        private void ColocarPecas()
        {
            //Brancas
            ColocarNovaPeca('a', 1, new Rei(tab, Cor.Branca));
            ColocarNovaPeca('b', 2, new Rei(tab, Cor.Branca));
            ColocarNovaPeca('b', 1, new Rei(tab, Cor.Branca));
            ColocarNovaPeca('c', 6, new Rei(tab, Cor.Branca));
            ColocarNovaPeca('c', 5, new Rei(tab, Cor.Branca));


            //Pretas
            ColocarNovaPeca('e', 4, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('e', 5, new Torre(tab, Cor.Preta));
            ColocarNovaPeca('f', 6, new Torre(tab, Cor.Preta));
                     

        }

        public void ExecutaMovimento(Posicao origem, Posicao destino)
        {
            Peca p = tab.RetirarPeca(origem);
            p.IncrementarQtdDeMovimentos();
            Peca pecaCapturada = tab.RetirarPeca(destino);
            tab.ColocarPeca(p, destino);
            if (pecaCapturada != null)
            {
                capturadas.Add(pecaCapturada);
            }
        }

        public void RealizaJogada(Posicao origem, Posicao destino)
        {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador(JogadorAtual);
        }

        private void MudaJogador(Cor jogadorAtual)
        {
            if (JogadorAtual == Cor.Branca)
            {
                JogadorAtual = Cor.Preta;
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                JogadorAtual = Cor.Branca;

            }
        }
    }
}