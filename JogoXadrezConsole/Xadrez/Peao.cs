using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez {
    internal class Peao : Peca {

        private PartidaXadrez Partida;

        public Peao(Tabuleiro tabuleiro, Cor cor, PartidaXadrez partida) : base(tabuleiro, cor) {
            Partida = partida;
        }

        public override string ToString() {
            return "P";
        }

        private bool ExisteInimigo(Posicao pos) {
            Peca p = Tabuleiro.peca(pos);
            return p != null && p.Cor != Cor;
        }

        private bool Livre(Posicao pos) {
            return Tabuleiro.peca(pos) == null;
        }

        public override bool[,] MovimentosPossiveis() {
            bool[,] matriz = new bool[Tabuleiro.Linha, Tabuleiro.Coluna];

            Posicao pos = new Posicao(0, 0);

            if (Cor == Cor.Branca) {
                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna);

                if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 2, Posicao.Coluna);

                Posicao p2 = new Posicao(Posicao.Linha - 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantMovimentos == 0) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha - 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                //#Jogada en passant
                if (Posicao.Linha == 3) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.peca(esquerda) == Partida.VulneravelEnPassant) {
                        matriz[esquerda.Linha - 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.peca(direita) == Partida.VulneravelEnPassant) {
                        matriz[direita.Linha - 1, direita.Coluna] = true;
                    }
                }

            } else {
                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(pos) && Livre(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 2, Posicao.Coluna);
                Posicao p2 = new Posicao(Posicao.Linha + 1, Posicao.Coluna);
                if (Tabuleiro.PosicaoValida(p2) && Livre(p2) && Tabuleiro.PosicaoValida(pos) && Livre(pos) && QuantMovimentos == 0) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna - 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                pos.DefinirValores(Posicao.Linha + 1, Posicao.Coluna + 1);
                if (Tabuleiro.PosicaoValida(pos) && ExisteInimigo(pos)) {
                    matriz[pos.Linha, pos.Coluna] = true;
                }

                //#Jogada en passant
                if (Posicao.Linha == 4) {
                    Posicao esquerda = new Posicao(Posicao.Linha, Posicao.Coluna - 1);

                    if (Tabuleiro.PosicaoValida(esquerda) && ExisteInimigo(esquerda) && Tabuleiro.peca(esquerda) == Partida.VulneravelEnPassant) {
                        matriz[esquerda.Linha + 1, esquerda.Coluna] = true;
                    }

                    Posicao direita = new Posicao(Posicao.Linha, Posicao.Coluna + 1);

                    if (Tabuleiro.PosicaoValida(direita) && ExisteInimigo(direita) && Tabuleiro.peca(direita) == Partida.VulneravelEnPassant) {
                        matriz[direita.Linha + 1, direita.Coluna] = true;
                    }
                }
            }

            return matriz;
        }
    }
}
