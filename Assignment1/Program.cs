using System;

namespace Assignment1
{
    class Program
    {
        static void Main(string[] args)
        {
            Player player1 = new Player(Name:"a");

            player1.Exp = 3000;

            Console.WriteLine(player1.Level);

            player1.Exp = 2000;

            Console.WriteLine(player1.Level);

            player1.Exp = 2000;

            Console.WriteLine(player1.Level);

            player1.Exp = 4000;

            Console.WriteLine(player1.Level);
        }
    }
}
