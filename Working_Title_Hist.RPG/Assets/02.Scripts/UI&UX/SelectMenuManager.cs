using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using UnityEngine.SceneManagement;

public class SelectManager : MonoBehaviour
{
    [SerializeField]
    private UIDocument uiDocument;

    private Button SwordButton;
    public GameObject MainUI;
    public GameObject ThisUI;

    // Start is called before the first frame update
    void OnEnable()
    {
        Time.timeScale = 0.0f;
        //¸ÞÀÎ UI ²¨µÒ
        MainUI.SetActive(false);
        // Ä® ¼±ÅÃ ¹öÆ° ÁöÁ¤
        SwordButton = uiDocument.rootVisualElement.Q<Button>("Sword");

        // ÇÚµé·¯
        SwordButton.clicked += SwordSelect;
    }
    private void SwordSelect()
    {
        MainUI.SetActive(true);
        ThisUI.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
