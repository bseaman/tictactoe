using System;
using TMPro;
using UnityEngine;

public class Game : MonoBehaviour
{
    [SerializeField]
    private Transform _gameBoard;
    [SerializeField]
    private GameObject _gameSquarePrefab;
    [SerializeField]
    private GamePlayScriptableObject _data;
    [SerializeField]
    private TMP_Text _header;

    private TicTacToeButton[] _gameSquares;

    private int _playerIdx;
    private Player[] _players;
    private Player CurrPlayer { get { return _players[_playerIdx]; } }

    private int _numTurns;
    private int _numTurnsToStartScoring;
    
    // Start is called before the first frame update
    void Start()
    {
        InitializeGameBoard();
        InitializePlayers();
    }

    /// <summary>
    /// Creates the game squares and arranges them in a grid formation.
    /// </summary>
    private void InitializeGameBoard()
    {
        _numTurnsToStartScoring = _data.GameBoardDimension * 2 - 1;
        _gameSquares = new TicTacToeButton[_data.GameBoardDimension * _data.GameBoardDimension];

        for(int i = 0; i < _data.GameBoardDimension; i++)
        {
            for (int j = 0; j < _data.GameBoardDimension; j++)
            {
                GameObject instance = Instantiate(_gameSquarePrefab, _gameBoard);
                TicTacToeButton gameSquare = instance.GetComponent<TicTacToeButton>();
                RectTransform transform = instance.GetComponent<RectTransform>();
                _gameSquares[i * _data.GameBoardDimension + j] = gameSquare;
                gameSquare.Selected += OnGameSquareSelect;

                transform.anchoredPosition = new Vector2(j * _data.GameSquareSpacing, i * _data.GameSquareSpacing);
            }
        }
    }

    /// <summary>
    /// Creates the player profiles according to the selected game mode.
    /// </summary>
    private void InitializePlayers()
    {
        const string PlayerOneMark = "X";
        const string PlayerTwoMark = "O";

        _players = new Player[2];

        if (App.Instance.GameMode == GameMode.TwoPlayer)
        {
            _players[0] = new Player(PlayerOneMark, _data.TwoPlayerGamePlayerOneTurn);
            _players[1] = new Player(PlayerTwoMark, _data.TwoPlayerGamePlayerTwoTurn);
        }
        else
        {
            _players[0] = new Player(PlayerOneMark, _data.OnePlayerGamePlayerTurn);
            _players[1] = new Player(PlayerTwoMark, _data.OnePlayerGameOpponentTurn, false);
        }
    }

    /// <summary>
    /// Callback that is invoked when a game square is selected.
    /// Marks the square for the current player, evaluates the
    /// win conditions, and then ends the player's turn.
    /// </summary>
    /// <param name="gameSquare">The game square that was selected.</param>
    private void OnGameSquareSelect(TicTacToeButton gameSquare)
    {
        gameSquare.Selected -= OnGameSquareSelect;

        int idx = Array.IndexOf(_gameSquares, gameSquare);
        if (idx > -1)
        {
            CurrPlayer.Bits += 1 << idx;
            gameSquare.Mark(CurrPlayer.MarkText);
        }

        EndTurn();
    }

    /// <summary>
    /// Ends the current player's turn. Checks if the current
    /// player won and starts the next player's turn if not.
    /// </summary>
    private void EndTurn()
    {
        _numTurns++;

        if (_numTurns >= _numTurnsToStartScoring)
        {
            if (DidPlayerWin(CurrPlayer.Bits, _data.WinPatterns))
            {
                GameResult result = _playerIdx == 0 ? GameResult.PlayerOneWin : GameResult.PlayerOneLose;
                App.Instance.EndGame(result);
                return;
            }
            else if (_numTurns == _gameSquares.Length)
            {
                App.Instance.EndGame(GameResult.Draw);
                return;
            }
        }

        _playerIdx ^= 1;

        _header.text = CurrPlayer.TurnText;
    }

    /// <summary>
    /// Determines whether the player's marked squares satisfy
    /// at least one of the win conditions. 
    /// </summary>
    /// <returns>True if the player's marked squares match one
    /// or more win conditions, False otherwise.</returns>
    private bool DidPlayerWin(int playerBits, int[] winPatterns)
    {
        for (int i = 0; i < winPatterns.Length; i++)
        {
            if (ContainsBits(playerBits, winPatterns[i]))
            {
                return true;
            }
        }

        return false;
    }

    /// <summary>
    /// Determines whether the bits in the mask are set in the given value.
    /// </summary>
    /// <param name="value">The integer to be evaluated.</param>
    /// <param name="mask">An integer containing the required bits.</param>
    /// <returns>True if all of the bits in the mask are set in the value,
    /// False otherwise.</returns>
    private bool ContainsBits(int value, int mask)
    {
        int result = value & mask;

        return result == mask;
    }
}
