using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace UglyTrivia
{
    public class Game
	{

#region props
		readonly List<string> _players = new List<string>();

	    readonly int[] _places = new int[6];
		public int[] Places
		{
			get { return _places; }
		}

	    readonly int[] _goldCoinPurses = new int[6];
		public int[] GoldCoinPurses
		{
			get { return _goldCoinPurses; }
		}

	    readonly bool[] _inPenaltyBox = new bool[6];
		public bool[] InPenaltyBox
		{
			get { return _inPenaltyBox; }
		}

	    readonly LinkedList<string> _popQuestions = new LinkedList<string>();
	    readonly LinkedList<string> _scienceQuestions = new LinkedList<string>();
	    readonly LinkedList<string> _sportsQuestions = new LinkedList<string>();
	    readonly LinkedList<string> _rockQuestions = new LinkedList<string>();

        int _currentPlayer = 0;
		public int CurrentPlayer
		{
			get { return _currentPlayer; }
		}

	    bool _isGettingOutOfPenaltyBox;
		public bool IsGettingOutOfPenaltyBox
		{
			get { return _isGettingOutOfPenaltyBox; }
		}

	    public LinkedList<string> PopQuestions
	    {
		    get { return _popQuestions; }
	    }

	    public LinkedList<string> ScienceQuestions
	    {
		    get { return _scienceQuestions; }
	    }

	    public LinkedList<string> SportsQuestions
	    {
		    get { return _sportsQuestions; }
	    }

	    public LinkedList<string> RockQuestions
	    {
		    get { return _rockQuestions; }
	    }

	    private readonly Action<string> _actionHandler;

#endregion props

        public Game(Action<string> actionHandler)
        {
	        _actionHandler = actionHandler;

	        for (int i = 0; i < 50; i++)
            {
                _popQuestions.AddLast("Pop Question " + i);
                _scienceQuestions.AddLast(("Science Question " + i));
                _sportsQuestions.AddLast(("Sports Question " + i));
                _rockQuestions.AddLast(createRockQuestion(i));
            }
        }

	    public String createRockQuestion(int index)
        {
            return "Rock Question " + index;
        }

		public bool isPlayable()
        {
            return (howManyPlayers() >= 2);
        }

        public bool add(String playerName)
        {
            _players.Add(playerName);
            _places[howManyPlayers()] = 0;
            _goldCoinPurses[howManyPlayers()] = 0;
            _inPenaltyBox[howManyPlayers()] = false;

            _actionHandler(playerName + " was added");
            _actionHandler("They are player number " + _players.Count);
            return true;
        }

        public int howManyPlayers()
        {
            return _players.Count;
        }

        public virtual void Roll(int roll)
        {
            _actionHandler(_players[_currentPlayer] + " is the current player");
            _actionHandler("They have rolled a " + roll);

			#region playerInPenalyBix
			if (_inPenaltyBox[_currentPlayer])
			{
				if (roll % 2 != 0)
                {
                    _isGettingOutOfPenaltyBox = true;

                    _actionHandler(_players[_currentPlayer] + " is getting out of the penalty box");
                    _places[_currentPlayer] = _places[_currentPlayer] + roll;
                    if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                    _actionHandler(_players[_currentPlayer]
                            + "'s new location is "
                            + _places[_currentPlayer]);
                    _actionHandler("The category is " + currentCategory());
                    askQuestion();
                }
                else
                {
                    _actionHandler(_players[_currentPlayer] + " is not getting out of the penalty box");
                    _isGettingOutOfPenaltyBox = false;
                }
			}
			#endregion
			else
            {
                _places[_currentPlayer] = _places[_currentPlayer] + roll;
                if (_places[_currentPlayer] > 11) _places[_currentPlayer] = _places[_currentPlayer] - 12;

                _actionHandler(_players[_currentPlayer]
                        + "'s new location is "
                        + _places[_currentPlayer]);
                _actionHandler("The category is " + currentCategory());
                askQuestion();
            }
        }

        private void askQuestion()
        {
            if (currentCategory() == "Pop")
            {
                _actionHandler(_popQuestions.First());
                _popQuestions.RemoveFirst();
            }
            if (currentCategory() == "Science")
            {
                _actionHandler(_scienceQuestions.First());
                _scienceQuestions.RemoveFirst();
            }
            if (currentCategory() == "Sports")
            {
                _actionHandler(_sportsQuestions.First());
                _sportsQuestions.RemoveFirst();
            }
            if (currentCategory() == "Rock")
            {
                _actionHandler(_rockQuestions.First());
                _rockQuestions.RemoveFirst();
            }
        }


        private String currentCategory()
        {
            if (_places[_currentPlayer] == 0) return "Pop";
            if (_places[_currentPlayer] == 4) return "Pop";
            if (_places[_currentPlayer] == 8) return "Pop";
            if (_places[_currentPlayer] == 1) return "Science";
            if (_places[_currentPlayer] == 5) return "Science";
            if (_places[_currentPlayer] == 9) return "Science";
            if (_places[_currentPlayer] == 2) return "Sports";
            if (_places[_currentPlayer] == 6) return "Sports";
            if (_places[_currentPlayer] == 10) return "Sports";
            return "Rock";
        }

	    // ReSharper disable once InconsistentNaming
        public bool GiveCorrectAnswerAndCheckIfNOTWinner()
        {
            if (_inPenaltyBox[_currentPlayer])
            {
                if (_isGettingOutOfPenaltyBox)
                {
                    AnswerCorrectlyAndIncreaseGoldCoinsAmount();

                    bool winner = didPlayerWin();

                    NextPlayersTurn();

                    return winner;
                }
                else
                {
                   NextPlayersTurn();
                    return true;
                }
            }
            else
            {
                AnswerCorrectlyAndIncreaseGoldCoinsAmount();

                bool winner = didPlayerWin();
                
				NextPlayersTurn();
                return winner;
            }
        }

	    private void NextPlayersTurn()
	    {
			_currentPlayer++;
			if (_currentPlayer == _players.Count) _currentPlayer = 0;
	    }

	    private void AnswerCorrectlyAndIncreaseGoldCoinsAmount()
	    {
			_actionHandler("Answer was correct!!!!");
			_goldCoinPurses[_currentPlayer]++;
			_actionHandler(_players[_currentPlayer]
					+ " now has "
					+ _goldCoinPurses[_currentPlayer]
					+ " Gold Coins.");
	    }

        public bool wrongAnswer()
        {
            _actionHandler("Question was incorrectly answered");
            _actionHandler(_players[_currentPlayer] + " was sent to the penalty box");
            _inPenaltyBox[_currentPlayer] = true;

            NextPlayersTurn();
            return true;
        }

        private bool didPlayerWin()
        {
            return _goldCoinPurses[_currentPlayer] != 6;
        }

    }

}
