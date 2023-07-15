using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HPBarManager : MonoBehaviour
{
    public UIDocument UIDocument;
    private ProgressBar progressBar;
    private float currentValue = 0f;
    private float maxValue = 100f;
    // Start is called before the first frame update
    void OnEnable()
    {
        var root = UIDocument.rootVisualElement;
        progressBar = root.Q<ProgressBar>("UserHP");

        // 초기 값 설정
        progressBar.value = maxValue;
    }

    // Update is called once per frame
    public static void DamagedPlayer()
    {
        UIDocument Document = GameObject.Find("UIDocument").GetComponent<UIDocument>();
        var root = Document.rootVisualElement;
        ProgressBar progressBar = progressBar = root.Q<ProgressBar>("UserHP");
        float currentValue = progressBar.value;
        float maxValue = 100f;

        // value 값 감소
        currentValue -= 10.0f;
        //애니메이션
        PlayerAnim.SetWalkingAnimation(false);
        PlayerAnim.SetIdleAnimation(false);
        PlayerAnim.SetPlayerAttack(false);
        PlayerAnim.SetPlayerDamage(true);

        if (currentValue == 0)
        {
            currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(false);
            PlayerAnim.SetPlayerAttack(false);
            PlayerAnim.SetPlayerDie(true);
        }

        // value 값에 따라 채워진 바 업데이트
        progressBar.value = currentValue;
    }
}
