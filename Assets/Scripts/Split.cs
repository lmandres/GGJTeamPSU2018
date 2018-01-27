using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class Split : MonoBehaviour {

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

    private void OnMouseDrag()
    {
        Debug.Log("draaaaag");

        Vector3 newPos = Input.mousePosition;
        Vector3 newMappedPos = new Vector3(
            ((float)newPos.x - (Screen.width / 2)) / ((float)Screen.width) * 12,
            ((float)newPos.y - (Screen.height / 2)) / ((float)Screen.height) * 10,
            newPos.z);
        if (!locked) {
            transform.position = newMappedPos;
        }
    }

    private void OnMouseDown() {
        Debug.Log("mousedown");
        /*if (locked) {
            Debug.Log("mousedown on locked splitter!");
        } else {
            Debug.Log("mousedown on unlocked splitter!");
            Vector2 MousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(MousePosition);
            transform.position = objPosition;
        }*/
    }
        
}
