using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenMenu : MonoBehaviour
{
    // 메뉴 UI창 키고 전투 UI창 비활성화
    [SerializeField]
    private UIDocument uiDocument;
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    private Button uxmlButton;

    private void OnEnable()
    {
        // UXML에서 생성한 Button 요소
        uxmlButton = uiDocument.rootVisualElement.Q<Button>("MenuOpen");

        // Button 클릭 이벤트에 대한 핸들러를 등록
        uxmlButton.clicked += OnButtonClick;
    }
    private void OnDisable()
    {
        // 핸들러를 해제
        if (uxmlButton != null)
        {
            uxmlButton.clicked -= OnButtonClick;
        }
    }

    private void OnButtonClick()
    {
        //게임을 우선 멈춤
        Time.timeScale = 0.0f;

        // objectToDisable를 비활성화
        objectToDisable.SetActive(false);

        // objectToEnable를 활성화
        objectToEnable.SetActive(true);
    }
}
