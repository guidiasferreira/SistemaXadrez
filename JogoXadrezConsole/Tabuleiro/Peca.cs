using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro {
    abstract class Peca {
        public Posicao Posicao { get; set; }
        public Tabuleiro Tabuleiro { get; protected set; }
        public Cor Cor { get; protected set; }
        public int QuantMovimentos { get; protected set; }

        public Peca(Tabuleiro tabuleiro, Cor cor) {
            Posicao = null;
            Cor = cor;
            Tabuleiro = tabuleiro;
            QuantMovimentos = 0;
        }

        public void IncrementarQuantMovimentos() {
            QuantMovimentos++;
        }

        public void DecrementarQuantMovimentos() {
            QuantMovimentos--;
        }

        public bool ExisteMovimentosPossiveis() {
            bool[,] matriz = MovimentosPossiveis();

            for (int i = 0; i < Tabuleiro.Linha; i++) {
                for (int j = 0; j < Tabuleiro.Coluna; j++) {
                    if (matriz[i, j]) {
                        return true;
                    }
                }
            }

            return false;
        }

        public bool MovimentoPossivel(Posicao pos) {
            return MovimentosPossiveis()[pos.Linha, pos.Coluna];
        }

        public abstract bool[,] MovimentosPossiveis();
    }
}
