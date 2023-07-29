using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxManager : MonoBehaviour
{
    public Transform target; // 따라갈 대상 오브젝트
    public Vector3 offset = new Vector3(0f, 0f, 0f); // 카메라와 대상 오브젝트 사이의 거리 및 높이 조절

    public static void WeaponRotate()
    {
        GameObject target = GameObject.FindGameObjectWithTag("Player");
        GameObject weapon = GameObject.Find("WeaponBox");
        weapon.transform.rotation = target.transform.rotation;
    }

    private void LateUpdate()
    {
        if (target != null)
        {
            // 카메라 위치를 대상 오브젝트의 위치로 설정하되 offset 만큼 떨어진 위치로 설정
            transform.position = target.position + offset;

            // 카메라가 대상 오브젝트를 바라보도록 설정
            transform.LookAt(target);
        }
    }
}
