using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pickup : MonoBehaviour
{
    private Rigidbody rb; // Reference to the Rigidbody of the object
    private bool isBeingCarried = false; // Flag to check if the object is being carried
    public Transform parent;
    void Start()
    {
        rb = GetComponent<Rigidbody>(); // Get the Rigidbody component
    }

   public void PickUp()
    {
        rb.isKinematic = true; // Disable Rigidbody physics when picked up
        transform.SetParent(parent); // Set the object's parent to the camera
        isBeingCarried = true; // Set the carrying flag to true

       


    }


    public void Carry()
    {
        // Update the object's position to follow the camera (or player)
                
        transform.position = parent.transform.position ;
    
        transform.Rotate(0,0,100);
    }

   public void Drop()
    {
        rb.isKinematic = false; // Enable Rigidbody physics when dropped
        transform.SetParent(null); // Reset the object's parent
        isBeingCarried = false; // Set the carrying flag to false
    }

}
