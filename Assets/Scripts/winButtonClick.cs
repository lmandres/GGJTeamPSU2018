using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class winButtonClick : MonoBehaviour {

	public bool isLastLevel;
	public int nextLvl;

	public void NextLevel()
    {
        Application.LoadLevel(nextLvl);
    }

	public void MainMenu(){
		Application.LoadLevel(0);
	}
}
