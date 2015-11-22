using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class MultiPlayerRollDiceTest :MultiPlayerBaseTest
	{
		[TestMethod]
		public void TwoPlayerRoll()
		{
			Game = new TwoPlayerRollGameConfiguration().StartGame();

			Assert.AreEqual(CalinPayerIndex, Game.CurrentPlayer);
			Game.Roll(3);
			Assert.AreEqual(JohnPlayerIndex, Game.CurrentPlayer);
				
		}

#region two player roll subclasses
		class TwoPlayerRollGameConfiguration : GameConfiguration
		{
			public Game StartGame()
			{
				Game game = new TwoPlayerRollGame(delegate { });
				game.add(CALIN_PLAYER);
				game.add(JOHN_PLAYER);
				return game;
			}
		}

		class TwoPlayerRollGame : Game
		{
			public TwoPlayerRollGame(Action<string> actionHandler) 
				: base(actionHandler)
			{
			}

			public override void Roll(int roll)
			{
				base.Roll(roll);
				if (roll%3 == 0)
					GiveCorrectAnswerAndCheckIfNOTWinner();
				else
					wrongAnswer();
			}
		}
#endregion


		[TestMethod]
		public void ThreePlayerRoll()
		{
			Game = new ThreePlayerRollGameConfiguration().StartGame();

			Game.Roll(4);
			Game.Roll(3);

			Assert.AreEqual(AndrewPlayerIndex, Game.CurrentPlayer);
		}


#region three player roll 

		class ThreePlayerRollGameConfiguration : GameConfiguration
		{
			public Game StartGame()
			{
				Game game = new ThreePlayerRollGame();
				game.add(CALIN_PLAYER);
				game.add(JOHN_PLAYER);
				game.add(ANDREW_PLAYER);
				return game;
			}
		}

		class ThreePlayerRollGame : Game
		{
			public ThreePlayerRollGame()
				: base(delegate { })
			{
			}

			public override void Roll(int roll)
			{
				base.Roll(roll);
				if (roll % 3 == 0)
					GiveCorrectAnswerAndCheckIfNOTWinner();
				else
					wrongAnswer();
			}
		}

#endregion

	}
}
