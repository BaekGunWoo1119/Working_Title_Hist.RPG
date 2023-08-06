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

        //���� ��� �ʱ�ȭ
        GameObject.Find("Player").transform.position = Vector3.zero;
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Enemy");
        foreach (GameObject enemy in enemies)
        {
            Destroy(enemy);
        }
        //�� 100���� ����
        PlayerState.PlayerHP = 100;
        // objectToDisable�� ��Ȱ��ȭ
        objectToDisable.SetActive(false);

        // objectToEnable�� Ȱ��ȭ
        objectToEnable.SetActive(true);
    }
}
