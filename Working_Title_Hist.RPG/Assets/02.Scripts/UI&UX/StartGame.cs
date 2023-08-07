using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class StartGame : MonoBehaviour
{
    public UIDocument root;
    // Start is called before the first frame update
    void Start()
    {
        root.rootVisualElement.Q<Button>("Start").clicked += OnStartButtonClicked;
    }

    // Update is called once per frame
    void OnStartButtonClicked()
    {
        SceneManager.LoadScene("SampleScene");
    }
}
