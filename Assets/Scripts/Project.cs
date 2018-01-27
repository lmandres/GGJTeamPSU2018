using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour {
    public float speed;
    public float strength;

	void Start () {
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1.0f * speed, 0));
    }

    private void FixedUpdate() {
        strength--;
        if (strength < 1) {
            Destroy(gameObject);
        }
    }
}
