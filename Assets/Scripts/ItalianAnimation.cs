using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class ItalianAnimation : MonoBehaviour
{
    [SerializeField] private Animator handAnimator;

    private void Start()
    {
        CombinationBar.OnBeAngried += PlayAngryHandAnim;
    }

    private void PlayAngryHandAnim()
    {
        handAnimator.Play("Angry Hand Anim");
    }
}
