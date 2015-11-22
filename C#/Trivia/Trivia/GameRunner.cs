using System;
using System.IO;
using UglyTrivia;

namespace Trivia
{
	public class GameRunner
	{
		private static bool _notAWinner;
		private static FileStream _ostrm;
		private static StreamWriter _writer;

		public static void Main(String[] args)
		{
			InputParameters input = ReadInput(args);

			for (int i = 0; i < input.Samples; i++)
			{
				int mySeed = input.Seed + i*313;
				CreateFile(i, mySeed, input.Iteration);

				Game aGame = new Game(Console.WriteLine);
				AnswerController answerController = new AnswerController(aGame.GiveCorrectAnswerAndCheckIfNOTWinner, aGame.wrongAnswer);

				aGame.add("Chet");
				aGame.add("Pat");
				aGame.add("Sue");
				try
				{
					Random rand = new Random(mySeed);

					do
					{
						aGame.Roll(rand.Next(5) + 1);

						_notAWinner = answerController.GiveAnswer(rand.Next(9));
					} while (_notAWinner);
				}
				catch (Exception ex)
				{
					Console.WriteLine(ex);
				}
				CloseStream();
			}
		}


		private static void CloseStream()
		{
			_writer.Close();
			_ostrm.Close();
		}

		private static void CreateFile(int index, int seed, int iteration)
		{
			try
			{

				var path = "../../Change" + iteration;
				//var path = "../../GoldenMaster";
				Directory.CreateDirectory(path);
				_ostrm = new FileStream(string.Format("{2}/Game{0}_{1}.txt", index, seed, path), FileMode.OpenOrCreate,
					FileAccess.Write);
				_writer = new StreamWriter(_ostrm);
			}
			catch (Exception e)
			{
				Console.WriteLine("Cannot open Redirect.txt for writing");
				Console.WriteLine(e.Message);
				return;
			}
			Console.SetOut(_writer);
		}


		private static InputParameters ReadInput(string[] args)
		{
			InputParameters input = new InputParameters
			{
				Iteration =  1,
				Samples = 10000,
				Seed = 5678
			};

			if (args == null || args.Length == 0)
				return input;
				

			if (args.Length > 0)
				input.Iteration = ReadInt(args[0]);

			if (args.Length > 1)
				input.Samples = ReadInt(args[1]);

			if (args.Length > 2)
				input.Seed = ReadInt(args[2]);

			return input;
		}

		private static int ReadInt(string arg)
		{
			int retVal;
			if (int.TryParse(arg, out retVal))
				return retVal;

			throw new ArgumentException("All parameters should be int");
		}

		private class InputParameters
		{
			public int Seed { get; set; }
			public int Samples { get; set; }
			public int Iteration { get; set; }
		}
	}
}

