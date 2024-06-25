using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    [SerializeField]
    private GameResult gameResult;

    public void Select()
    {
        App.Instance.EndGame(gameResult);
    }
}
