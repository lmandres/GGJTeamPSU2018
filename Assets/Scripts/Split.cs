using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Split : MonoBehaviour {

    public GameObject emitted;
    public Transform[] spawns;
    public bool locked; //locked items are part of the puzzle
    public static GameObject satellite;
    Vector3 startPos;
    Quaternion initQ;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collision) {
        Debug.Log("Receiver is Hit");
        if (collision.gameObject.tag != tag) {
            return;
        }
        // Ignore if the object faces away from the recieving satellite
        /*if (Quaternion.Angle(gameObject.transform.rotation, collision.transform.rotation) >= 270) {
            return;
        }*/
        Destroy(collision.gameObject);
        foreach (Transform spawn in spawns) {
            Instantiate(emitted, spawn.position, spawn.rotation);
        }
    } 
}
