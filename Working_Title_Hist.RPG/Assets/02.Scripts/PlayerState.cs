using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    public static float PlayerHP = 100.0f;
    public static float PlayerNowHP = 100.0f;
    public static float PlayerATK = 100.0f;
    public static float PlayerATK_Rate = 1.0f;
    public static float PlayerDEF = 5.0f;
    public float PlayerMOV = 5.0f;
    public float PlayerIVC = 1.0f;
    public float IVC_Time = 0.0f;
    private bool IsIVC = false;
    public float rotationSpeed = 5f;

    public static int PlayerLevel = 1;
    public static float PlayerEXP = 0.0f;
    public static float MaxEXP = 50.0f;
    public static int SkillPoint = 0;

    public bool isFire = false;
    public bool isWater = false;
    public bool isTree = false;
    public bool isSteel = false;
    public bool isEarth = false;

    public Transform P_Transform;
    private Transform closestEnemy;

    private List<Transform> enemyTransforms = new List<Transform>();

    public enum Player_State
    {
        IDLE,
        WALK,
        ATTACK,
        DAMAGED,
        DIE
    }

    void Start()
    {

    }

    void Update()
    {
        StartCoroutine(InvincibleTime());

        LevelUp();

        Debug.Log(PlayerEXP);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "E_Spear")
        {
            if(IsIVC == false)
            {
                StartCoroutine(DamageEffect());
                IsIVC = true;
            }
        }
        if (other.gameObject.tag == "E_Arrow")
        {
            if (IsIVC == false)
            {
                StartCoroutine(DamageEffect());
                IsIVC = true;
            }
        }
    }

    IEnumerator InvincibleTime()
    {
        if(IsIVC == true)
        {
            IVC_Time += Time.deltaTime;
            if(IVC_Time > PlayerIVC)
            {
                IsIVC = false;
                IVC_Time = 0;
            }
        }
        yield return new WaitForSeconds(0.0f);
    }

    IEnumerator DamageEffect()
    {
        if (PlayerHP > 0)
        {
            PlayerNowHP -= 10.0f;
            Debug.Log(PlayerNowHP);
            HPBarManager.DamagedPlayer();
            yield return new WaitForSeconds(0.2f);
        }

        else
        {
            yield return new WaitForSeconds(1f);
            Time.timeScale = 0.0f;
        }

    }

    void LevelUp()
    {
        if(PlayerEXP >= MaxEXP)
        {
            MaxEXP += 50.0f;
            SkillPoint++;
            PlayerLevel++;
        }
    }

    IEnumerator ChooseTrait()
    {
        if(PlayerLevel == 10)
        {
            //���� ���� ���Ƿ� �־��
            yield return new WaitForSeconds(0.0f);
        }
    }
}
