using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
using UnityEngine.UI;

public class CutsceneController : MonoBehaviour
{
    [SerializeField] private GameObject[] objectsToBeDisabled;
    [SerializeField] private GameObject cutscenePanel;
    [SerializeField] private Image tears;
    [SerializeField] private float scaleFactor = 5f;

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
        tears.DOFade(1f, 5f).OnComplete(() => HideCutscene());
    }

    private void OnDestroy()
    {
        CombinationBar.OnBeAngried -= HandleAngryPrompt;
    }
}
