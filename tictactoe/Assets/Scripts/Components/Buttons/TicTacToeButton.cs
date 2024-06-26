using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TicTacToeButton : MonoBehaviour
{
    [SerializeField]
    private TMP_Text _text;

    public Action<TicTacToeButton> Selected;

    public bool IsSelectable {  get; private set; }
    public bool IsInteractable
    {
        get
        {
            return _button.interactable;
        }
        set
        {
            _button.interactable = value && IsSelectable;
        }
    }

    private Button _button;

    void Awake()
    {
        _button = GetComponent<Button>();

        IsSelectable = true;
    }

    public void Select()
    {
        if (IsSelectable)
        {
            IsSelectable = false;
            IsInteractable = false;

            Selected?.Invoke(this);
        }
    }

    public void Mark(string value)
    {
        _text.text = value;
    }
}
