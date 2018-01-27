using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : MonoBehaviour {
    public GameObject emitted;
    public Transform spawn;

    public void Transmit() {
        Instantiate(emitted, spawn.position, spawn.rotation);
    }
}
