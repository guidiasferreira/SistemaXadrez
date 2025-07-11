using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tabuleiro {
    internal class Peca {
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
    }
}
