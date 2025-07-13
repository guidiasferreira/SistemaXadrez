using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace xadrez {
    internal class PartidaXadrez {

        public Tabuleiro Tabuleiro { get; private set; }
        public bool Terminada { get; private set; }
        public int Turno { get; private set; }
        public Cor JogadorAtual { get; private set; }

        private HashSet<Peca> pecas;
        private HashSet<Peca> capturadas;

        public PartidaXadrez() {
            Tabuleiro = new Tabuleiro(8, 8);
            Turno = 1;
            JogadorAtual = Cor.Branca;
            Terminada = false;
            pecas = new HashSet<Peca>();
            capturadas = new HashSet<Peca>();
            ColocarPecas();
        }

        public void ExecutaMovimento(Posicao origem, Posicao destino) {
            Peca p = Tabuleiro.RetirarPeca(origem);
            p.IncrementarQuantMovimentos();
            Peca pecaCapturada = Tabuleiro.RetirarPeca(destino);
            Tabuleiro.ColocarPeca(p, destino);

            if (pecaCapturada != null) {
                capturadas.Add(pecaCapturada);
            }
        }

        public void RealizarJogada(Posicao origem, Posicao destino) {
            ExecutaMovimento(origem, destino);
            Turno++;
            MudaJogador();
        }

        public void ValidarPosicaoOrigem(Posicao pos) {
            if (Tabuleiro.peca(pos) == null) {
                throw new TabuleiroException("Não existe peça na posição de origem escolhida!");
            }

            if (JogadorAtual != Tabuleiro.peca(pos).Cor) {
                throw new TabuleiroException("A peça de origem escolhida não é sua!");
            }

            if (!Tabuleiro.peca(pos).ExisteMovimentosPossiveis()) {
                throw new TabuleiroException("Não há movimentos possíveis para a peça de origem escolhida!");
            }
        }

        public void ValidarPosicaoDestino(Posicao origem, Posicao destino) {
            if (!Tabuleiro.peca(origem).PodeMover(destino)) {
                throw new TabuleiroException("Posição de destino é inválida!");
            }
        }

        private void MudaJogador() {
            if (JogadorAtual == Cor.Branca) {
                JogadorAtual = Cor.Preta;

            } else {
                JogadorAtual = Cor.Branca;
            }
        }

        public HashSet<Peca> PecasCapturadas(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in capturadas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }

            return aux;
        }
        public HashSet<Peca> PecasEmJogo(Cor cor) {
            HashSet<Peca> aux = new HashSet<Peca>();

            foreach (Peca x in pecas) {
                if (x.Cor == cor) {
                    aux.Add(x);
                }
            }

            aux.ExceptWith(PecasCapturadas(cor));
            return aux; 
        }


        public void ColocarNovaPeca(char coluna, int linha, Peca peca) {
            Tabuleiro.ColocarPeca(peca, new PosicaoXadrez(coluna, linha).ToPosicao());
            pecas.Add(peca);
        }

        public void ColocarPecas() {
            ColocarNovaPeca('c', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('c', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 2, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('e', 1, new Torre(Tabuleiro, Cor.Branca));
            ColocarNovaPeca('d', 1, new Rei(Tabuleiro, Cor.Branca));

            ColocarNovaPeca('c', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('c', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 7, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('e', 8, new Torre(Tabuleiro, Cor.Preta));
            ColocarNovaPeca('d', 8, new Rei(Tabuleiro, Cor.Preta));


        }
    }
}
