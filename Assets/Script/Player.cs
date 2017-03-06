using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float rotationSpeed = 5;

    private Rigidbody rb;
    private Quaternion calibrationQuaternion;

    void Start ()
    {
        rb = GetComponent<Rigidbody>();
        CalibrateAccelerometer();
    }

    void CalibrateAccelerometer()
    {
        Vector3 accelerationSnapshot = Input.acceleration;
        Quaternion rotateQuaternion = Quaternion.FromToRotation(new Vector3(0.0f, 0.0f, -1.0f), accelerationSnapshot);
        calibrationQuaternion = Quaternion.Inverse(rotateQuaternion);
    }

    Vector3 FixAcceleration(Vector3 acceleration)
    {
        Vector3 fixedAcceleration = calibrationQuaternion * acceleration;
        return fixedAcceleration;
    }

    void FixedUpdate ()
    {
        //float h = Input.GetAxis("Horizontal");
        //float v = Input.GetAxis("Vertical");

        Vector3 accelerationRaw = Input.acceleration;
        Vector3 acceleration = FixAcceleration (accelerationRaw);

        Quaternion rotX = Quaternion.AngleAxis(acceleration.y * rotationSpeed, Vector3.right);
        Quaternion rotZ = Quaternion.AngleAxis(acceleration.x * -rotationSpeed, Vector3.forward);

        transform.rotation = transform.rotation * rotX;
        transform.rotation = transform.rotation * rotZ;


    }
}
