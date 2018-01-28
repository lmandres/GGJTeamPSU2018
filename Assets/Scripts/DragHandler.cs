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
            Transform template = satellite.transform.GetChild(0);
            Transform newSat = Instantiate(template, newPos, Quaternion.identity);
            newSat.tag = "PlayerSat"; //Used for deleteing
        }
        satellite = null;
        transform.position = startPos;
    }
}