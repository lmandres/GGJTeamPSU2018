using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Absorb : MonoBehaviour {
    public int magnitude;
    public bool absorb_laser;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (absorb_laser && collision.gameObject.tag == "Laser") {
            Destroy(collision.gameObject);
        } else if (collision.gameObject.tag == "Radio Wave") {
            collision.gameObject.GetComponent<DrawRadioWaves>().m_Intensity -= magnitude;
        }
    }
}