﻿using System;
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
            pecas = new Peca[Linha, Coluna];
        }

        public Peca peca(int Linha, int Coluna) {
            return pecas[Linha, Coluna];
        }

        public Peca peca(Posicao pos) {
            return pecas[pos.Linha, pos.Coluna];
        }

        public bool ExistePeca(Posicao pos) {
            ValidarPosicao(pos);
            return peca(pos) != null;   
        }

        public void ColocarPeca(Peca p, Posicao pos) {
            if (ExistePeca(pos)) {
                throw new TabuleiroException("Já existe uma peça nessa posição!");
            }

            pecas[pos.Linha, pos.Coluna] = p;
            p.Posicao = pos;
        }

        public Peca RetirarPeca(Posicao pos) {
            if (peca(pos) == null) {
                return null;
            } 

            Peca aux = peca(pos);
            aux.Posicao = null;
            pecas[pos.Linha, pos.Coluna] = null;
            return aux;
        }

        public bool PosicaoValida(Posicao pos) {
            if (pos.Linha < 0 || pos.Linha >= Linha || pos.Coluna < 0 || pos.Coluna >= Coluna) {
                return false;
            }

            return true;
        }

        public void ValidarPosicao(Posicao pos) {
            if (!PosicaoValida(pos)) {
                throw new TabuleiroException("Posição Inválida!");
            }
        }
    }
}
