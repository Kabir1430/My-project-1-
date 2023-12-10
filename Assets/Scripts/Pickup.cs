using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    private Rigidbody rb; // Reference to the Rigidbody of the object
    private bool isBeingCarried = false; // Flag to check if the object is being carried

    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

   public void PickUp()
    {
        rb.isKinematic = true; // Disable Rigidbody physics when picked up
        transform.SetParent(Camera.main.transform); // Set the object's parent to the camera
        isBeingCarried = true; // Set the carrying flag to true
    }


   public void Carry()
    {
        // Update the object's position to follow the camera (or player)
        transform.position = Camera.main.transform.position + Camera.main.transform.forward * 2.0f;
    }

   public void Drop()
    {
        rb.isKinematic = false; // Enable Rigidbody physics when dropped
        transform.SetParent(null); // Reset the object's parent
        isBeingCarried = false; // Set the carrying flag to false
    }

}
