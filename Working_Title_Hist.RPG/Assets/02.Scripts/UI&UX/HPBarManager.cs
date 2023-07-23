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
        var Label = progressBar.Q<Label>();

        // �ʱ� �� ����
        progressBar.value = maxValue;
        Label.text = progressBar.value.ToString();
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
}
