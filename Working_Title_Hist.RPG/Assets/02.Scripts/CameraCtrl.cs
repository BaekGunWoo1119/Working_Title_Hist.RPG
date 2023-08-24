//카메라가 플레이어를 따라오게 만드는 스크립트
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraCtrl : MonoBehaviour
{

    float offsetY = 20.0f;
    float offsetZ = -20.0f;
    public GameObject player;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.position =new Vector3(player.transform.position.x, player.transform.position.y +  offsetY, player.transform.position.z + offsetZ);
    }
}
