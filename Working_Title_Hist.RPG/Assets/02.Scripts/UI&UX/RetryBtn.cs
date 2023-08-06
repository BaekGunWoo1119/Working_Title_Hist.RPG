using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class RetryBtn : MonoBehaviour
{
    public UIDocument uiDocument;
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    private Button uxmlButton;

    private void OnEnable()
    {
        // UXML에서 생성한 Button 요소
        uxmlButton = uiDocument.rootVisualElement.Q<Button>("Retry");

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
        //게임을 다시 재생
        Time.timeScale = 1.0f;

        //게임 요소 초기화
        GameObject.Find("Player").transform.position = Vector3.zero;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        //피 100으로 변경
        PlayerState.PlayerHP = 100;
        // objectToDisable를 비활성화
        objectToDisable.SetActive(false);

        // objectToEnable를 활성화
        objectToEnable.SetActive(true);
    }
}
