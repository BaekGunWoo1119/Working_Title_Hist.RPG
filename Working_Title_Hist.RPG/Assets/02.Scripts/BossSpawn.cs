using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class BossSpawn : MonoBehaviour
{
    public GameObject Boss;
    public Transform BossSpawnerTr;
    // Update is called once per frame

    public UIDocument UIDocument;
    public GameObject Scenario;
    private ProgressBar progressBar;
    private float currentValue = 0f;
    private float maxValue = 100f;


    private void Start()
    {
        BossSpawnerTr = GameObject.Find("BossSpawner").GetComponent<Transform>();
    }
    
    void OnEnable()
    {
        var root = UIDocument.rootVisualElement;
        progressBar = root.Q<ProgressBar>("BossHP");
        var Label = progressBar.Q<Label>();
        progressBar.style.display = DisplayStyle.None;

        currentValue = maxValue;
        progressBar.value = maxValue;
        Label.text = progressBar.value.ToString();
    }

    void BossDamaged()
    {
        currentValue -= 10.0f;
    }

    void Update()
    {
        if (Timer.Min == 0 && Timer.Sec == 0)
        {
            Scenario.SetActive(true);
            Debug.Log("보스 소환");
            Instantiate(Boss, BossSpawnerTr.position, BossSpawnerTr.rotation);
            progressBar.style.display = DisplayStyle.Flex;
        }

        if (Timer.Min == 1 && Timer.Sec == 3 && currentValue == 0)
        {
            GameManager.BossDead();
        }

        if (Scenario.activeSelf)
        {
            Time.timeScale = 0.0f;
        }

        else
        {
            Time.timeScale = 1.0f;
        }

    }

}
