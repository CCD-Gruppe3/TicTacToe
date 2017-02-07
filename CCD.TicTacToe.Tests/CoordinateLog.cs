using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace CCD.TicTacToe.Tests
{
	[TestClass]
	public class CoordinateLog
	{

		[TestMethod]
		public void TryAdd()
		{
			var coordinateLog = new Data.CoordinateLog();
			Assert.IsTrue(coordinateLog.TryAdd(new Data.Coordinate(1, 2)));
		}

		[TestMethod]
		public void TryAdd_Error()
		{
			var coordinateLog = new Data.CoordinateLog();
			Assert.IsFalse(coordinateLog.TryAdd(new Data.Coordinate(9, 9)));
		}

		[TestMethod]
		public void TryAddTwice()
		{
			var coordinateLog = new Data.CoordinateLog();
			coordinateLog.TryAdd(new Data.Coordinate(1, 2));

			Assert.IsFalse(coordinateLog.TryAdd(new Data.Coordinate(1, 2)));
		}

		[TestMethod]
		public void Reset()

		{
			var coordinateLog = new Data.CoordinateLog();
			coordinateLog.TryAdd(new Data.Coordinate(1, 2));
			coordinateLog.Reset();
			Assert.IsTrue(coordinateLog.TryAdd(new Data.Coordinate(1, 2)));
		}
	}
}
