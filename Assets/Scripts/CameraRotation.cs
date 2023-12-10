using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraRotation : MonoBehaviour
{

    public Transform player;
    public Camera fpscam;
    public float range = 100f;
    public GameObject Paper,Flash;
    public float rot, sensor;

    public LayerMask layer;

    public bool papering,lighting,opening;

    public Animator anim;

   
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

        player.Rotate(player.up * x);

        if(Input.GetKey(KeyCode.Mouse1) && !lighting)
        {
            Flash.SetActive(true);
            StartCoroutine(On());
        }

        if (Input.GetKey(KeyCode.Mouse1) && lighting)
        {
            Flash.SetActive(false);
          
            StartCoroutine(OFF());

        }

        if (Input.GetKeyDown(KeyCode.Mouse0))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        RaycastHit hit;
        if (Physics.Raycast(fpscam.transform.position, fpscam.transform.forward, out hit, range))
        {

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("paper")  && !papering)
            {
                Paper.SetActive(true);
             //   Debug.Log(hit.transform.name);
                StartCoroutine(True());
            }
            if (papering)
            {

                StartCoroutine(False());

                Paper.SetActive(false);
            }

            if(hit.collider.gameObject.layer==LayerMask.NameToLayer("Drawer") && !opening)
            {

                anim.SetBool("On", true);
                StartCoroutine(Open());
                Debug.Log("Open");

           

            }


            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Drawer") && opening)
            {
                anim.SetBool("On", false);
                StartCoroutine(Close());


            }


        }
    }

    IEnumerator True()
    {

        yield return new WaitForSeconds(0.2f);

        papering = true;
    }

    IEnumerator False()
    {

        yield return new WaitForSeconds(0.2f);
    papering=false; 
    }

    IEnumerator On()
    {

        yield return new WaitForSeconds(0.2f);

        lighting= true;
    }

    IEnumerator OFF()
    {

        yield return new WaitForSeconds(0.2f);
    lighting= false;
    }

    IEnumerator Open()
    {

        yield return new WaitForSeconds(0.2f);
        opening = false;
    }

    IEnumerator Close()
    {

        yield return new WaitForSeconds(0.2f);
        opening = false;
    }


}
