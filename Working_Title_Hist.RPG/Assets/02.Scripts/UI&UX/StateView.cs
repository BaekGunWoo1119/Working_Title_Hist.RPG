using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class StateView : MonoBehaviour
{
    private Label HPLabel;
    private Label PowerLabel;
    private Label SpeedLabel;
    private Label DEFLabel;
    private Label LvLabel;
    private Label ExpLabel;
    private Label SkillptLabel;

    private float HP;
    private float Power;
    private float Speed;
    private float DEF;
    private float Lv;
    private float Exp;
    private float SkillPt;

    // Start is called before the first frame update
    void OnEnable()
    {
        UIDocument uidocument = GameObject.Find("StateMenu").GetComponent<UIDocument>();
        var root = uidocument.rootVisualElement;

        // Group Box ��������
        var groupBox = root.Q<GroupBox>("Result");
        var groupBox2 = root.Q<GroupBox> ("LvResult");

        // ���� ���� ǥ���� Label ����
        HPLabel = new Label();
        PowerLabel = new Label();
        SpeedLabel = new Label();
        DEFLabel = new Label();
        LvLabel = new Label();
        ExpLabel = new Label();
        SkillptLabel = new Label();

        //���� ����
        HPLabel.style.color = new StyleColor(Color.white);
        PowerLabel.style.color = new StyleColor(Color.white);
        SpeedLabel.style.color = new StyleColor(Color.white);
        DEFLabel.style.color = new StyleColor(Color.white);
        LvLabel.style.color = new StyleColor(Color.white);
        ExpLabel.style.color = new StyleColor(Color.white);
        SkillptLabel.style.color = new StyleColor(Color.white);

        // Group Box�� Label �߰�
        groupBox.Add(HPLabel);
        groupBox.Add(PowerLabel);
        groupBox.Add(SpeedLabel);
        groupBox.Add(DEFLabel);

        groupBox2.Add(LvLabel);
        groupBox2.Add(ExpLabel);
        groupBox2.Add(SkillptLabel);

        // ���� �� ����
        HP = PlayerState.PlayerHP;
        Power = PlayerState.PlayerATK;
        Speed = PlayerState.PlayerATK_Rate;
        DEF = PlayerState.PlayerDEF;
        Lv = PlayerState.PlayerLevel;
        Exp = PlayerState.PlayerEXP;
        SkillPt = PlayerState.SkillPoint;

        // Label�� ���� ���� ǥ��
        HPLabel.text = HP.ToString();
        PowerLabel.text = Power.ToString();
        SpeedLabel.text = Speed.ToString();
        DEFLabel.text = DEF.ToString();

        LvLabel.text = Lv.ToString();
        ExpLabel.text = Exp.ToString();
        SkillptLabel.text = SkillPt.ToString();
        
        //����Ʈ â ��Ȱ��ȭ

        if (SkillPt > 0)
        {
            var SelBox = uidocument.rootVisualElement.Q<VisualElement>("LevelUpSelect");
            //���� ��ų �ϼ��Ǹ� ��ų Ʈ�� �߰� ����. USS�� ���� �Ϸ�
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
