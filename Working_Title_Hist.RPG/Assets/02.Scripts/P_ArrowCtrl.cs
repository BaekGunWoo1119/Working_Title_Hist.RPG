using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class P_ArrowCtrl : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(Vector3.forward * 0.1f);

        Destroy(this.gameObject, 3.0f);
    }

   void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "Enemy") 
        {
            Debug.Log(other.gameObject);
            Destroy(this.gameObject);
        }
    }
}
