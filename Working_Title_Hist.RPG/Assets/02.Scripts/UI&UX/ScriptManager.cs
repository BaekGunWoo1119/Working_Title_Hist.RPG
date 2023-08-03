using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Reflection.Emit;
using UnityEngine;
using UnityEngine.UIElements;

public class ScriptManager : MonoBehaviour
{
    public TextAsset scriptText;
    [SerializeField]
    private UIDocument uiDocument;
    private UnityEngine.UIElements.Label scriptLabel;

    void OnEnable()
    {
        scriptLabel = uiDocument.rootVisualElement.Q<UnityEngine.UIElements.Label>("Script");
        //string filePath = Path.Combine(Application.streamingAssetsPath, scriptText);
        //StartCoroutine(LoadTextFile(filePath));
        if (scriptText != null)
        {
            string innerText = scriptText.text;
            // txt ������ ������ ������ ���ϴ� �۾��� �����մϴ�.
            scriptLabel.text = innerText;
            scriptLabel.style.whiteSpace = WhiteSpace.Normal;
        }
        else
        {
            Debug.LogError("Text file is not assigned in the Inspector!");
        }
    }
}
