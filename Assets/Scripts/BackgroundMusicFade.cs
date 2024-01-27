using UnityEngine;
using DG.Tweening;

public class BackgroundMusicFade : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField][Range(0f, 1f)] private float maxVolume = 0.3f;
    [SerializeField] private float fadeDuration = 2f;

    private void Start()
    {
        audioSource.volume = 0f;
        audioSource.DOFade(maxVolume, fadeDuration).SetEase(Ease.InSine);
    }
}
