using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class iNVISIBLE : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject rack;

    // Update is called once per frame
    void Update()
    {
   
        if(Input.GetKeyDown(KeyCode.Space))

        {

            rack.SetActive(false);
        }
        if (Input.GetKeyDown(KeyCode.H))

        {

            rack.SetActive(true);
        }

    }
}
