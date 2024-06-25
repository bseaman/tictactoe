using TMPro;
using UnityEngine;

public class ResultText : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        TMP_Text text = GetComponent<TMP_Text>();
        text.text = "Good Job!";
    }
}
