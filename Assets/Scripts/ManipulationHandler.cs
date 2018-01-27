using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ManipulationHandler : MonoBehaviour, IBeginDragHandler,  IDragHandler, IEndDragHandler{

    public static GameObject satellite;
    Vector3 startPos;
    Quaternion initQ;

    public void OnBeginDrag(PointerEventData eventData) {
        satellite = gameObject;
        startPos = transform.position;
        initQ = transform.rotation;

        Debug.Log(initQ);
        Debug.Log(Input.mousePosition);
        Debug.Log("mouse1: " + Input.GetMouseButton(1).ToString());
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
        Debug.Log("mousedonw on locked sat!");
    }

    private void OnMouseUpAsButton() {
        Debug.Log("mouseclick on locked sat!");
    }
        
}
