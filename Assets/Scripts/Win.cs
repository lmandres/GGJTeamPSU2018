using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {
	public GameObject WinCanvas;

	void Awake () {
		Debug.Log(WinCanvas);
        WinCanvas.SetActive(false);
        Debug.Log(WinCanvas.activeSelf);
	}

	private void OnTriggerEnter2D(Collider2D collision) {
		Debug.Log("IS IT EVEN TRIGGERING ME!?");
        WinCanvas.SetActive(true);
	}
}
