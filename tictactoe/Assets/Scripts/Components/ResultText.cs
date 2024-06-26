using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    private GameResultScriptableObject _data;

    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        text.text = GetResultText();
    }

    private string GetResultText()
    {
        if(App.Instance.GameMode == GameMode.TwoPlayer)
        {
            switch(App.Instance.GameResult)
            {
                case GameResult.PlayerOneWin:
                    return _data.TwoPlayerGamePlayerOneWins;
                case GameResult.PlayerOneLose:
                    return _data.TwoPlayerGamePlayerTwoWins;
                default:
                    return _data.TwoPlayerGameDraw;
            }
        }
        else
        {
            switch (App.Instance.GameResult)
            {
                case GameResult.PlayerOneWin:
                    return _data.OnePlayerGamePlayerWins;
                case GameResult.PlayerOneLose:
                    return _data.OnePlayerGamePlayerLoses;
                default:
                    return _data.OnePlayerGameDraw;
            }
        }
    }
}
