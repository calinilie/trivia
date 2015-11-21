using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class WrongAnswerTest : BaseTest
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
