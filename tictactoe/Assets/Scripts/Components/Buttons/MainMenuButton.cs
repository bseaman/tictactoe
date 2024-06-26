using UnityEngine;

public class MainMenuButton : MonoBehaviour
{
    public void Select()
    {
        App.Instance.Restart();
    }
}
