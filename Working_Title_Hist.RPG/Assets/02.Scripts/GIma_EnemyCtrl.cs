using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GIma_EnemyCtrl : MonoBehaviour
{
    public float speed;
    public float Rushspeed;
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
}
