using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBoxManager : MonoBehaviour
{
    public Transform target; // ���� ��� ������Ʈ
    public Vector3 offset = new Vector3(0f, 0f, 0f); // ī�޶�� ��� ������Ʈ ������ �Ÿ� �� ���� ����

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
            // ī�޶� ��ġ�� ��� ������Ʈ�� ��ġ�� �����ϵ� offset ��ŭ ������ ��ġ�� ����
            transform.position = target.position + offset;

            // ī�޶� ��� ������Ʈ�� �ٶ󺸵��� ����
            transform.LookAt(target);
        }
    }
}
