using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour {
    public int magnitude;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != tag) {
            return;
        }
        collision.gameObject.GetComponent<RadioWave>().strength -= magnitude;
    }
}