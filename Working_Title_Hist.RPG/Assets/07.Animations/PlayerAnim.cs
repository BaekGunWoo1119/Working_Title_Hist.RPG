using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    public Animator animator;
    private Vector3 previousPosition;
    void Start()
    {
        // 초기 위치를 이전 위치로 설정
        previousPosition = transform.position;
    }

    void Update()
    {
        Vector3 currentPosition = transform.position;

        // Player의 위치 변화를 감지하여 회전과 애니메이션을 적용
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
