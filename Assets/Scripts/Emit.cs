﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : MonoBehaviour {
    public GameObject emitted;
    public Transform spawn;

	void Start () {
        //Instantiate(emitted, spawn.position, spawn.rotation);
	}

    public void Transmit() {
        Instantiate(emitted, spawn.position, spawn.rotation);
    }

    private void OnMouseDown() {
        Debug.Log("RAWR");
    }
}
