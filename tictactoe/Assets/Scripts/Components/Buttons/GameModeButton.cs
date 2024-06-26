using UnityEngine;

public class GameModeButton : MonoBehaviour
{
    [SerializeField]
    private GameMode _gameMode;

    public void Select()
    {
        App.Instance.StartGame(_gameMode);
    }
}
