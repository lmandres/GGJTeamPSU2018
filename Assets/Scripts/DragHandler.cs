using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler,  IDragHandler, IEndDragHandler{

    public static GameObject satellite;
    private Vector3 startPos;
    private Transform stopPos;

    public void OnBeginDrag(PointerEventData eventData) {
        satellite = gameObject;
        startPos = transform.position;
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        Vector3 newPos = Input.mousePosition;
        Vector3 newMappedPos = new Vector3(
            ((float) newPos.x - (Screen.width/2))/((float)Screen.width) * 12,
            ((float) newPos.y - (Screen.height/2))/((float)Screen.height) * 10,
            newPos.z);

        Debug.Log(newPos.ToString() + " -> " + newMappedPos.ToString());

        if (satellite.transform.childCount > 0) {
            Transform sat = satellite.transform.GetChild(0);
            Debug.Log(sat);
            //sat.
            Instantiate(sat, newMappedPos, Quaternion.identity);
        }
        satellite = null;
        transform.position = startPos;
    }

    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

}