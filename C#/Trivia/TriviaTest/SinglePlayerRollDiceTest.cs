using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class SinglePlayerRollDiceTest
	{
		private Game undertest;
		int onlyPlayerIndex = 0;
		string onlyPlayer = "Calin";

		[TestInitialize]
		public void Setup()
		{
			undertest = new GameConfiguration()
				.StartGame(
					eventHandler: delegate { }, 
					players: onlyPlayer);
		}

		[TestMethod]
		public void RollFourTest()
		{
			int diceRoll = 4;

			undertest.Roll(diceRoll);

			Assert.AreEqual(undertest.Places[onlyPlayerIndex], diceRoll);
		}

		[TestMethod]
		public void IsPlayerInPenaltyBoxTest()
		{
			int diceRoll = 4;
			undertest.Roll(diceRoll);
			Assert.AreEqual(undertest.InPenaltyBox[onlyPlayerIndex], false);
		}

		[TestMethod]
		public void AskQuestionAfterRollTest()
		{
			var numberOfQuestions = undertest.PopQuestions.Count + undertest.RockQuestions.Count +
			                        undertest.ScienceQuestions.Count + undertest.SportsQuestions.Count;
			int diceRoll = 4;
			undertest.Roll(diceRoll);


			var newNumberOfQuestions = undertest.PopQuestions.Count + undertest.RockQuestions.Count +
									undertest.ScienceQuestions.Count + undertest.SportsQuestions.Count;
			Assert.IsTrue(newNumberOfQuestions == numberOfQuestions - 1);
		}

	}
}
