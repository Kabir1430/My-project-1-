using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;

public class CameraRotation : MonoBehaviour
{


    public Transform player,door;
    public float rotationSpeed = 2.0f; // Speed of 
    public Camera fpscam;
    public float range = 100f;
    public int i;

    public GameObject Paper,Flash,Girl,Child,GameClear,Safed,CSafed,O,Setting;
    public float rot, sensor;

    public LayerMask layer;

    public bool papering,lighting,opening, isBeingCarried,pickup,girlkey,chilkey,basementkey,setting;

    // public Animator anim;


    //public Rigidbody rb;

    // public Rotate R;
    // public Pickup Object;
    // Start is called before the first frame update

    public Slider slider;
    void Start()
    {
        
        Cursor.lockState = CursorLockMode.Locked;
    }


    public void RangeUpdate(float sen)
    {
          
        sensor=slider.value ;

       
;   
        Debug.Log(sensor);
    }
    void Escape()
    {
        if(Input.GetKeyUp(KeyCode.Escape) )
        {
            Cursor.lockState = CursorLockMode.None;
            Setting.SetActive(true);
            Time.timeScale = 0; 
            StartCoroutine(Set());
        }

        if (Input.GetKeyUp(KeyCode.Escape))
        {
                //Cursor.lockState = CursorLockMode.None;
            Setting.SetActive(false);
            StartCoroutine(SetDone());
            Cursor.lockState = CursorLockMode.Locked;
        }
    }
    void Back()
    {
                        Time.timeScale = 1;
        //Cursor.lockState = CursorLockMode.None;
        Setting.SetActive(false);
        StartCoroutine(SetDone());
        Cursor.lockState = CursorLockMode.Locked;

    }
    IEnumerator Set()
    {

        yield return new WaitForSeconds(1f);
        setting = true;
    }
    IEnumerator SetDone()
    {

        yield return new WaitForSeconds(1f);
        setting = false;
    }

    // Update is called once per frame
    void Update()
    {
        Escape();
        float x = Input.GetAxis("Mouse X") * sensor * Time.deltaTime;


        float y = Input.GetAxis("Mouse Y") * sensor * Time.deltaTime;

        rot -= y;
        rot = Mathf.Clamp(rot, -90f, 90);

        transform.localRotation = Quaternion.Euler(rot, 0f, 0f);

        player.Rotate(player.up * x);

        if (Input.GetKey(KeyCode.Mouse1) && !lighting)
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

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("paper") && !papering)
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

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("girldoor"))
            {
                Girl.SetActive(false);
                i++;
                Safed.SetActive(true);
                StartCoroutine(Ok());
            }

            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("child"))
            {
                i++;
                Child.SetActive(false);

                CSafed.SetActive(true);
                StartCoroutine(Ok());
            }


            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Drawer") && i == 2)
            {
                GameClear.SetActive(true);
            }


            if (hit.collider.gameObject.layer == LayerMask.NameToLayer("Drawer") && i <2)
            {
                O.SetActive(true);
                StartCoroutine(Ok());
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

   IEnumerator Ok()
    {
        yield return new WaitForSeconds(1f);
        CSafed.SetActive(false);
        Safed.SetActive(false);
    O.SetActive(false);
    }

}
