using UnityEngine;
using UnityEngine.SceneManagement;

public enum GameMode
{
    OnePlayer,
    TwoPlayer
}
public enum GameResult
{
    PlayerOneWin,
    PlayerOneLose,
    Draw
}

public class App : MonoBehaviour
{
    public static App Instance { get; private set; }

    public GameMode GameMode { get; private set; }
    public GameResult GameResult { get; private set; }

    private enum AppState
    {
        None,
        GameSelection,
        GamePlay,
        GameOver
    }

    private AppState _state = AppState.None;
    private AppState State
    {
        set
        {
            if (_state != value)
            {
                _state = value;
                SceneManager.LoadSceneAsync(((int)_state));
            }
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        Instance = this;

        DontDestroyOnLoad(gameObject);

        State = AppState.GameSelection;
    }

    public void StartGame(GameMode mode)
    {
        GameMode = mode;
        State = AppState.GamePlay;
    }

    public void EndGame(GameResult result)
    {
        GameResult = result;
        State = AppState.GameOver;
    }

    public void Restart()
    {
        State = AppState.GameSelection;
    }
}
