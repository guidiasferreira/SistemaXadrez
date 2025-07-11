using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro {
    internal class Tabuleiro {
        public int Linha { get; set; }
        public int Coluna { get; set; }

        private Peca[,] pecas;

        public Tabuleiro(int linha, int coluna) {
            Linha = linha;
            Coluna = coluna;
            pecas = new Peca[linha, coluna];
        }

        public Peca peca(int linha, int coluna) {
            return pecas[linha, coluna];
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }
    }
}
