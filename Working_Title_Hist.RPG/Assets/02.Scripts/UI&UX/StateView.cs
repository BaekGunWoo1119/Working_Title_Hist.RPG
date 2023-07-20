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
    private float HP;
    private float Power;
    private float Speed;
    private float DEF;

    // Start is called before the first frame update
    void OnEnable()
    {
        UIDocument uidocument = GameObject.Find("StateMenu").GetComponent<UIDocument>();
        var root = uidocument.rootVisualElement;

        // Group Box 가져오기
        var groupBox = root.Q<GroupBox>("Result");

        // 변수 값을 표시할 Label 생성
        HPLabel = new Label();
        PowerLabel = new Label();
        SpeedLabel = new Label();
        DEFLabel = new Label();

        //색상 설정
        HPLabel.style.color = new StyleColor(Color.white);
        PowerLabel.style.color = new StyleColor(Color.white);
        SpeedLabel.style.color = new StyleColor(Color.white);
        DEFLabel.style.color = new StyleColor(Color.white);

        // Group Box에 Label 추가
        groupBox.Add(HPLabel);
        groupBox.Add(PowerLabel);
        groupBox.Add(SpeedLabel);
        groupBox.Add(DEFLabel);

        // 변수 값 설정
        HP = PlayerState.PlayerHP;
        Power = PlayerState.PlayerATK;
        Speed = PlayerState.PlayerATK_Rate;
        DEF = PlayerState.PlayerDEF;

        // Label에 변수 값을 표시
        HPLabel.text = HP.ToString();
        PowerLabel.text = Power.ToString();
        SpeedLabel.text = Speed.ToString();
        DEFLabel.text = DEF.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
