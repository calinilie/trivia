using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

namespace TriviaTest
{
	[TestClass]
	public class MultiPlayerRollDiceTest :MultiPlayerBaseTest
	{
		[TestMethod]
		public void TwoPlayerRoll()
		{
			Game = new GameConfiguration().StartGame(
				delegate { }, 
				null,
				CALIN_PLAYER, JOHN_PLAYER);
			 AnswerController answerController = new AnswerController(Game.GiveCorrectAnswerAndCheckIfNOTWinner, Game.wrongAnswer);

			Assert.AreEqual(CalinPayerIndex, Game.CurrentPlayer);
			Game.Roll(3);
			answerController.GiveAnswer(new Random().Next(9));
			Assert.AreEqual(JohnPlayerIndex, Game.CurrentPlayer);
				
		}


		[TestMethod]
		public void ThreePlayerRoll()
		{
			Game = new GameConfiguration().StartGame(
							delegate { },
							null,
							CALIN_PLAYER, JOHN_PLAYER, ANDREW_PLAYER);
			AnswerController answerController = new AnswerController(Game.GiveCorrectAnswerAndCheckIfNOTWinner, Game.wrongAnswer);

			Game.Roll(4);
			answerController.GiveAnswer(new Random().Next(9));
			Game.Roll(3);
			answerController.GiveAnswer(new Random().Next(9));

			Assert.AreEqual(AndrewPlayerIndex, Game.CurrentPlayer);
		}

	}
}
