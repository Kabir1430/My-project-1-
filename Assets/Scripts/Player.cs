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
            anim.SetFloat("H",0);

            anim.SetFloat("V", 1);
        }
        else if(Input.GetKey(KeyCode.S))
        {


            anim.SetFloat("V", -1);


            anim.SetFloat("H", 0);

        }

        else if (Input.GetKey(KeyCode.D))
        {

                        anim.SetFloat("H", 1);


            anim.SetFloat("V", 0);

        }
        else if (Input.GetKey(KeyCode.A))
        {

            anim.SetFloat("H", -1);

            anim.SetFloat("V", 0);


        }

        else
        {
            anim.SetFloat("H", 0);

            anim.SetFloat("V", 0);

            // Player is not moving
            Debug.Log("Player is not moving.");
    
        }

    }

    
}
