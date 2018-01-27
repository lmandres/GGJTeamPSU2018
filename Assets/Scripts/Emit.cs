using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : MonoBehaviour {
    public GameObject emitted;
    public Transform spawn;

	void Start () {
        Instantiate(emitted, spawn.position, spawn.rotation);
	}
}
