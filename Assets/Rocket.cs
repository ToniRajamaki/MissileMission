using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;

    // Start is called before the first frame update
    void Awake() {
        
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessInput();
        
        
    }
    
    private void ProcessInput()
    {
       
        if(Input.GetKey(KeyCode.Space) || 
           Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up);
        }
        if(Input.GetKey(KeyCode.A))
        {
            print("LEFT");
        }
        
        if(Input.GetKey(KeyCode.D))
        {
        
            print("RIGHT");
        
        }

    }
}
