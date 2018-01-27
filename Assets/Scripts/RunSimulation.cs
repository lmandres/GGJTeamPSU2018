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
        Debug.Log("starting run sim");
        Button btn = runButton.GetComponent<Button>();
        btn.onClick.AddListener(TaskOnClick);
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void TaskOnClick() {
        Debug.Log("clicked run");
        initalTransmitter.Transmit();

    }
}