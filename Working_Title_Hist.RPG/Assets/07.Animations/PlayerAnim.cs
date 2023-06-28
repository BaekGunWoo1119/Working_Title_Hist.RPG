using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnim
{
    public static void SetWalkingAnimation(bool Walking)
    {
        Animator animator = GameObject.Find("example_model").GetComponent<Animator>();
        animator.SetBool("Walking", Walking);
    }

    public static void SetIdleAnimation(bool Idle)
    {
        Animator animator = GameObject.Find("example_model").GetComponent<Animator>();
        animator.SetBool("Idle", Idle);
    }
}