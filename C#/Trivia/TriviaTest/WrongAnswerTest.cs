using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Trivia;
using UglyTrivia;

namespace TriviaTest
{
	[TestClass]
	public class WrongAnswerTest : BaseTest
	{
		[TestMethod]
		public void ShouldReturnTrue()
		{
			var actual = Game.wrongAnswer();
			Assert.AreEqual(true, actual);
		}
	}
}
