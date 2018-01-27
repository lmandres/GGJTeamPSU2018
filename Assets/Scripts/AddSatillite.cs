using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AddSatillite : MonoBehaviour {

    public Button clearButton;
    public GameObject[] items;

	// Use this for initialization
	void Start () {
        Debug.Log("creating reset button");
        Button btn = clearButton.GetComponent<Button>();

        btn.onClick.AddListener(TaskOnClick);
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    private void TaskOnClick() {
        Debug.Log("clicked reset");
        /*En
        IEnumerator e = Canvas.FindObjectsOfType<GameObject>().GetEnumerator();
        while( e.)
        //newSat.locked = false;
        //gameObject.*/
    }
}