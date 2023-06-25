using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator animator;
    private Vector3 previousPosition;
    void Start()
    {
        // �ʱ� ��ġ�� ���� ��ġ�� ����
        previousPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Player�� ��ġ ��ȭ�� �����Ͽ� ȸ���� �ִϸ��̼��� ����
        if (currentPosition != previousPosition)
        {
            Vector3 moveDirection = currentPosition - previousPosition;
            Quaternion targetRotation = Quaternion.LookRotation(moveDirection);
            transform.rotation = targetRotation;

            if (animator != null)
            {
                animator.SetBool("Walking", true);
                animator.SetBool("Idle", false);
            }
        }
        else
        {
            if (animator != null)
            {
                animator.SetBool("Walking", false);
                animator.SetBool("Idle", true);
            }
        }
    }
}
