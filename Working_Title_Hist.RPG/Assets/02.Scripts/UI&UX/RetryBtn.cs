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
        // UXML���� ������ Button ���
        uxmlButton = uiDocument.rootVisualElement.Q<Button>("Retry");

        // Button Ŭ�� �̺�Ʈ�� ���� �ڵ鷯�� ���
        uxmlButton.clicked += OnButtonClick;
    }
    private void OnDisable()
    {
        // �ڵ鷯�� ����
        if (uxmlButton != null)
        {
            uxmlButton.clicked -= OnButtonClick;
        }
    }

    private void OnButtonClick()
    {
        //������ �ٽ� ���
        Time.timeScale = 1.0f;

        //ü�� ���󺹱�
        PlayerState.PlayerHP = 100;

        //�� ���ε�
        SceneManager.LoadScene("SampleScene");
    }
}
