using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillCtrl : MonoBehaviour
{
    private float removeTime;

    void Update()
    {
        removeTime += Time.deltaTime;
        transform.Translate(Vector3.forward * 0.2f);

        if(removeTime >= 5.0f)
        {
            Destroy(this.gameObject);
        }
    }
}
