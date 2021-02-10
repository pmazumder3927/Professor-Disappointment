using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsObjectController2 : MonoBehaviour
{
    Rigidbody rb;
    public bool autoStart = false;
    public Vector3[] ForceArray;
    public ForceMode ForceType;

    private bool isApplying = false;
    private Vector3 initialPos;
    private Vector3 initialRot;
    // Use this for initialization
    void Start()
    {
        initialPos = transform.position;
        initialRot = transform.eulerAngles;
        rb = GetComponent<Rigidbody>();
        if (autoStart) OnStartMotion();
    }

    private void OnStartMotion()
    {
        rb.AddForce(ForceArray[DemoManager.Instance.caseNumber - 1], ForceType);
        isApplying = true;
    }

    public Rigidbody GetRigidbody()
    {
        return rb;
    }

    private void Update()
    {
        if (!isApplying)
        {
            return;
        }
        if (ForceType == ForceMode.Acceleration || ForceType == ForceMode.Force)
        {
            rb.AddForce(ForceArray[DemoManager.Instance.caseNumber - 1], ForceType);
        }
    }

    public void Reset()
    {
        transform.position = initialPos;
        transform.rotation = Quaternion.Euler(initialRot);
        rb.velocity = Vector3.zero;
        rb.angularVelocity = Vector3.zero;
        isApplying = true;
    }

    public void StartPhysicsObject()
    {
        OnStartMotion();
    }
}
