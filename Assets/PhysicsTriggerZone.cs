using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PhysicsTriggerZone : MonoBehaviour {
    public Vector3 Force;
    public ForceMode ForceType;
	// Use this for initialization
    private void OnTriggerStay(Collider other)
    {
        other.gameObject.GetComponent<Rigidbody>().AddForce(Force, ForceType);
    }
}
