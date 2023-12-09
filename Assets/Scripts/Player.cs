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

    public bool Ground,iscrouch;

    public Transform sphere;

    public float smoothblend,wait;

    public Vector3 crouchscale,defaultscale,Velocity;
   
    public LayerMask layer;

    public GameObject CardBoard,PlayerObj;

    IEnumerator Crouching()
    {
        yield return new WaitForSeconds(wait);
        iscrouch = true;
    }
    IEnumerator Crouch()
    {
        yield return new WaitForSeconds(wait);

        iscrouch = false;
    }
    void Update()
    {


     Ground = Physics.CheckSphere(sphere.position, Radius,layer);
        if(Ground&&Velocity.y<0)
        {
            Velocity.y = 0;

        }
        else
        {
                 Velocity.y -= gravity * Time.deltaTime;
        }

        
        characterController.Move(Velocity);

     float H=Input.GetAxis("Horizontal")*speed *Time.deltaTime; 

        float V = Input.GetAxis("Vertical") * speed * Time.deltaTime;
        characterController.Move(transform.forward * V);
        characterController.Move(transform.right * H);   
        


        //Crouch
        if(Input.GetKey(KeyCode.LeftControl)&&!iscrouch)
        {
            transform.localScale = crouchscale;
        CardBoard.SetActive(true); 
            PlayerObj.SetActive(false);
            characterController.center = new Vector3(0, 0, 0.28f);
            StartCoroutine(Crouching());
       
        }
        if(Input.GetKey(KeyCode.LeftControl) && iscrouch)
        {
            transform.localScale = defaultscale;
            CardBoard.SetActive(false);
            PlayerObj.SetActive(true);
            characterController.center = new Vector3(0, 0, 0);
            StartCoroutine(Crouch());   
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
