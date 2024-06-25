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
    internal enum AppState
    {
        None,
        GameSelection,
        GamePlay,
        GameOver
    }

    private AppState _state = AppState.None;
    private AppState state {
        get {
            return _state;
        }
        set {
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

        state = AppState.GameSelection;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void StartGame(GameMode mode)
    {
        Debug.LogFormat("Starting game: {0}", mode.ToString());

        state = AppState.GamePlay;
    }

    public void EndGame(GameResult result)
    {
        Debug.LogFormat("Ending game: {0}", result.ToString());

        state = AppState.GameOver;
    }

    public void Restart()
    {
        state = AppState.GameSelection;
    }
}
