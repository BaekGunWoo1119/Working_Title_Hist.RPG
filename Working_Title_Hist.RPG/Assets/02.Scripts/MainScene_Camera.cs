using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene_Camera : MonoBehaviour
{
    public float speed = 1.0f; // 카메라 움직임 속도
    public float amplitude = 10f; // 카메라 움직임의 진폭

    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // 왼쪽으로 움직일지 오른쪽으로 움직일지 결정
        float direction = movingRight ? 1f : -1f;

        // 카메라를 왼쪽 또는 오른쪽으로 이동
        Vector3 newPosition = startPosition + new Vector3(direction * amplitude, 0f, 0f) * Time.deltaTime * speed;
        transform.position = newPosition;

        // 움직임 방향 변경
        if (Mathf.Abs(transform.position.x - startPosition.x) >= amplitude)
        {
            movingRight = !movingRight;
        }
    }
}
