using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Trash : MonoBehaviour, IDropHandler {

    public BoxCollider2D trashcan;

	// Use this for initialization
	void Start () {
		//trashcan.bounds = new Bounds();
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
        Debug.Log("Trash_impact");
        if (collision.gameObject.tag != tag) {
            return;
        }
        Destroy(collision.gameObject);
    }
}
