using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class InCounterManager : MonoBehaviour
{
    public UIDocument Canvas;
    public GameObject objectToDisable;

    private void OnEnable()
    {
        objectToDisable.SetActive(false);

        var root = Canvas.rootVisualElement;
        var text = root.Q<Label>("Label");


        // Text ������ �ϴ� Label ��Ҹ� ����
        text.text = "Hello, UI Toolkit!";
    }


}
