namespace Trivia
{
	public class PlayersController : IPlayersController
	{
		public PlayersController(int temporaryTotalNumberOfPlayers)
		{
			TemporaryTotalNumberOfPlayers = temporaryTotalNumberOfPlayers;
			CurrentPlayer = 0;
		}

		public int CurrentPlayer { get; private set; }
		public int TemporaryTotalNumberOfPlayers { get; private set; }

		public void NextPlayerTurn()
		{
			CurrentPlayer++;
			if (CurrentPlayer == TemporaryTotalNumberOfPlayers) CurrentPlayer = 0;
		}
	}
}
