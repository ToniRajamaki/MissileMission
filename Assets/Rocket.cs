using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource thrustAudio;

    // Start is called before the first frame update
    void Awake() {

      // private [SerializeField] rotationSpeed = 5;
        thrustAudio = GetComponent<AudioSource>();
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
            if(!thrustAudio.isPlaying)
            {
                thrustAudio.Play();
            }
        }
        else
        {
            thrustAudio.Stop();
        }
        if(Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward);
        }
        
        if(Input.GetKey(KeyCode.D))
        {
             transform.Rotate(-Vector3.forward);
        
        }

    }
}
