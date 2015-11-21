using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class CorrectAnswerTest : BaseTest
	{
		[TestMethod]
		public void GoldCoinsIncrease()
		{
			Game.GiveCorrectAnswerAndCheckIfNOTWinner();
			
			Assert.AreEqual(1, Game.GoldCoinPurses[OnlyPlayerIndex]);
		}

		[TestMethod]
		public void WinnerAfterOneCorrectAnswer()
		{
			Assert.AreEqual(0, Game.GoldCoinPurses[OnlyPlayerIndex]);

			var notaWinner = Game.GiveCorrectAnswerAndCheckIfNOTWinner();

			Assert.IsTrue(notaWinner);
		}
	}
}
