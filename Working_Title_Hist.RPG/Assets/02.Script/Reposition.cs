using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reposition : MonoBehaviour
{
    void OnTriggerExit(Collider col)
    {
        if (col.gameObject.tag != "Area")
        {
            return;
        }
        Vector3 playerPos = GameManager.Instance.player.transform.position;
        Vector3 myPos = transform.position;
        float dirX = playerPos.x - myPos.x;
        float dirZ = playerPos.z - myPos.z;

        float diffx = Mathf.Abs(dirX);
        float diffz = Mathf.Abs(dirZ);

        dirX = dirX > 0 ? 1 : -1;
        dirZ = dirZ > 0 ? 1 : -1;

        switch (transform.tag)
        {
            case "Ground":
                if(diffx > diffz)
                {
                    transform.Translate(Vector3.right * dirX * 200);
                }
                else if (diffz > diffx)
                {
                    transform.Translate(Vector3.forward * dirZ * 200);
                }
                break;
        }
    }

    void Update()
    {

    }
}
