using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameOver : MonoBehaviour
{


    public GameObject panel;
    public void OnCollisionEnter(Collision collision)
    {
            Debug.Log("GameOver");
        if (collision.gameObject.tag == "Player")
        {
            panel.SetActive(true);
        }
    }
  
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
