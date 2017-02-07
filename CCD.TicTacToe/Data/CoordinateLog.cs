using System;
using System.Collections.Generic;

namespace CCD.TicTacToe.Data
{
	internal class CoordinateLog
	{
		public CoordinateLog()
		{
			moves = new List<Coordinate>();
		}

		private readonly List<Coordinate> moves;

		public bool TryAdd(Coordinate coordinate)
		{
			if (coordinate.X < 0 || coordinate.Y < 0)
				return false;
			if (coordinate.X > 2 || coordinate.Y > 2)
				return false;

			if (!moves.Contains(coordinate))
			{
				moves.Add(coordinate);
				return true;
			}
			return false;
		}

		public void Reset()
		{
			moves.Clear();
		}

		public int Count => moves.Count;

		public Coordinate[] Moves => moves.ToArray();

		public Token[,] ToBoard()
		{
			Token[,] result = {
				{Token.Empty, Token.Empty, Token.Empty},
				{Token.Empty, Token.Empty, Token.Empty},
				{Token.Empty, Token.Empty, Token.Empty}
			};

			bool playerOne = true;

			foreach (var coordinate in moves)
			{
				var token = playerOne ? Token.PlayerOne : Token.PlayerTwo;

				result[coordinate.X, coordinate.Y] = token;

				playerOne = !playerOne;
			}

			return result;
		}
	}
}