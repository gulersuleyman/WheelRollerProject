using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CharacterAnimation : MonoBehaviour
{
    Animator _animator;


    private void Awake()
    {
        _animator = GetComponentInChildren<Animator>();
    }
    public void RunningAnimation(bool isRunning)
    {
        if (isRunning == _animator.GetBool("isRunning")) return;

        _animator.SetBool("isRunning", isRunning);
    }

    public void FallingAnimation(bool isFalling)
    {
        if (isFalling == _animator.GetBool("isFalling")) return;

        _animator.SetBool("isFalling", isFalling);
    }
}
