using System;

namespace Trivia
{
	/// <summary>
	/// separate component which controlls the logic on whether an answer is correct or wonrg.
	/// </summary>
	public class AnswerController
	{

		private Func<bool> _correctAnswer;
		private Func<bool> _wrongAnswer;

		public AnswerController(Func<bool> correctAnswer, Func<bool> wrongAnswer)
		{
			_correctAnswer = correctAnswer;
			_wrongAnswer = wrongAnswer;
		}

		public bool GiveAnswer(int input)
		{
			if (input == 7)
			{
				return _wrongAnswer();
			}
			return _correctAnswer();
		}

	}
}
