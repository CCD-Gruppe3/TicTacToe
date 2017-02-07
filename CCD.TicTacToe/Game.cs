using System.Collections.Generic;
using System.Linq;
using CCD.TicTacToe.Data;

namespace CCD.TicTacToe
{
	internal class Game
	{
		public Game()
		{
			Reset();
		}

		private CoordinateLog coordinateLog;

		public GameState Reset()
		{
			coordinateLog = new CoordinateLog();
			return new GameState(coordinateLog.ToBoard(), GetState());
		}

		public GameState CheckEndOfGame()
		{
			Coordinate[] playersMoves = GetCurrentPlayersMoves().ToArray();
			bool isThreeInARow = IsThreeInARow(playersMoves);

			return GetGameState(isThreeInARow);
		}

		private IEnumerable<Coordinate> GetCurrentPlayersMoves()
		{
			for (int i = coordinateLog.Moves.Length - 1; i >= 0; i = i - 2)
			{
				yield return coordinateLog.Moves[i];
			}
		}


		public bool IsThreeInARow(Coordinate[] playersMoves)
		{
			return playersMoves.GroupBy(m => m.X).Any(g => g.Count() == 3) ||
			                    playersMoves.GroupBy(m => m.Y).Any(g => g.Count() == 3) ||
			                    playersMoves.Count(m => m.X == m.Y) == 3 ||
			                    playersMoves.Count(m => m.X == 2 - m.Y) == 3;
		}

		public GameState Play(Coordinate coordinate)
		{
			if (coordinateLog.TryAdd(coordinate))
			{
				return CheckEndOfGame();
			}
			return new GameState(coordinateLog.ToBoard(), State.Error);
		}

		/// <summary>
		/// Aktueller Spielstatus
		/// </summary>
		private GameState GetGameState(bool isThreeInARow)
		{
			return new GameState(coordinateLog.ToBoard(), isThreeInARow ? GetWinnerState() : GetState());
		}

		/// <summary>
		/// Gibt an, wer den nächsten Zug macht.
		/// </summary>
		private State GetState()
		{
			if (coordinateLog.Count%2 == 0)
				return State.PlayerOne;
			return State.PlayerTwo;
		}

		/// <summary>
		/// Wer ist der Gewinner?
		/// </summary>
		private State GetWinnerState()
		{
			if (coordinateLog.Count%2 == 1)
				return State.PlayerOneWinner;
			return State.PlayerTwoWinner;
		}
	}
}