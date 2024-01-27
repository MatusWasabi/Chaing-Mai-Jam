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
            //Vector3 currCharOffset = animator.GetCharOffset(i);
            sequence.Join(animator.DOFadeChar(i, 1f, letterAnimationTime));
            sequence.PrependInterval(timeBetweenLetters);
        }
        /*for (int i = 0; i < animator.textInfo.characterCount; ++i)
        {
            if (!animator.textInfo.characterInfo[i].isVisible) continue;
            //Vector3 currCharOffset = animator.GetCharOffset(i);
            sequence.Join(animator.DOFadeChar(i, 1f, 0.4f));
            sequence.PrependInterval(0.05f);
            //sequence.Join(animator.DOOffsetChar(i, currCharOffset + new Vector3(0, 30, 0), 1));
        }*/
    }
}
