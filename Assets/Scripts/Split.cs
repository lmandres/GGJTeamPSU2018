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
    public AudioClip radioSound;

    private AudioSource source;
    public float volLowRange = .5f;
    public float volHighRange = 1.0f;

    public void Awake(){
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision) {
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
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(radioSound, vol);
        }
    } 
}
