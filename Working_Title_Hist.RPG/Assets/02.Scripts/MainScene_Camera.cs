using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainScene_Camera : MonoBehaviour
{
    public float speed = 1.0f; // ī�޶� ������ �ӵ�
    public float amplitude = 10f; // ī�޶� �������� ����

    private Vector3 startPosition;
    private bool movingRight = true;

    private void Start()
    {
        startPosition = transform.position;
    }

    private void Update()
    {
        // �������� �������� ���������� �������� ����
        float direction = movingRight ? 1f : -1f;

        // ī�޶� ���� �Ǵ� ���������� �̵�
        Vector3 newPosition = startPosition + new Vector3(direction * amplitude, 0f, 0f) * Time.deltaTime * speed;
        transform.position = newPosition;

        // ������ ���� ����
        if (Mathf.Abs(transform.position.x - startPosition.x) >= amplitude)
        {
            movingRight = !movingRight;
        }
    }
}
