using UnityEngine;

[CreateAssetMenu(fileName = "GamePlayData", menuName = "ScriptableObjects/GamePlayScriptableObject", order = 1)]
public class GamePlayScriptableObject : ScriptableObject
{
    public int GameBoardDimension;
    public float GameSquareSpacing;
    public int[] WinPatterns;
    public string OnePlayerGamePlayerTurn;
    public string OnePlayerGameOpponentTurn;
    public string TwoPlayerGamePlayerOneTurn;
    public string TwoPlayerGamePlayerTwoTurn;
}
