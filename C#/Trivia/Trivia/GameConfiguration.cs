using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyTrivia;

namespace Trivia
{
	public class GameConfiguration
	{
		public Game StartGame(Action<string> eventHandler, params string[] players)
		{
			Game game = new Game(eventHandler);
			foreach (var player in players)
			{
				game.add(player);
			}
			return game;
		}
	}
}
