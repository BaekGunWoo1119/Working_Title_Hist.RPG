using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
 
public class B_EnemyCtrl : MonoBehaviour {
    public float speed;
    private Rigidbody target;
    bool isLive;
    private Transform Playertr;

    void Awake(){
        Playertr = GameObject.FindGameObjectWithTag("Player").transform;
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Rigidbody>();
    }
    void Update(){
        transform.LookAt(Playertr);
        if(Vector3.Distance(Playertr.position, transform.position) > 10.0f){
            transform.position += transform.forward * speed * Time.deltaTime;
        }
        else if(Vector3.Distance(Playertr.position, transform.position) < 10.0f){
            //활 쏘는 함수
        }
    }
}