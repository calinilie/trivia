using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class SinglePlayerRollDiceTest
	{
		private Game _undertest;
		private int onlyPlayerIndex = 0;
		private const string ONLY_PLAYER = "Calin";

		[TestInitialize]
		public virtual void Setup()
		{
			_undertest = new GameConfiguration()
				.StartGame(
					eventHandler: delegate { },
					players: ONLY_PLAYER);
		}
 
		[TestMethod]
		public void RollFourTest()
		{
			int diceRoll = 4;

			_undertest.Roll(diceRoll);

			Assert.AreEqual(_undertest.Places[onlyPlayerIndex], diceRoll);
		}

		[TestMethod]
		public void IsPlayerInPenaltyBoxTest()
		{
			int diceRoll = 4;
			_undertest.Roll(diceRoll);
			Assert.AreEqual(_undertest.InPenaltyBox[onlyPlayerIndex], false);
		}

		[TestMethod]
		public void AskQuestionAfterRollTest()
		{
			var numberOfQuestions = _undertest.PopQuestions.Count + _undertest.RockQuestions.Count +
			                        _undertest.ScienceQuestions.Count + _undertest.SportsQuestions.Count;
			int diceRoll = 4;
			_undertest.Roll(diceRoll);


			var newNumberOfQuestions = _undertest.PopQuestions.Count + _undertest.RockQuestions.Count +
									_undertest.ScienceQuestions.Count + _undertest.SportsQuestions.Count;
			Assert.IsTrue(newNumberOfQuestions == numberOfQuestions - 1);
		}

	}
}
