using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class Timer : MonoBehaviour
{
    public static float Sec;
    public static int Min;

    [SerializeField]
    private UIDocument uiDocument;
    private VisualElement containerElement;
    private Label timerLabel;

    void OnEnable()
    {
        containerElement = uiDocument.rootVisualElement.Q<VisualElement>("MiddlePanel");
        timerLabel = containerElement.Q<Label>("TimerText");
    }

    void Update()
    {
        Sec += Time.deltaTime;
        string timerText = string.Format("{0:D2}   :   {1:D2}", Min, (int)Sec);
        timerLabel.text = timerText;

        if ((int)Sec > 59)
        {
            Sec = 0;
            Min++;
        }
    }
}
