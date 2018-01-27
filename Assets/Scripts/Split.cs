using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Split : MonoBehaviour {
    public GameObject emitted;
    public Transform[] spawns;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != tag) {
            return;
        }
        Destroy(collision.gameObject);
        foreach (Transform spawn in spawns) {
            Instantiate(emitted, spawn.position, spawn.rotation);
        }
    }
}
