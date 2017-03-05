using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotationSpeed = 5;
    

    private Rigidbody rb;

	void Start ()
    {
        rb = GetComponent<Rigidbody>();
	}
	
	
	void FixedUpdate ()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Quaternion rotX = Quaternion.AngleAxis(v * rotationSpeed, Vector3.right);
        Quaternion rotY = Quaternion.AngleAxis(h * rotationSpeed, Vector3.forward);

        transform.rotation = transform.rotation * rotX;
        transform.rotation = transform.rotation * rotY;


    }
}
