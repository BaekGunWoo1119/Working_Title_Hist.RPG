using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerAnim
{
    public static void SetWalkingAnimation(bool Walking)
    {
        Animator animator = GameObject.Find("Player").GetComponent<Animator>();
        animator.SetBool("Walking", Walking);
    }

    public static void SetIdleAnimation(bool Idle)
    {
        Animator animator = GameObject.Find("Player").GetComponent<Animator>();
        animator.SetBool("Idle", Idle);
    }

    public static void SetPlayerAttack(bool Attack)
    {
        Animator animator = GameObject.Find("Player").GetComponent<Animator>();
        animator.SetBool("Attack", Attack);
    }
}