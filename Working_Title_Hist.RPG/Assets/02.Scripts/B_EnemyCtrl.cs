using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class B_EnemyCtrl : MonoBehaviour
{
    public float speed;
    public float HP = 100.0f;
    public float MaxHP = 100.0f;
    public float DEF = 5.0f;
    public float arrowCoolDown;
    public GameObject Arrow;
    public Transform FirePos;
    private Rigidbody target;
    bool isLive;
    private Transform Playertr;
    private GameObject Player;

    void Awake()
    {
        arrowCoolDown = 3.0f;
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerState>();
        Playertr = GameObject.FindWithTag("Player").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    void Update()
    {
        arrowCoolDown += Time.deltaTime;
        transform.LookAt(Playertr);
        if (Vector3.Distance(Playertr.position, transform.position) > 15.0f)
        {
            transform.position += transform.forward * speed * Time.deltaTime;
            //자연스러운 걸음을 위한 방향 조정
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 30f, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else if (Vector3.Distance(Playertr.position, transform.position) < 20.0f)
        {
            if(arrowCoolDown > 3.0f) 
            { 
                Instantiate(Arrow, FirePos.transform.position, FirePos.transform.rotation);
                arrowCoolDown = 0;
            }
            // 공격에 맞춰서 방향 전환
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 60f, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
    }

    private void OnEnable()
    {
        HP = MaxHP;
        isLive = true;
    }
    void OnTriggerExit(Collider col)
    {
        if(col.gameObject.tag == "Area")
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