using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	public int nextLevel;

	private void OnTriggerEnter2D(Collider2D collision) {
        GUI.contentColor = Color.red;
		if(GUI.Button(new Rect((Screen.width/3) * 2,Screen.height/2 +100,100,40),"Next Level")){
			Application.LoadLevel(nextLevel);
		}
		//and quit button
		if(GUI.Button(new Rect((Screen.width/3) * 2,Screen.height/2 +150,100,40),"Quit")){
			Application.Quit();
    }
}
