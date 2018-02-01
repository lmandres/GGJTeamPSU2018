using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	public void NextLevel()
    {
        Component child = nextLevelBtn.GetComponentInChildren(typeof(Button));
        Button childButton = (Button)child;

        if (nextLvl%2 > 0)
        {
            childButton.enabled = true;
        } else
        {
            childButton.enabled = false;
        }
        Application.LoadLevel(nextLvl);

    }

	public void MainMenu(){
		Application.LoadLevel(0);
	}
}
