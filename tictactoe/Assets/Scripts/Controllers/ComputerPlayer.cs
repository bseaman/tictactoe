using System;
using System.Linq;
using System.Threading.Tasks;

public class ComputerPlayer : Player
{
    private readonly int _selectionDelay;

    protected Action<TicTacToeButton[]> _selectionStrategy;

    public ComputerPlayer(string markText, string turnText, int selectionDelay)
        : base(markText, turnText, false)
    {
        _selectionDelay = selectionDelay;
        _selectionStrategy = RandomSelection;
    }

    public override async void SelectGameSquare(TicTacToeButton[] squares)
    {
        await Task.Delay(_selectionDelay);

        _selectionStrategy(squares);
    }

    /// <summary>
    /// Square selection strategy that randomly selects a square from the given set.
    /// </summary>
    /// <param name="squares">The set of game squares from which to select.</param>
    protected void RandomSelection(TicTacToeButton[] squares)
    {
        TicTacToeButton[] unmarkedSquares = squares.Where(square => square.IsSelectable).ToArray();
        int selectionIdx = UnityEngine.Random.Range(0, unmarkedSquares.Length);
        unmarkedSquares[selectionIdx].Select();
    }
}
