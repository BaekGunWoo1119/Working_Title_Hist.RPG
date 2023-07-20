using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    
    public float PlayerHP = 100.0f;
    public static float PlayerATK = 25.0f;
    public static float PlayerATK_Rate = 1.0f;
    public float PlayerDEF = 5.0f;
    public float PlayerMOV = 5.0f;
    public float PlayerIVC = 1.0f;
    public float IVC_Time = 0.0f;
    private bool IsIVC = false;

    public enum Player_State
    {
        IDLE,
        WALK,
        ATTACK,
        DAMAGED,
        DIE
    }

    void Update()
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
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Spear")
        {
            if(IsIVC == false)
            {
                StartCoroutine(DamageEffect());
                IsIVC = true;
            }
        }
        if (other.gameObject.tag == "Arrow")
        {
            if (IsIVC == false)
            {
                StartCoroutine(DamageEffect());
                IsIVC = true;
            }
        }
    }

    IEnumerator DamageEffect()
    {
            PlayerHP -= 10.0f;
            Debug.Log(PlayerHP);
            HPBarManager.DamagedPlayer();
            yield return new WaitForSeconds(0.2f);
    }
}
