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
    public string AttackBtn; // Button 변수 선언
    public UIDocument UIDocument;
    private Button attackclick;
    private int clickCount;
    void Awake()
    {
        // Button 오브젝트 찾아서 할당
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

        yield return null; // 다음 프레임까지 대기

        // 클릭 이벤트가 여러 번 발생해도 로직을 실행하고자 하는 횟수에 맞게 처리
        if (clickCount == 1)
        {
            // 로직 실행
            Debug.Log("버튼맨");

            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(false);
            PlayerAnim.SetPlayerAttack(true);
            //딜레이 이후 공격 애니메이션 제거
            yield return new WaitForSeconds(1f);
            PlayerAnim.SetPlayerAttack(false);
            // 클릭 횟수 초기화
            clickCount = 0;
        }
    }

    // Update is called once per frame
        void Update()
    {

    }
}
