﻿
public abstract class Player
{
    public int Bits;
    public string MarkText { get; private set; }
    public string TurnText { get; private set; }
    public bool IsHuman { get; private set; }

    public Player(string markText, string turnText, bool isHuman)
    {
        MarkText = markText;
        TurnText = turnText;
        IsHuman = isHuman;
    }

    public abstract void SelectGameSquare(TicTacToeButton[] squares);
}
