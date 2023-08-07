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

    //ü�¹� �ڵ�
    public UIDocument UIDocument;
    private ProgressBar progressBar;
    private float currentValue = 0f;
    private float maxValue = 100f;

    private void Start()
    {
        BossSpawnerTr = GameObject.Find("BossSpawner").GetComponent<Transform>();
    }
    
    //ü�¹� ���� �ڵ� ���߿� ������ ��
    void OnEnable()
    {
        var root = UIDocument.rootVisualElement;
        progressBar = root.Q<ProgressBar>("BossHP");
        var Label = progressBar.Q<Label>();
        //���� ü�¹� ó���� ��Ȱ��ȭ
        progressBar.style.display = DisplayStyle.None;

        // �ʱ� �� ����
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
            Debug.Log("���� ��ȯ!");
            Instantiate(Boss, BossSpawnerTr.position, BossSpawnerTr.rotation);
            progressBar.style.display = DisplayStyle.Flex;
        }

        if (Timer.Min == 1 && Timer.Sec == 3 && currentValue == 0)
        {
            GameManager.BossDead();
        }
    }
}
