using System;

namespace CCD.TicTacToe
{
	internal class App
	{
		public void Run()
		{
			var game=new Game();
			var ui = new UI();

			var gs = game.Reset();

			ui.Print(gs);

			ui.GetCommand(
				c =>
				{
					gs = game.Play(c);
					ui.Print(gs);
				},
				() =>
				{
					gs = game.Reset();
					ui.Print(gs);
				}
				);

		}
	}
}