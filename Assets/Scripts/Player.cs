using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float speed = 5f;
    public float sensitivity = 2f;
    private float rotationX = 0f;
    public Rigidbody rb;
    public Animator anim;


    private void Start()
    {
             Cursor.lockState = CursorLockMode.Locked;
    }

    void Update()
    {
        // Move the player
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical) * speed * Time.deltaTime;
        transform.Translate(movement);

        // Rotate the player based on mouse input
        float mouseX = Input.GetAxis("Mouse X");
        float mouseY = -Input.GetAxis("Mouse Y"); // Invert Y-axis for more intuitive controls

        // Limit vertical rotation to avoid looking too far up or down
        rotationX += mouseY * sensitivity;
        rotationX = Mathf.Clamp(rotationX, -90f, 90f);

        transform.Rotate(Vector3.up * mouseX * sensitivity);
        Camera.main.transform.localRotation = Quaternion.Euler(rotationX, 0f, 0f);



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
