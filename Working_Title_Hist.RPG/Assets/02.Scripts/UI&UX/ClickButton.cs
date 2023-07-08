using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml.Linq;
using UnityEditor;
using UnityEngine;
using UnityEngine.UIElements;
public class ClickButton : MonoBehaviour
{
    public string AttackBtn;
    public UIDocument UIDocument;
    private Button attackclick;
    private int clickCount;

    public Weapon_Sword Weapon_Sword;

    void Awake()
    {
        attackclick = UIDocument.rootVisualElement.Q<Button>("Attack");
        attackclick.clicked += AttackBtnClickHandler;
    }

    void AttackBtnClickHandler()
    {
        StartCoroutine(ProcessClickEvent());
    }

    IEnumerator ProcessClickEvent()
    {

        

        clickCount++;

        yield return null;

        if (clickCount == 1)
        {
            Debug.Log("공격");

            Weapon_Sword.Use();

            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(false);
            PlayerAnim.SetPlayerAttack(true);
            
            yield return new WaitForSeconds(1f);
            PlayerAnim.SetPlayerAttack(false);
            
            clickCount = 0;
        }
    }

    // Update is called once per frame
        void Update()
    {

    }
}
