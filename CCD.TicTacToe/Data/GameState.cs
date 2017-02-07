namespace CCD.TicTacToe.Data
{
	internal class GameState
	{
		public Token[,] Board { get; }

		public State State { get; }

		public GameState(Token[,] board, State state)
		{
			Board = board;
			State = state;
		}
	}
}