using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {

	public void Quit(){
		Application.Quit();
	}

	public void NewGame(){
		Application.LoadLevel(1);
	}
}