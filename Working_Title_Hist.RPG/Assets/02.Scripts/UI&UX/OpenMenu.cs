using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;

public class OpenMenu : MonoBehaviour
{
    // �޴� UIâ Ű�� ���� UIâ ��Ȱ��ȭ
    [SerializeField]
    private UIDocument uiDocument;
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    private Button uxmlButton;

    private void OnEnable()
    {
        // UXML���� ������ Button ��Ҹ� �����ɴϴ�.
        uxmlButton = uiDocument.rootVisualElement.Q<Button>("MenuOpen");

        // Button Ŭ�� �̺�Ʈ�� ���� �ڵ鷯�� ����մϴ�.
        uxmlButton.clicked += OnButtonClick;
    }
    private void OnDisable()
    {
        // �ڵ鷯�� �����մϴ�.
        if (uxmlButton != null)
        {
            uxmlButton.clicked -= OnButtonClick;
        }
    }

    private void OnButtonClick()
    {
        // objectToDisable�� ��Ȱ��ȭ�մϴ�.
        objectToDisable.SetActive(false);

        // objectToEnable�� Ȱ��ȭ�մϴ�.
        objectToEnable.SetActive(true);
    }
}
