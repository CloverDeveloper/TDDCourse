using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Text;
using TicTacToe.Model;

namespace SecondCourse.NUnit
{
    [TestFixture]
    public class TicTacToe
    {
        [Test]
        public void CreateGame_GameIsInCorrectState() 
        {
            Game game = new Game();

            Assert.AreEqual(0, game.MovesCounter);
            Assert.AreEqual(State.Unset, game.GetState(1));
        }

        [Test]
        public void MakeMove_CounterShifts() 
        {
            Game game = new Game();

            game.MakeMove(1);

            Assert.AreEqual(1, game.MovesCounter);
        }

        [Test]
        public void MakeInvalidMove_ThrowsException() 
        {
            Assert.Throws<ArgumentOutOfRangeException>(() =>
            {
                Game game = new Game();

                game.MakeMove(0);
            });
        }

        [Test]
        public void MoveOnTheSameSquare_ThrowsException()
        {
            Assert.Throws<InvalidOperationException>(() =>
            {
                Game game = new Game();

                game.MakeMove(1);
                game.MakeMove(1);
            });
        }

        [Test]
        public void MakingMoves_SetStateCorrectly() 
        {
            Game game = new Game();

            MakeMoves(game,1,2,3,4);

            Assert.AreEqual(State.Cross, game.GetState(1));
            Assert.AreEqual(State.Zero, game.GetState(2));
            Assert.AreEqual(State.Cross, game.GetState(3));
            Assert.AreEqual(State.Zero, game.GetState(4));
        }

        [Test]
        public void GetWinner_ZerosWinVertically_ReturnZeros() 
        {
            Game game = new Game();

            // 2 5 8 Zero Win
            MakeMoves(game,1, 2, 3, 5, 7, 8);

            Assert.AreEqual(Winner.Zero, game.GetWinner());
        }

        [Test]
        public void GetWinner_CrossWinDiagonal_ReturnCross()
        {
            Game game = new Game();

            // 1 5 9 Cross Win
            MakeMoves(game, 1, 2, 5, 4, 9);

            Assert.AreEqual(Winner.Cross, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameIsUnfinished_ReturnGameIsUnfinished()
        {
            Game game = new Game();

            // Game Unfinished
            MakeMoves(game, 1, 2, 3, 4, 9);

            Assert.AreEqual(Winner.GameIsUnfinished, game.GetWinner());
        }

        [Test]
        public void GetWinner_GameDraw_ReturnDraw()
        {
            Game game = new Game();

            // Game Draw
            MakeMoves(game, 1, 2, 3, 7, 8,9,4,5,6);

            Assert.AreEqual(Winner.Draw, game.GetWinner());
        }

        private void MakeMoves(Game game, params int[] indexs) 
        {
            foreach (var index in indexs)
            {
                game.MakeMove(index);
            }
        }
    }
}
