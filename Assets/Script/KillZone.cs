﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZone : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        other.transform.position = new Vector3(0, 10, 0); // zmiana pozycji obiektu na domyślną
    }

}
