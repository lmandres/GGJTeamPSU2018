using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Win : MonoBehaviour {

	private void OnTriggerEnter2D(Collider2D collision)
    {
        GameObject nextLevelBtn = GameObject.Find("NextLevel");
        Component child = nextLevelBtn.GetComponentInChildren(typeof(Button));
        Button childButton = (Button)child;

        childButton.enabled = true;
    }
}
