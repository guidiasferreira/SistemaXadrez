using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tabuleiro;
using xadrez;

namespace JogoXadrezConsole {
    internal class Program {
        static void Main(string[] args) {

            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(0, 0));
            tabuleiro.ColocarPeca(new Torre(tabuleiro, Cor.Preta), new Posicao(1, 3));
            tabuleiro.ColocarPeca(new Rei(tabuleiro, Cor.Preta), new Posicao(2, 4));

            Tela.ImprimirTabuleiro(tabuleiro);

            Console.ReadKey();
        }
    }
}
