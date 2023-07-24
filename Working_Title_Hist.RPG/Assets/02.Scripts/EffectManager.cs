using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EffectManager : MonoBehaviour
{
    public GameObject targetObject; // 무기 오브젝트를 Inspector 창에서 지정합니다.
    public Vector3 offset; // 무기와 Trail Renderer 간의 거리를 조절하기 위한 오프셋값입니다.
    private TrailRenderer trailRenderer;
    void Start()
    {
        trailRenderer = GetComponent<TrailRenderer>();
    }

    void Update()
    {
            // Trail Renderer의 위치를 무기 오브젝트 위치에 오프셋을 더한 값으로 설정합니다.
            //transform.position = targetObject.transform.position + offset;
    }
}
