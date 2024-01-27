using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class DialogueSpeaker : MonoBehaviour
{
    private TextMeshProUGUI _textMeshProUGUI;



    public void Speak(string dialog)
    {
        _textMeshProUGUI.text = dialog;
    }
}
