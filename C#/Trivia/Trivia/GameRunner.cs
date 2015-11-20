using System;
using System.IO;
using UglyTrivia;

namespace Trivia
{
    public class GameRunner
    {

        private static bool _notAWinner;
		static FileStream _ostrm;
		static StreamWriter _writer;
	    private const int CHANGE_ITERATION = 5;

	    public static void Main(String[] args)
	    {
		    int seed = 5678;

		    for (int i = 0; i < 10000; i++)
		    {
				int mySeed = seed + i * 313;
				CreateFile(i, mySeed);

			    Game aGame = new Game(Console.WriteLine);

			    aGame.add("Chet");
			    aGame.add("Pat");
			    aGame.add("Sue");
			    try
			    {
				    Random rand = new Random(mySeed);

				    do
				    {
					    aGame.roll(rand.Next(5) + 1);

					    if (rand.Next(9) == 7)
					    {
						    _notAWinner = aGame.wrongAnswer();
					    }
					    else
					    {
						    _notAWinner = aGame.wasCorrectlyAnswered();
					    }
				    } while (_notAWinner);
			    }
			    catch (Exception ex)
			    {
				    Console.WriteLine(ex);
			    }
				CloseStream();
		    }
	    }


	    static void CloseStream()
	    {
			_writer.Close();
			_ostrm.Close();
	    }

	    static void CreateFile(int index, int seed)
	    {
			try
			{
				var path = "../../Change"+ CHANGE_ITERATION;
				//var path = "../../GoldenMaster";
				Directory.CreateDirectory(path);
				_ostrm = new FileStream(string.Format("{2}/Game{0}_{1}.txt", index, seed, path), FileMode.OpenOrCreate, FileAccess.Write);
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
    }

}

