using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Laser : MonoBehaviour {
    public float speed;
    public int timeout;

	void Start () {
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1.0f * speed, 0));
        StartCoroutine(Cull());
    }

    IEnumerator Cull() {
        yield return new WaitForSeconds(timeout);
        Destroy(gameObject);
    }
}
