using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class CorrectAnswerTest : BaseTest
	{

		private int _player1Index = 0;
		private int _player2Index = 1;

		[TestInitialize]
		public override void Setup()
		{
			base.Setup();
			Game = new GameConfiguration().StartGame(delegate { }, "Calin", "John Doe");
		}

		[TestMethod]
		public void GoldCoinsIncrease()
		{
			Game.GiveCorrectAnswerAndCheckIfNOTWinner();
			
			Assert.AreEqual(1, Game.GoldCoinPurses[_player1Index]);
		}

		[TestMethod]
		public void PlayerStartsWithNoGoldCoins()
		{
			Assert.AreEqual(0, Game.GoldCoinPurses[_player1Index]);
			Assert.AreEqual(0, Game.GoldCoinPurses[_player2Index]);
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
