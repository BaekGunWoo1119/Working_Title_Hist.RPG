using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEventCrtl : MonoBehaviour
{

    public GameObject EnCounterUI; 

    private float RotSpeed = 30.0f;
    void Update()
    {
        transform.Rotate(Vector3.forward * Time.deltaTime * RotSpeed);
    }

    void OnTriggerEnter(Collider other) 
    {
        if(other.gameObject.tag == "Player")
        {
            Debug.Log("이벤트 발생");            
            StartCoroutine(ShowEvent());

            gameObject.SetActive(false);
        }    
    }

    IEnumerator ShowEvent()
    {
        EnCounterUI.SetActive(true);
        yield return null;
    }
}
