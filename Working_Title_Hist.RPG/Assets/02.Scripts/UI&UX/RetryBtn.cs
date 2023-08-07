using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class RetryBtn : MonoBehaviour
{
    public UIDocument uiDocument;

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

        //체력 원상복귀
        PlayerState.PlayerHP = 100;

        //씬 리로드
        SceneManager.LoadScene("SampleScene");
    }
}
