using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void OnDrop( PointerEventData eventData) {
        //trashdrop
        Debug.Log("TRAAAAASSSH");
        //Destroy(DragHandler.satellite.transform);
        DragHandler.satellite.transform.SetParent(null);
    }

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != tag) {
            return;
        }
        Destroy(collision.gameObject);
    }
}
