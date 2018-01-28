using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DragHandler : MonoBehaviour, IBeginDragHandler,  IDragHandler, IEndDragHandler{

    public static GameObject satellite;
    public int limit;
    private Vector3 startPos;
    private Transform stopPos;
    public int used;

    public void Start() {
        reserCounter();
    }

    public void reserCounter() {
        gameObject.GetComponentInChildren<Text>().text = limit.ToString();
        used = 0;
    }

    public void incrementCounter() {
        used--;
        gameObject.GetComponentInChildren<Text>().text = (limit - used).ToString();
    }


    public void OnBeginDrag(PointerEventData eventData) {
        if (used < limit) {
            satellite = gameObject;
            startPos = transform.position;
        }
    }

    public void OnDrag(PointerEventData eventData) {
        if (used < limit) {
            transform.position = Input.mousePosition;
        }
    }

    public void OnEndDrag(PointerEventData eventData) {
        if (used < limit) {
            Vector3 pos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector3 newPos = new Vector3(pos.x, pos.y, 0);

            if (satellite.transform.childCount > 0) {
                Transform template = satellite.transform.GetChild(0);
                Transform newSat = Instantiate(template, newPos, Quaternion.identity);
                newSat.tag = "PlayerSat"; //Used for deleteing
            }
            used++;
            gameObject.GetComponentInChildren<Text>().text = (limit - used).ToString();
            satellite = null;
            transform.position = startPos;
        }
    }
}