using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    //zmienne i obiekty domyślne
    public float rotationSpeed = 5;

    //zmienne i obiekty prywatne
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

        //deklaracja użycia akcelerometru w telefonie
        Vector3 accelerationRaw = Input.acceleration;
        Vector3 acceleration = FixAcceleration (accelerationRaw);

        //nadanie "obrotom telefonu" odpowiednich kierunków w grze
        Quaternion rotX = Quaternion.AngleAxis(acceleration.y * rotationSpeed, Vector3.right);
        Quaternion rotZ = Quaternion.AngleAxis(acceleration.x * -rotationSpeed, Vector3.forward);

        //zmiana obrotu
        transform.rotation = transform.rotation * rotX;
        transform.rotation = transform.rotation * rotZ;
        transform.rotation = new Quaternion(transform.rotation.x, 0, transform.rotation.z,1);
            
    }
}
