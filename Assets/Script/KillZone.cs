using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

    public Vector3 spawn;

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(spawn.x, spawn.y, spawn.z); // zmiana pozycji obiektu na domyślną
    }

}
