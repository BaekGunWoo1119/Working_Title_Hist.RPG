using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class S_EnemyCtrl : MonoBehaviour {
    public float speed;
    public float HP = 100.0f;
    public float MaxHP = 100.0f;
    public float DEF = 5.0f;
    private Rigidbody target;
    bool isLive;
    private Transform Playertr;
    private GameObject Player;

    void Awake()
    {
        Player = GameObject.FindGameObjectWithTag("Player");
        Player.GetComponent<PlayerState>();
        Playertr = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    void Update()
    {
        Animator animator = this.GetComponent<Animator>();
        transform.LookAt(Playertr);
        if(Vector3.Distance(Playertr.position, transform.position) > 3.0f){
            transform.position += transform.forward * speed * Time.deltaTime;
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
            //자연스러운 걸음을 위한 방향 조정
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 30f, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else if(Vector3.Distance(Playertr.position, transform.position) < 5.0f){
            //칼 휘두르는 함수
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", true);
            // 칼 휘두를 시 위치 고정
            //transform.position = this.transform.position;
            // 공격에 맞춰서 방향 전환
            Quaternion targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y + 60f, transform.rotation.eulerAngles.z);
            transform.rotation = targetRotation;
        }
        else {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
        }
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
            if (col.gameObject.tag == "Sword"){
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
        if (HP <= 0)
        {
            Dead();
            Debug.Log("E DEAD");
        }
    }
    void Dead()
    {
        gameObject.SetActive(false);
    }
}