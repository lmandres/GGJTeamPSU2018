using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winButtonClick : MonoBehaviour {

	public bool isLastLevel;
	public int nextLvl;
	GameObject nextLevelBtn;
	GameObject mainMenuBtn;

	void Start () {
		nextLevelBtn = GameObject.Find("NextLevel");
		mainMenuBtn = GameObject.Find("MainMenu");
		if(isLastLevel){
			nextLevelBtn.SetActive(false);
		}
	}

	public void NextLevel(){
		Application.LoadLevel(nextLvl);
	}

	public void MainMenu(){
		Application.LoadLevel(0);
	}
}
