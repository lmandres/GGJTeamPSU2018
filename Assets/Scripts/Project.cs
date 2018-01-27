using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Project : MonoBehaviour {
    public float speed;

	void Start () {
        GetComponent<Rigidbody2D>().AddRelativeForce(new Vector2(1.0f * speed, 0));
    }
}
