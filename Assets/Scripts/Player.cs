using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
  public CharacterController characterController;

    public float speed;

    public Animator anim;

    public float gravity = 9.81f; // Adjust gravity force as needed
    
    public float Radius;

    public bool Ground;

    public Transform sphere;

    public float smoothblend;

    public Vector3 crouchscale,Velocity;
   
    public LayerMask layer;
    void Update()
    {


     Ground = Physics.CheckSphere(sphere.position, Radius,layer);

                 Velocity.y -= gravity * Time.deltaTime;
        
        characterController.Move(Velocity);

     float H=Input.GetAxis("Horizontal")*speed *Time.deltaTime; 

        float V = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        characterController.Move(transform.forward * V);
        characterController.Move(transform.right * H);   
        


        //Crouch
        if(Input.GetKey(KeyCode.LeftControl))
        {
            transform.localScale = crouchscale;
        }

        
        
        //Anim

        if (Input.GetKey(KeyCode.W))
        {
       
            anim.SetFloat("V", 1, smoothblend, Time.deltaTime);
        }
        else if(Input.GetKey(KeyCode.S))
        {
            anim.SetFloat("V", -1, smoothblend, Time.deltaTime);

        }

        else if (Input.GetKey(KeyCode.D))
        {

            anim.SetFloat("H", 1, smoothblend, Time.deltaTime);

        }
        else if (Input.GetKey(KeyCode.A))
        {

            anim.SetFloat("H", -1, smoothblend, Time.deltaTime);

        }

        else
        {

            anim.SetFloat("H", 0, smoothblend, Time.deltaTime);
            anim.SetFloat("V", 0, smoothblend, Time.deltaTime);
       //     anim.SetFloat("V", 0);

            // Player is not moving
            Debug.Log("Player is not moving.");
    
        }

        //Gravity


    }


   public void Move(float x,float y)
    {
        anim.SetFloat("V", y, smoothblend, Time.deltaTime);
    }
}
