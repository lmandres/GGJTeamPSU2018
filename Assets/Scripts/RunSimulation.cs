using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class RunSimulation : MonoBehaviour {

    public Button runButton;
    public Emit initalTransmitter;
    public GameObject[] items;

	// Use this for initialization
	void Start () {
        Button btn = runButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		
	}

    void TaskOnClick() {
        foreach (GameObject obj in GameObject.FindGameObjectsWithTag("Emitter")) {
            obj.GetComponent<Emit>().Transmit();
        }
    }
}