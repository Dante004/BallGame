using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckBall : MonoBehaviour {

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ball") Time.timeScale = 0;
    }

}
