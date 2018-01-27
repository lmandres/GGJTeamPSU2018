using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour {
    public int magnitude;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log(collision.gameObject);
        //Destroy(collision.gameObject);
        collision.gameObject.GetComponent<RadioWave>().strength -= magnitude;
    }
}