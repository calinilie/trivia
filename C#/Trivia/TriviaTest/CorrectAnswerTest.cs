using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class CorrectAnswerTest : MultiPlayerBaseTest
	{

		[TestInitialize]
		public void Setup()
		{
			Game = new GameConfiguration().StartGame(delegate { }, CALIN_PLAYER, JOHN_PLAYER);
		}

		[TestMethod]
		public void GoldCoinsIncrease()
		{
			Game.GiveCorrectAnswerAndCheckIfNOTWinner();
			
			Assert.AreEqual(1, Game.GoldCoinPurses[CalinPayerIndex]);
		}

		[TestMethod]
		public void PlayerStartsWithNoGoldCoins()
		{
			Assert.AreEqual(0, Game.GoldCoinPurses[CalinPayerIndex]);
			Assert.AreEqual(0, Game.GoldCoinPurses[JohnPlayerIndex]);
		}

		[TestMethod]
		public void WonAfterOneCorrectAnswer()
		{
			var notaWinner = Game.GiveCorrectAnswerAndCheckIfNOTWinner();

			Assert.IsTrue(notaWinner);
		}

		[TestMethod]
		public void NextPlayerAfterCorrectAnswer()
		{
			Game.GiveCorrectAnswerAndCheckIfNOTWinner();

			Assert.AreEqual(1, Game.CurrentPlayer);
		}
	}
}
