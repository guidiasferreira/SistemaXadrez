using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;

namespace JogoXadrezConsole {
    internal class Tela {
        public static void ImprimirTabuleiro(Tabuleiro tabuleiro) {
            for (int i = 0; i < tabuleiro.Linha; i++) {
                for (int j = 0; j < tabuleiro.Coluna; j++) {
                    if (tabuleiro.peca(i, j) == null) {
                        Console.Write(" — ");

                    } else {
                        Console.Write(tabuleiro.peca(i, j) + " ");
                    }                   
                }

                Console.WriteLine();
            }
        }
    }
}
