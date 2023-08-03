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

        // Group Box 가져오기
        var groupBox = root.Q<GroupBox>("Result");
        var groupBox2 = root.Q<GroupBox> ("LvResult");

        // 변수 값을 표시할 Label 생성
        HPLabel = new Label();
        PowerLabel = new Label();
        SpeedLabel = new Label();
        DEFLabel = new Label();
        LvLabel = new Label();
        ExpLabel = new Label();
        SkillptLabel = new Label();

        //색상 설정
        HPLabel.style.color = new StyleColor(Color.white);
        PowerLabel.style.color = new StyleColor(Color.white);
        SpeedLabel.style.color = new StyleColor(Color.white);
        DEFLabel.style.color = new StyleColor(Color.white);
        LvLabel.style.color = new StyleColor(Color.white);
        ExpLabel.style.color = new StyleColor(Color.white);
        SkillptLabel.style.color = new StyleColor(Color.white);

        // Group Box에 Label 추가
        groupBox.Add(HPLabel);
        groupBox.Add(PowerLabel);
        groupBox.Add(SpeedLabel);
        groupBox.Add(DEFLabel);

        groupBox2.Add(LvLabel);
        groupBox2.Add(ExpLabel);
        groupBox2.Add(SkillptLabel);

        // 변수 값 설정
        HP = PlayerState.PlayerHP;
        Power = PlayerState.PlayerATK;
        Speed = PlayerState.PlayerATK_Rate;
        DEF = PlayerState.PlayerDEF;
        Lv = PlayerState.PlayerLevel;
        Exp = PlayerState.PlayerEXP;
        SkillPt = PlayerState.SkillPoint;

        // Label에 변수 값을 표시
        HPLabel.text = HP.ToString();
        PowerLabel.text = Power.ToString();
        SpeedLabel.text = Speed.ToString();
        DEFLabel.text = DEF.ToString();

        LvLabel.text = Lv.ToString();
        ExpLabel.text = Exp.ToString();
        SkillptLabel.text = SkillPt.ToString();
        
        //셀렉트 창 비활성화

        if (SkillPt > 0)
        {
            var SelBox = uidocument.rootVisualElement.Q<VisualElement>("LevelUpSelect");
            //추후 스킬 완성되면 스킬 트리 추가 예정. USS는 제작 완료
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
