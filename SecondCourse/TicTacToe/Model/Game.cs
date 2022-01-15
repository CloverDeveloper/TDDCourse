using System;
using System.Collections.Generic;
using System.Text;

namespace TicTacToe.Model
{
    public class Game
    {
        public int MovesCounter { get; private set; }
        private readonly State[] board = new State[9];

        public Game()
        {
            for (int i = 0; i < board.Length; i += 1) 
            {
                board[i] = State.Unset;
            }
        }

        public void MakeMove(int index)
        {
            if (index < 1 || index > 9)
                throw new ArgumentOutOfRangeException();

            if (this.GetState(index) != State.Unset)
                throw new InvalidOperationException();

            this.board[index - 1] = this.MovesCounter % 2 == 0 ? State.Cross : State.Zero;

            this.MovesCounter += 1;
        }

        public State GetState(int index)
        {
            return this.board[index - 1];
        }

        public Winner GetWinner()
        {
            return this.GetWinner(1, 4, 7, 2, 5, 8, 3, 6, 9, 1, 2, 3, 4, 5, 6, 7, 8, 9, 1, 5, 9, 3, 5, 7);
        }

        private Winner GetWinner(params int[] indexs)
        {
            bool same;
            for (int i = 0; i < indexs.Length; i+=3)
            {
                same = this.AreSame(indexs[i], indexs[i + 1], indexs[i + 2]);
                if (same && this.GetState(indexs[i]) != State.Unset) 
                {
                    return this.GetState(indexs[i]) == State.Cross ? Winner.Cross : Winner.Zero;
                }
            }

            if (this.MovesCounter < 9) return Winner.GameIsUnfinished;

            return Winner.Draw;
        }

        private bool AreSame(int a, int b, int c)
        {
            return this.GetState(a) == this.GetState(b) && this.GetState(a) == this.GetState(c);
        }
    }
}
