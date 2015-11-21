using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	public class BaseTest
	{
		protected Game Game;
		protected int OnlyPlayerIndex = 0;
		private const string ONLY_PLAYER = "Calin";

		[TestInitialize]
		public virtual void Setup()
		{
			Game = new GameConfiguration()
				.StartGame(
					eventHandler: delegate { },
					players: ONLY_PLAYER);
		}
	}
}
