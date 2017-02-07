using System.Runtime.Serialization;
using CCD.TicTacToe.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCD.TicTacToe.Tests
{
    [TestClass]
    public class Game
    {

        [TestMethod]
        public void Play_Player_One()
        {
            var game = new TicTacToe.Game();
            var coordinate = new Coordinate(0, 1);
            var gameState = game.Play(coordinate);
            Assert.AreEqual(State.PlayerTwo, gameState.State);
            Assert.AreEqual(Token.PlayerOne, gameState.Board[0, 1]);
        }

        [TestMethod]
        public void Play_Error()
        {
            var game = new TicTacToe.Game();
			var coordinate = new Coordinate(9, 9);
            var gameState = game.Play(coordinate);
            Assert.AreEqual(State.Error, gameState.State);
        }

        [TestMethod]
        public void Reset()
        {
            var game = new TicTacToe.Game();
			var coordinate = new Coordinate(0, 1);
            game.Play(coordinate);
            var gameState = game.Reset();
            Assert.AreEqual(Token.Empty, gameState.Board[0, 1]);
        }

        [TestMethod]
        public void CheckEndOfGame_PlayerOneWins()
        {
            var game = new TicTacToe.Game();

			game.Play(new Coordinate(0, 0));
			game.Play(new Coordinate(0, 2));
			game.Play(new Coordinate(1, 1));
			game.Play(new Coordinate(0, 1));
			var gameState = game.Play(new Coordinate(2, 2));

			Assert.AreEqual(State.PlayerOneWinner, gameState.State);
        }

        [TestMethod]
        public void CheckEndOfGame_PlayerTwoWins()
        {
            var game = new TicTacToe.Game();

			game.Play(new Coordinate(2, 2));
			game.Play(new Coordinate(0, 2));
			game.Play(new Coordinate(1, 1));
			game.Play(new Coordinate(0, 1));
			game.Play(new Coordinate(2, 1));
			var gameState = game.Play(new Coordinate(0, 0));

			Assert.AreEqual(State.PlayerTwoWinner, gameState.State);
        }

		[TestMethod]
        public void CheckEndOfGame_PlayerOneWins2()
        {
            var game = new TicTacToe.Game();

			game.Play(new Coordinate(0, 2));
			game.Play(new Coordinate(2, 1));
			game.Play(new Coordinate(1, 1));
			game.Play(new Coordinate(1, 0));
			var gameState = game.Play(new Coordinate(2, 0));

			Assert.AreEqual(State.PlayerOneWinner, gameState.State);
        }

        [TestMethod]
        public void CheckEndOfGame_PlayerTwoWins2()
        {
            var game = new TicTacToe.Game();

			game.Play(new Coordinate(2, 2));
			game.Play(new Coordinate(2, 0));
			game.Play(new Coordinate(1, 1));
			game.Play(new Coordinate(1, 0));
			game.Play(new Coordinate(1, 2));
			var gameState = game.Play(new Coordinate(0, 0));

			Assert.AreEqual(State.PlayerTwoWinner, gameState.State);
        }
    }
}
