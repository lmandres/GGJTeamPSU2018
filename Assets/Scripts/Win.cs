using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	GameObject WinCanvas;

	void Start () {
		WinCanvas = GameObject.Find("Win Canvas");
		WinCanvas.SetActive(false);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
        WinCanvas.SetActive(true);
	}
}
