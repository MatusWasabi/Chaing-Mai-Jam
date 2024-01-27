using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItalianAnimation : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;

    private void Awake()
    {
        CombinationBar.OnBeAngried += PlayAngryHandAnim;
    }

    private void Start()
    {
        HideAnimation();
    }

    private void PlayAngryHandAnim()
    {
        gameObject.SetActive(true);
        handAnimator.Play("Angry Hand Anim");
    }

    public void HideAnimation()
    {
        gameObject.SetActive(false);
    }

    private void OnDestroy()
    {
        CombinationBar.OnBeAngried -= PlayAngryHandAnim;
    }
}
