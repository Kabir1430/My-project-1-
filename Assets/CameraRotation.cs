using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Transform player;

    public float rot, sensor;
    // Start is called before the first frame update
    void Start()
    {
       Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Mouse X") * sensor * Time.deltaTime;


        float y = Input.GetAxis("Mouse Y") * sensor * Time.deltaTime;

        rot -= y;
        rot = Mathf.Clamp(rot, -90f, 90);

        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);

        player.Rotate(player.up*x);
    }
}
