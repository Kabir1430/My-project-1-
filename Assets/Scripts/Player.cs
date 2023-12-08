using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Player : MonoBehaviour
{
  public CharacterController characterController;

    public float speed;
    public Animator anim;
    void Start()
    {
    }

    void Update()
    {

     float H=Input.GetAxis("Horizontal")*speed *Time.deltaTime;

        float V = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        characterController.Move(transform.forward * V);
        characterController.Move(transform.right * H);    
        //Anim

        if (Input.GetKey(KeyCode.W))
        {

            // Player is moving
            anim.SetBool("Walk", true);
            Debug.Log("Player is moving!");
        }
        else if(Input.GetKey(KeyCode.S))
        {

            anim.SetBool("Walk", true);


        }

        else if (Input.GetKey(KeyCode.D))
        {

            anim.SetBool("Walk", true);


        }
        else if (Input.GetKey(KeyCode.A))
        {

            anim.SetBool("Walk", true);


        }

        else
        {
                anim.SetBool("Walk", false);

            // Player is not moving
            Debug.Log("Player is not moving.");
    
        }

    }

    
}
