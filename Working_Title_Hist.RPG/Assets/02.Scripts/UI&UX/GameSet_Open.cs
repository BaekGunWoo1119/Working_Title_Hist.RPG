using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class GameSet_Open : MonoBehaviour
{
    // �޴� UIâ Ű�� ���� UIâ ��Ȱ��ȭ
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    public void OpenUI()
    {
        // objectToDisable�� ��Ȱ��ȭ�մϴ�.
        objectToDisable.SetActive(false);

        // objectToEnable�� Ȱ��ȭ�մϴ�.
        objectToEnable.SetActive(true);
    }
}