using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class HPBarManager : MonoBehaviour
{
    public UIDocument UIDocument;
    private ProgressBar HPBar;
    private ProgressBar EXPBar;
    private float currentValue;
    private float maxValue;
    public GameObject objectToDisable;
    public GameObject objectToEnable;

    // Start is called before the first frame update
    void OnEnable()
    {
        var root = UIDocument.rootVisualElement;
        HPBar = root.Q<ProgressBar>("UserHP");
        var Label = HPBar.Q<Label>();

        // �ʱ� �� ����
        maxValue = PlayerState.PlayerHP;
        currentValue = maxValue;
        HPBar.value = maxValue;
        Label.text = HPBar.value.ToString();
    }

    // Update is called once per frame
    public static void DamagedPlayer()
    {
        UIDocument Document = GameObject.Find("UIDocument").GetComponent<UIDocument>();
        var root = Document.rootVisualElement;
        ProgressBar progressBar = root.Q<ProgressBar>("UserHP");
        float currentValue = progressBar.value;
        float maxValue = 100f;
        var Label = progressBar.Q<Label>();

        // value �� ����
        currentValue -= 10.0f;
        Label.text = currentValue.ToString();
        //�ִϸ��̼�
        PlayerAnim.SetWalkingAnimation(false);
        PlayerAnim.SetIdleAnimation(false);
        PlayerAnim.SetPlayerAttack(false);

        if (currentValue == 0)
        {
            currentValue = Mathf.Clamp(currentValue, 0f, maxValue);
            PlayerAnim.SetWalkingAnimation(false);
            PlayerAnim.SetIdleAnimation(false);
            PlayerAnim.SetPlayerAttack(false);
            PlayerAnim.SetPlayerDie(true);

        }

        // value ���� ���� ä���� �� ������Ʈ
        progressBar.value = currentValue;
    }

    void Update()
    {
        var root = UIDocument.rootVisualElement;
        EXPBar = root.Q<ProgressBar>("UserEXP");
        EXPBar.value = PlayerState.PlayerEXP / PlayerState.MaxEXP * 100.0f;
        var EXP = EXPBar.Q<Label>();
        EXP.text = PlayerState.PlayerEXP.ToString();

        if (HPBar.value == 0)
        {
            // objectToDisable�� ��Ȱ��ȭ�մϴ�.
            objectToDisable.SetActive(false);

            // objectToEnable�� Ȱ��ȭ�մϴ�.
            objectToEnable.SetActive(true);
        }
    }
}
