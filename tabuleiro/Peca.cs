﻿using tabuleiro;

namespace tabuleiro
{
    abstract class Peca
    {
        public Posicao Posicao { get; set; }
        public Cor Cor { get; protected set; }
        public int QtdDeMovimentos { get; protected set; }
        public Tabuleiro Tab { get; protected set; }

        public Peca(Tabuleiro tab, Cor cor)
        {
            Posicao = null;
            Cor = cor;
            QtdDeMovimentos = 0;
            Tab = tab;
        }

        public void IncrementarQtdDeMovimentos()
        {
            QtdDeMovimentos++;
        }

        public void DecrementarQtdDeMovimentos()
        {
            QtdDeMovimentos--;
        }

        public abstract bool[,] MovimentosPossiveis();

        public bool ExisteMovimento()
        {
            bool[,] mat = MovimentosPossiveis();
            for(int i = 0; i < Tab.Linhas; i++)
            {
                for(int j = 0; j < Tab.Colunas; j++)
                {
                    if(mat[i, j])
                    {
                        return true;
                    }               
                }
            }
            return false;
        }

        public bool PodeMoverPara(Posicao pos)
        {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }
                
    }
}
