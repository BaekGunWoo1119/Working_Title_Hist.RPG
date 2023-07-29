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
    private Button BowButton;
    private Button SpearButton;

    public GameObject MainUI;
    public GameObject ThisUI;

    public WeaponCtrl WeaponCtrl;

    // Start is called before the first frame update
    void OnEnable()
    {
        Time.timeScale = 0.0f;
        //메인 UI 꺼둠
        MainUI.SetActive(false);
        // 칼 선택 버튼 지정
        SwordButton = uiDocument.rootVisualElement.Q<Button>("Sword");
        BowButton = uiDocument.rootVisualElement.Q<Button>("Bow");
        SpearButton = uiDocument.rootVisualElement.Q<Button>("Spear");

        //버튼 핸들러
        SwordButton.clicked += SwordSelect;
        BowButton.clicked += BowSelect;
        SpearButton.clicked += SpearSelect;
    }
    private void SwordSelect()
    {
        WeaponCtrl.type = WeaponCtrl.Weapon_Type.SWORD;
        WeaponCtrl.Weapon_Change();
        MainUI.SetActive(true);
        ThisUI.SetActive(false);
    }

    private void BowSelect()
    {
        WeaponCtrl.type = WeaponCtrl.Weapon_Type.BOW;
        WeaponCtrl.Weapon_Change();
        MainUI.SetActive(true);
        ThisUI.SetActive(false);
    }

    private void SpearSelect()
    {
        WeaponCtrl.type = WeaponCtrl.Weapon_Type.SPEAR;
        WeaponCtrl.Weapon_Change();
        MainUI.SetActive(true);
        ThisUI.SetActive(false);
    }


    // Update is called once per frame
    void Update()
    {
        
    }
}
