using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;

namespace TriviaTest
{
	[TestClass]
	public class PlayerTurnTest : MultiPlayerBaseTest
	{
		[TestMethod]
		public void SecondPlayerTurn()
		{
			var playersController = new PlayersController(2);
			Game = new GameConfiguration().StartGame(
				delegate { },
				playersController,
				CALIN_PLAYER, JOHN_PLAYER);
			AnswerController answerController = new AnswerController(Game.GiveCorrectAnswerAndCheckIfNOTWinner, Game.wrongAnswer);
			Assert.AreEqual(FirstPlayerIndex, Game.CurrentPlayer);
			Assert.AreEqual(FirstPlayerIndex, playersController.CurrentPlayer);

			answerController.GiveAnswer(new Random().Next(9));

			Assert.AreEqual(SecondPlayerIndex, Game.CurrentPlayer);
			Assert.AreEqual(SecondPlayerIndex, playersController.CurrentPlayer);

		}


		[TestMethod]
		public void ThirdPlayerTurn()
		{
			var playersController = new PlayersController(3);
			Game = new GameConfiguration().StartGame(
							delegate { },
							playersController,
							CALIN_PLAYER, JOHN_PLAYER, ANDREW_PLAYER);
			AnswerController answerController = new AnswerController(Game.GiveCorrectAnswerAndCheckIfNOTWinner, Game.wrongAnswer);

			answerController.GiveAnswer(new Random().Next(9));
			answerController.GiveAnswer(new Random().Next(9));

			Assert.AreEqual(ThirdPlayerIndex, Game.CurrentPlayer);
			Assert.AreEqual(ThirdPlayerIndex, playersController.CurrentPlayer);
		}

	}
}
