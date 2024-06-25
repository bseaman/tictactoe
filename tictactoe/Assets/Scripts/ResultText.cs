using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    [SerializeField]
    private GameResultScriptableObject data;

    // Start is called before the first frame update
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
                    return data.TwoPlayerGamePlayerOneWins;
                case GameResult.PlayerOneLose:
                    return data.TwoPlayerGamePlayerTwoWins;
                default:
                    return data.TwoPlayerGameDraw;
            }
        }
        else
        {
            switch (App.Instance.GameResult)
            {
                case GameResult.PlayerOneWin:
                    return data.OnePlayerGamePlayerWins;
                case GameResult.PlayerOneLose:
                    return data.OnePlayerGamePlayerLoses;
                default:
                    return data.OnePlayerGameDraw;
            }
        }
    }
}
