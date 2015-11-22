using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class WrongAnswerTest : MultiPlayerBaseTest
	{

		[TestInitialize]
		public void Setup()
		{
			Game = new GameConfiguration().StartGame(delegate { }, CALIN_PLAYER, JOHN_PLAYER);
		}

		[TestMethod]
		public void ShouldReturnTrue()
		{
			var actual = Game.wrongAnswer();
			Assert.AreEqual(true, actual);
		}

		[TestMethod]
		public void AfterWrongAnswerChangePlayerTurn()
		{
			Game.wrongAnswer();
			Assert.AreEqual(1, Game.CurrentPlayer);
		}
	}
}
