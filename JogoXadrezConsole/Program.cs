using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tabuleiros;

namespace JogoXadrezConsole {
    internal class Program {
        static void Main(string[] args) {

            Tabuleiro tabuleiro = new Tabuleiro(8, 8);

            Console.ReadKey();
        }
    }
}
