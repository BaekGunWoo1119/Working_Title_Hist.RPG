using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class E_ArrowCtrl : MonoBehaviour
{
    private Transform playerPos;
    private Vector3 dir;
    // Start is called before the first frame update
    void Start()
    {
        playerPos = GameObject.FindWithTag("Player").GetComponent<Transform>();
        //dir = playerPos.position - transform.position;
       // GetComponent<Rigidbody>().AddForce(dir * Time.deltaTime * 10000);
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);

        Destroy(this.gameObject, 3.0f);
    }

    void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Player") 
        {
            Debug.Log(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
