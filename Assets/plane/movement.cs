using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour {
    [SerializeField] private int acceleration;
    [SerializeField] private GameObject bomber;
    [SerializeField] private GameObject cam;
    [SerializeField] public ParticleSystem af1;
    [SerializeField] public ParticleSystem af2;

    public float speed = 20.0F;
    public float tiltAngle = 30.0F;
    private float speeda;
    

    public GameObject oodio;
    private void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
       
       
    }
    void Update()
    {

      

  


        if (Input.GetKey(KeyCode.W))
        {
            
           bomber.GetComponent<Rigidbody>().AddForce(transform.forward*600, ForceMode.Acceleration);
            af1.Play();
            af2.Play();
            oodio.SetActive(true);
        }
        if (Input.GetKey(KeyCode.A))
        {

            cam.transform.Rotate(new Vector3(0, 0, 1) * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.D))
        {

            cam.transform.Rotate(new Vector3(0, 0, -1) * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.Space))
        {

            cam.transform.Rotate(new Vector3(-2, 0, 0) * Time.deltaTime * speed);

        }
        if (Input.GetKey(KeyCode.LeftShift))
        {

            cam.transform.Rotate(new Vector3(2, 0, 0) * Time.deltaTime * speed);

        }
        
    }
    private void FixedUpdate()
    {
       
        cam.transform.Rotate(new Vector3(0, Input.GetAxis("Horizontal")*2, 0) * Time.deltaTime * speed);

        Vector3 hi = new Vector3(bomber.transform.position.x,bomber.transform.position.y,bomber.transform.position.z);

        cam.transform.position=hi;

        

        speeda = bomber.GetComponent<Rigidbody>().velocity.magnitude;
            if (speeda >0)
            {
            bomber.GetComponent<Rigidbody>().AddForce(transform.forward * -100, ForceMode.Acceleration);
            Debug.Log("hiii");
        }
    }
 //I love finnerty

}

