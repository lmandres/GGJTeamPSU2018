using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Split : MonoBehaviour {

    public Animator animator;
    public float delay = 0;
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
    public int maxTagCount = 50;

    public void Awake(){
        source = GetComponent<AudioSource>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.tag + ": " + GameObject.FindGameObjectsWithTag(collision.gameObject.tag).Length.ToString());
        if (collision.gameObject.tag != tag) {
            return;
        } else if (GameObject.FindGameObjectsWithTag(collision.gameObject.tag).Length > maxTagCount)
        {
            Destroy(collision.gameObject);
            return;
        }
        // Ignore if the object faces away from the recieving satellite
        /*if (Quaternion.Angle(gameObject.transform.rotation, collision.transform.rotation) >= 270) {
            return;
        }*/
        Destroy(collision.gameObject);
        StartCoroutine(Fire());
    } 

    private IEnumerator Fire() {
        if (animator)
        {
            animator.SetTrigger("Fire");
            yield return new WaitForSeconds(delay);
        }
        foreach (Transform spawn in spawns)
        {
            Instantiate(emitted, spawn.position, spawn.rotation);
            float vol = Random.Range(volLowRange, volHighRange);
            source.PlayOneShot(radioSound, vol);
        }
    }
}
