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
    // 메뉴 UI창 키고 전투 UI창 비활성화
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    public void OpenUI()
    {
        // objectToDisable를 비활성화합니다.
        objectToDisable.SetActive(false);

        // objectToEnable를 활성화합니다.
        objectToEnable.SetActive(true);
    }
}