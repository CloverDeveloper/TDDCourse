using System;
using System.Text;
using TicTacToe.Model;

namespace TicTacToe
{
    class TicTacToeGame
    {
        private static Game game = new Game();

        static void Main(string[] args)
        {
            Console.WriteLine(GetPrintableState());

            while (game.GetWinner() == Winner.GameIsUnfinished) 
            {
                var index = int.Parse(Console.ReadLine());

                game.MakeMove(index);

                Console.WriteLine();
                Console.WriteLine(GetPrintableState());
            }

            Console.WriteLine($"Result:{game.GetWinner()}");
        }

        private static string GetPrintableState()
        {
            StringBuilder sb = new StringBuilder();

            for (int i = 1; i <= 7; i += 3) 
            {
                sb.AppendLine("     |     |     ");
                sb.AppendLine($"  {GetPrintState(i)}  |  {GetPrintState(i+1)}  |  {GetPrintState(i+2)}  ");
                if (i < 7)
                {
                    sb.AppendLine("-----|-----|-----");
                }
                else 
                {
                    sb.AppendLine("     |     |     ");
                }
            }

            return sb.ToString();
        }

        private static string GetPrintState(int index)
        {
            var state = game.GetState(index);

            if (state == State.Unset) return index.ToString();

            return state == State.Cross ? "X" : "O";
        }
    }
}
