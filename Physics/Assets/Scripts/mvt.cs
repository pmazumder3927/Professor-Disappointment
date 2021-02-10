using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mvt : MonoBehaviour
{
    public float speed = 10f;
    public ForceMode ForceTypeToApply = ForceMode.Acceleration;

    [SerializeField]
    float xSpeed = 250f;
    [SerializeField]
    float ySpeed = 100f;
    [SerializeField]
    float yMinLimit = -20;
    [SerializeField]
    float yMaxLimit = 80;

    float x = 0;
    float y = 0;

    bool stdWalk = false;
    public bool disabled = true;
    Rigidbody rb;
    // Use this for initialization
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        var angles = transform.eulerAngles; x = angles.y; y = angles.x;
    }

    // Update is called once per frame
    void Update()
    {
        if (disabled)
        {
            return;
        }
        /*
        if (stdWalk)
        {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(Vector3.forward * 7 * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(-Vector3.forward * 7 * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.Translate(Vector3.right * 7 * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.Translate(Vector3.left * 7 * Time.deltaTime);
            }
        }
        else {
            if (Input.GetAxis("Vertical") > 0)
            {
                transform.Translate(Vector3.forward * 7 * Time.deltaTime);
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                transform.Translate(-Vector3.forward * 7 * Time.deltaTime);
            }
            else if (Input.GetAxis("Horizontal") > 0)
            {
                transform.eulerAngles += new Vector3(0, 25, 0) * Time.deltaTime;
            }
            else if (Input.GetAxis("Horizontal") < 0)
            {
                transform.eulerAngles += new Vector3(0, -25, 0) * Time.deltaTime;
            }
        } */

        // RECONFIGURE Vertical and Horizontal to be the X and Y axes of the same stick
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        rb.AddForce(new Vector3(h * speed, 0, v * speed), ForceTypeToApply);
        //RECONFIGURE LookX and Y to be the axes of another stick
        x += Input.GetAxis("LookX") * xSpeed * 0.02f;
        y -= Input.GetAxis("LookY") * ySpeed * 0.02f;
        y = ClampAngle(y, yMinLimit, yMaxLimit);
        var rotation = Quaternion.Euler(y, x, 0);
        gameObject.transform.rotation = rotation;
    }

    static float ClampAngle(float angle, float min, float max)
    {
        if (angle < -360) angle += 360; if (angle > 360) angle -= 360; return Mathf.Clamp(angle, min, max);
    }

    public void Disable()
    {
        disabled = true;
    }

    public void Enable()
    {
        disabled = false;
    }

}
