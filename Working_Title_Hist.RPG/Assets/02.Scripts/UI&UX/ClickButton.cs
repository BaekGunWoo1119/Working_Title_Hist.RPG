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
    public string AttackBtn; // Button ���� ����
    public UIDocument UIDocument;
    private Button attackclick;
    private int clickCount;
    void Awake()
    {
        // Button ������Ʈ ã�Ƽ� �Ҵ�
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

        yield return null; // ���� �����ӱ��� ���

        // Ŭ�� �̺�Ʈ�� ���� �� �߻��ص� ������ �����ϰ��� �ϴ� Ƚ���� �°� ó��
        if (clickCount == 1)
        {
            // ���� ����
            Debug.Log("��ư��");

            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(false);
            PlayerAnim.SetPlayerAttack(true);
            //������ ���� ���� �ִϸ��̼� ����
            yield return new WaitForSeconds(1f);
            PlayerAnim.SetPlayerAttack(false);
            // Ŭ�� Ƚ�� �ʱ�ȭ
            clickCount = 0;
        }
    }

    // Update is called once per frame
        void Update()
    {

    }
}
