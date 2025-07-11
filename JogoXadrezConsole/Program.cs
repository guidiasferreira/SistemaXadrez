using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiro;

namespace JogoXadrezConsole {
    internal class Program {
        static void Main(string[] args) {

            Posicao p = new Posicao(3, 4);

            Console.WriteLine("Posição: " + p);

            Console.ReadKey();
        }
    }
}
