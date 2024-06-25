using UnityEngine;

public class GameModeButton : MonoBehaviour
{
    [SerializeField]
    private GameMode gameMode;

    public void Select()
    {
        App.Instance.StartGame(gameMode);
    }
}
