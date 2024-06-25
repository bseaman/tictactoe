using UnityEngine;

[CreateAssetMenu(fileName = "GameResultData", menuName = "ScriptableObjects/GameResultScriptableObject", order = 1)]
public class GameResultScriptableObject : ScriptableObject
{
    public string OnePlayerGamePlayerWins;
    public string OnePlayerGamePlayerLoses;
    public string OnePlayerGameDraw;
    public string TwoPlayerGamePlayerOneWins;
    public string TwoPlayerGamePlayerTwoWins;
    public string TwoPlayerGameDraw;
}
