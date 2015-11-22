using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UglyTrivia;

namespace Trivia
{
	public class GameConfiguration
	{
		public Game StartGame(Action<string> eventHandler, IPlayersController playersController, params string[] players)
		{
			if (playersController == null)
				playersController = new DummyPlayersContoller();

			Game game = new Game(eventHandler, playersController);
			foreach (var player in players)
			{
				game.add(player);
			}
			return game;
		}

		class DummyPlayersContoller : IPlayersController
		{
			public int CurrentPlayer { get; private set; }
			public void NextPlayerTurn()
			{
			}
		}
	}
}
