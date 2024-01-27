using DG.Tweening;
using TMPro;
using UnityEngine;

public class TextAnimation : MonoBehaviour
{
    [SerializeField] private TMP_Text text;
    [SerializeField] private float letterAnimationTime = 0.2f;
    [SerializeField] private float timeBetweenLetters = 0.02f;

    private void Start()
    {
        ResetText();
        Animate();

        CutsceneController.OnCutsceneFinished += HandleCutsceneFinished;
    }

    private void ResetText()
    {
        text.alpha = 0f;
    }

    private void Animate()
    {
        DOTweenTMPAnimator animator = new(text);
        Sequence sequence = DOTween.Sequence();
        for (int i = animator.textInfo.characterCount - 1; i >= 0; i--)
        {
            if (!animator.textInfo.characterInfo[i].isVisible) continue;
            sequence.Join(animator.DOFadeChar(i, 1f, letterAnimationTime));
            sequence.PrependInterval(timeBetweenLetters);
        }
    }

    public void ChangeText(string text)
    {
        this.text.text = text;
    }

    private void HandleCutsceneFinished()
    {
        Animate();
    }

    private void OnDestroy()
    {
        CutsceneController.OnCutsceneFinished -= HandleCutsceneFinished;
    }
}
