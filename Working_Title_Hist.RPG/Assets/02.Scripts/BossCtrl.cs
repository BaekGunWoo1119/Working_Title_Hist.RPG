using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;


public class BossCtrl : MonoBehaviour
{
    public GameObject Boss;
    public Transform BossSpawnerTr;
    // Update is called once per frame

    //체력바 코드
    public UIDocument UIDocument;
    private ProgressBar progressBar;
    private float currentValue = 0f;
    private float maxValue = 100f;

    private void Start()
    {
        BossSpawnerTr = GameObject.Find("BossSpawner").GetComponent<Transform>();
    }
    
    //체력바 관련 코드 나중에 날려도 됨
    void OnEnable()
    {
        var root = UIDocument.rootVisualElement;
        progressBar = root.Q<ProgressBar>("BossHP");
        var Label = progressBar.Q<Label>();
        //보스 체력바 처음엔 비활성화
        progressBar.style.display = DisplayStyle.None;

        // 초기 값 설정
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
        if (Timer.Min == 1 && Timer.Sec == 0)
        {
            Debug.Log("보스 소환!");
            Instantiate(Boss, BossSpawnerTr.position, BossSpawnerTr.rotation);
            progressBar.style.display = DisplayStyle.Flex;
        }

        if (Timer.Min == 1 && Timer.Sec == 3 && currentValue == 0)
        {
            GameManager.BossDead();
        }
    }
}
