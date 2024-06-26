using UnityEngine;

public class EndGameButton : MonoBehaviour
{
    [SerializeField]
    private GameResult _gameResult;

    public void Select()
    {
        App.Instance.EndGame(_gameResult);
    }
}
