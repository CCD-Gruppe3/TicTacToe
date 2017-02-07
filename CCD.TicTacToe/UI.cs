using System;
using System.Linq;
using CCD.TicTacToe.Data;

namespace CCD.TicTacToe
{
	internal class UI
	{
		public void Print(GameState gameState)
		{
            PrintBoard(gameState.Board);
		    PrintState(gameState.State);
		}

	    private void PrintBoard(Token[,] board)
	    {
			Console.WriteLine(" A B C");

			for (var row = 0; row < 3; row++)
            {
                Console.WriteLine($"{row}{PrintToken(board[0, row])}|{PrintToken(board[1, row])}|{PrintToken(board[2, row])}");
                if (row < 2)
                    Console.WriteLine(" -+-+-");
            }
        }

	    private void PrintState(State state)
	    {
	        switch (state)
	        {
                case State.PlayerOneWinner:
                    Console.WriteLine("*** Spieler 1 gewinnt");
	                break;
                case State.PlayerTwoWinner:
                    Console.WriteLine("*** Spieler 2 gewinnt");
                    break;
                case State.Tie:
                    Console.WriteLine("*** Unentschieden");
                    break;
                case State.Error:
                    Console.WriteLine("Ungültige Eingabe");
                    break;
            }
	    }

	    private char PrintToken(Token token)
	    {
	        switch (token)
	        {
                case Token.PlayerOne:
	                return 'X';
                case Token.PlayerTwo:
	                return 'O';
                default:
	                return ' ';
	        }

	    }

		public void GetCommand(Action<Coordinate> onCoordinate , Action onReset)
		{
		    while (true)
		    {
		        Console.Write("Kommando: ");
		        var command = Console.ReadLine()?.ToLower();

				if (command == null)
					continue;

				if (command.Equals("neu"))
		        {
		            onReset();
		        }
		        if (command.Equals("ende"))
		        {
		            return;
		        }
		        if (command.Length == 2 && new[] {'a', 'b', 'c'}.Contains(command[0]) &&
		            new[] {'0', '1', '2'}.Contains(command[1]))
		        {
		            onCoordinate(new Coordinate((byte) command[0] - (byte) 'a', int.Parse(command[1].ToString())));
		        }
		    }
		}
	}
}