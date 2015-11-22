namespace Trivia
{
	public interface IPlayersController
	{
		int CurrentPlayer { get; }
		void NextPlayerTurn();
	}
}
