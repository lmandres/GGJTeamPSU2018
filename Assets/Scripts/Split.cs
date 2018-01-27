using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Split : MonoBehaviour, IBeginDragHandler,  IDragHandler, IEndDragHandler{

    public GameObject emitted;
    public Transform[] spawns;
    public bool locked; //locked items are part of the puzzle
    public static GameObject satellite;
    Vector3 startPos;
    Quaternion initQ;
    public string tag;

    private void OnTriggerEnter2D(Collider2D collision) {
        if (collision.gameObject.tag != tag) {
            return;
        }
        Destroy(collision.gameObject);
        foreach (Transform spawn in spawns) {
            Instantiate(emitted, spawn.position, spawn.rotation);
        }
    }

    public void OnBeginDrag(PointerEventData eventData) {
        satellite = gameObject;
        startPos = transform.position;
        initQ = transform.rotation;

        Debug.Log(initQ);
        Debug.Log(Input.mousePosition);
        Debug.Log(Input.GetMouseButton(1));
    }

    public void OnDrag(PointerEventData eventData) {
        transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData) {
        /*Vector3 newPos = Input.mousePosition;
        Vector3 newMappedPos = new Vector3(
            ((float) newPos.x - (Screen.width/2))/((float)Screen.width) * 12,
            ((float) newPos.y - (Screen.height/2))/((float)Screen.height) * 10,
            newPos.z);

        Debug.Log(newPos.ToString() + " -> " + newMappedPos.ToString());

        if (satellite.transform.childCount > 0) {
            Transform sat = satellite.transform.GetChild(0);
            Debug.Log(sat);
            Instantiate(sat, newMappedPos, Quaternion.identity);
        }
        satellite = null;
        transform.position = startPos;
        */
    }

    private void OnMouseDown() {
        if (locked) {
            Debug.Log("mousedown on locked splitter!");
        } else {
            Debug.Log("mousedown on unlocked splitter!");
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }
    }

    private void OnMouseUpAsButton() {
        if (locked) {
            Debug.Log("mouseclick on locked splitter!");
        } else {
            Debug.Log("mouseclick on unlocked splitter!");
        }
    }
        
}
