using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;

public class GIma_EnemyCtrl : MonoBehaviour
{
    public float speed;
    public float Rushspeed;
    public float HP = 100.0f;
    public float MaxHP = 100.0f;
    public float DEF = 5.0f;
    private GameObject Player;
    bool isLive;
    private Transform Playertr;

    void Start()
    {
        Playertr = GameObject.FindGameObjectWithTag("Player").transform;
        transform.LookAt(Playertr);
    }

    // Update is called once per frame
    void Update()
    {
        if (Vector3.Distance(Playertr.position, transform.position) > 15.0f)
        {
            transform.LookAt(Playertr);
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if (Vector3.Distance(Playertr.position, transform.position) < 15.0f)
        {
            StartCoroutine(Rush());
        }
    }
    IEnumerator Rush()
    {
        transform.position += transform.forward * Rushspeed * Time.deltaTime;
        speed = 0;
        yield return new WaitForSeconds(5f);
        speed = 15;
    }
    private void OnEnable()
    {
        HP = MaxHP;
        isLive = true;
    }

    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag == "Area")
        {
            gameObject.SetActive(false);
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag == "Sword")
        {
            HP = HP - (PlayerState.PlayerATK - DEF);
        }
        if (col.gameObject.tag == "Spear")
        {
            HP = (float)(HP - (PlayerState.PlayerATK * 0.75 - DEF * 0.75));
        }
        if (col.gameObject.tag == "Axe")
        {
            HP = (float)(HP - (PlayerState.PlayerATK - DEF * 0.5));
        }
        if (col.gameObject.tag == "Hammer")
        {
            HP = (float)(HP - (PlayerState.PlayerATK * 1.5 - DEF * 0.5));
        }
        if (col.gameObject.tag == "Arrow")
        {
            HP = (float)(HP - (PlayerState.PlayerATK * 0.75 - DEF * 0.75));
        }
        //스킬 부분 추가
        if (col.gameObject.tag == "Skill")
        {
            HP = 0;
        }

        if (HP <= 0)
        {
            Dead();
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
        PlayerState.PlayerEXP += 10.0f;
    }
}
