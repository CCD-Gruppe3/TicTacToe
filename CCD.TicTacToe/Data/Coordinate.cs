using System;

namespace CCD.TicTacToe.Data
{
	internal class Coordinate : IEquatable<Coordinate>
	{
		public bool Equals(Coordinate other)
		{
			if (ReferenceEquals(null, other)) return false;
			if (ReferenceEquals(this, other)) return true;
			return X == other.X && Y == other.Y;
		}

		public override bool Equals(object obj)
		{
			if (ReferenceEquals(null, obj)) return false;
			if (ReferenceEquals(this, obj)) return true;
			if (obj.GetType() != this.GetType()) return false;
			return Equals((Coordinate) obj);
		}

		public override int GetHashCode()
		{
			unchecked
			{
				return (X*397) ^ Y;
			}
		}

		public static bool operator ==(Coordinate left, Coordinate right)
		{
			return Equals(left, right);
		}

		public static bool operator !=(Coordinate left, Coordinate right)
		{
			return !Equals(left, right);
		}

		public Coordinate(int x, int y)
		{
			X = x;
			Y = y;
		}

		public int X { get; }
		public int Y { get; }
	}
}