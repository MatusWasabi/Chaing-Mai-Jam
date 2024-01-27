using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;
using System;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToBeDisabled;
    [SerializeField] private GameObject cutscenePanel;
    [SerializeField] private Image tears;

    public static event Action OnCutsceneFinished;

    private void Start()
    {
        CombinationBar.OnBeAngried += HandleAngryPrompt;
    }

    private void HandleAngryPrompt()
    {
        ShowCutscene();
    }

    private void SetAllObjectsState(bool enable)
    {
        foreach (GameObject obj in objectsToBeDisabled)
        {
            obj.SetActive(enable);
        }
    }

    private void ShowCutscene()
    {
        cutscenePanel.SetActive(true);
        SetAllObjectsState(false);
        PlayCutscene();
    }

    private void HideCutscene()
    {
        cutscenePanel.SetActive(false);
        SetAllObjectsState(true);
    }

    private void PlayCutscene(int cutsceneNumber = 0)
    {
        tears.DOFade(0f, 0f);
        _ = tears.DOFade(1f, 5f).OnComplete(() =>
        {       
            HideCutscene();
            OnCutsceneFinished?.Invoke();
        });
    }

    private void OnDestroy()
    {
        CombinationBar.OnBeAngried -= HandleAngryPrompt;
    }
}
