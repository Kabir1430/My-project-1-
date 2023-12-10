using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Raycast : MonoBehaviour
{    
    public Camera fpscam;
    public float range = 100f;
    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Space))
        {
            Shoot();
        }
    }
    void Shoot()
    {
        RaycastHit hit;
        if(Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit ,range))
        {
            
            if(hit.collider.tag=="")
            {

            Debug.Log(hit.transform.name);

            }
        }
    }
}
