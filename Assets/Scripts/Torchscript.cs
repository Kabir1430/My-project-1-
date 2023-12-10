using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torchscript : MonoBehaviour
{
    public Light torchLight;

    private void Start()
    {
        // Try to find the Light component on the same GameObject or its children
        torchLight = GetComponentInChildren<Light>();

        // Check if the Light component is found
        if (torchLight == null)
        {
            Debug.LogError("No Light component found on the GameObject or its children.");
            enabled = false; // Disable the script to avoid errors
        }

        torchLight.enabled = false;
    }

    private void Update()
    {
   
        if (Input.GetMouseButtonDown(0))
        {

            ToggleTorch();
        }
    }

    private void ToggleTorch()
    {

        torchLight.enabled = !torchLight.enabled;
    }
}
