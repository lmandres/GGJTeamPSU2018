using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour {

	public int nextLevel;
	public bool lastLevel;


	void OnGUI(){
		
		//if retry button is pressed load scene 0 the game
		GUI.contentColor = Color.red;
		if(!lastLevel){
			if(GUI.Button(new Rect((Screen.width/3) * 2,Screen.height/2 -150,100,40),"Next Level")){
				Application.LoadLevel(1);
			}
		}
		//and quit button
		if(GUI.Button(new Rect((Screen.width/3) * 2,Screen.height/2 -100,100,40),"Main Menu")){
			Application.LoadLevel(0);
		}
	}

	private void OnTriggerEnter2D(Collider2D collision) {
        
	}
}
