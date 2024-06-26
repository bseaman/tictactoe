
public class HumanPlayer : Player
{
    public HumanPlayer(string markText, string turnText)
        : base(markText, turnText, true) { }

    public override void SelectGameSquare(TicTacToeButton[] squares) { }
}
