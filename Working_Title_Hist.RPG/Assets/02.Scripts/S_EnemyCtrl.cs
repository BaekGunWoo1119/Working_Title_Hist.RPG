using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class S_EnemyCtrl : MonoBehaviour {
    public float speed;
    private Rigidbody target;
    bool isLive;
    private Transform Playertr;

    void Awake(){
        Playertr = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    void Update(){
        Animator animator = this.GetComponent<Animator>();
        transform.LookAt(Playertr);
        if(Vector3.Distance(Playertr.position, transform.position) > 3.0f){
            transform.position += transform.forward * speed * Time.deltaTime;
            animator.SetBool("Walking", true);
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", false);
        }
        else if(Vector3.Distance(Playertr.position, transform.position) < 5.0f){
            //칼 휘두르는 함수
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", false);
            animator.SetBool("Attack", true);
            // 칼 휘두를 시 위치 고정
            //transform.position = this.transform.position;
        }
        else {
            animator.SetBool("Walking", false);
            animator.SetBool("Idle", true);
            animator.SetBool("Attack", false);
        }
    }
}