using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCtrl : MonoBehaviour
{
    public float moveSpeed = 50.0f;
    public float rotSpeed = 5.0f;
    private void Move_Pos(Vector3 move) {this.transform.position += move;}
    private Vector3 Get_Pos() {return this.transform.position;}

      
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKey(KeyCode.A))
        {
            Move_Pos(Vector3.left*moveSpeed*Time.deltaTime);
        }
        if(Input.GetKey(KeyCode.D))
        {
            Move_Pos(Vector3.right*moveSpeed*Time.deltaTime);
        }  
        if(Input.GetKey(KeyCode.W))
        {
            Move_Pos(Vector3.forward*moveSpeed*Time.deltaTime);
        }  
        if(Input.GetKey(KeyCode.S))
        {
            Move_Pos(Vector3.back*moveSpeed*Time.deltaTime);
        }

        transform.Rotate(0f, -Input.GetAxis("Mouse X") * rotSpeed, 0f, Space.World);

    }
}
