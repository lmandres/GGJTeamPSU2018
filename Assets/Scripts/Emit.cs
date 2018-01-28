using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Emit : MonoBehaviour {
    public GameObject emitted;
    public Transform spawn;
    public AudioClip radioSound;

    private AudioSource source;
    public float volLowRange = .5f;
    public float volHighRange = 1.0f;

    public void Awake(){
    	source = GetComponent<AudioSource>();
    }

    public void Transmit() {
        Instantiate(emitted, spawn.position, spawn.rotation);
        float vol = Random.Range(volLowRange, volHighRange);
        source.PlayOneShot(radioSound,vol);
    }
}
