using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource thrustAudio;
    [SerializeField] float rotationSpeed = 100f;
    [SerializeField] float thrustPower = 200f;

    // Start is called before the first frame update
    void Awake() {

      // private [SerializeField] rotationSpeed = 5;
        thrustAudio = GetComponent<AudioSource>();
        rigidBody = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrust();
        Rotate();
    }

    void OnCollisionEnter(Collision other) 
    {
        switch (other.gameObject.tag)
        {
            case "Friendly":
                print("OK");
                break;
            default:
                print("DEAD"); // todo kill the player
                break;
        }
    }

    private void Thrust()
    {
        if (Input.GetKey(KeyCode.Space) ||
                   Input.GetKey(KeyCode.W))
        {
            rigidBody.AddRelativeForce(Vector3.up * thrustPower);
            if (!thrustAudio.isPlaying)
            {
                thrustAudio.Play();
            }
        }
        else
        {
            thrustAudio.Stop();
        }
    }
    
    private void Rotate()
    {
        rigidBody.freezeRotation = true; // take manual control of rotation

        float rotationThisFrame = rotationSpeed * Time.deltaTime;

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(Vector3.forward * rotationThisFrame);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(-Vector3.forward * rotationThisFrame);
        }

        rigidBody.freezeRotation = false; // let unity physics continue rotation

    }

}
