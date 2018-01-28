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

        Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(pos.x, pos.y, 0);

        if (satellite.transform.childCount > 0) {
            Transform sat = satellite.transform.GetChild(0);
            //Debug.Log(sat);
            Instantiate(sat, newPos, Quaternion.identity);
        }
        satellite = null;
        transform.position = startPos;
    }

    // Use this for initialization
    void Start () { }
	
	// Update is called once per frame
	void Update () { }

}