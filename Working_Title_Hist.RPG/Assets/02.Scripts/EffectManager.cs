using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject targetObject; // ���� ������Ʈ�� Inspector â���� �����մϴ�.
    public Vector3 offset; // ����� Trail Renderer ���� �Ÿ��� �����ϱ� ���� �����°��Դϴ�.
    private TrailRenderer trailRenderer;
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
            // Trail Renderer�� ��ġ�� ���� ������Ʈ ��ġ�� �������� ���� ������ �����մϴ�.
            //transform.position = targetObject.transform.position + offset;
    }
}
