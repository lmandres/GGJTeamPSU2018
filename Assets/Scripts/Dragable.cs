using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour {
    public bool locked;

    private void OnMouseDrag() {
        Vector3 thing = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(thing.x, thing.y, 0);

        bool ctrlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);

        if (!locked) {
            if (ctrlPressed) {
                //rotate
                transform.rotation = Quaternion.LookRotation(Vector3.forward, newPos - transform.position);
                transform.Rotate(new Vector3(0, 0, 90)); //Fix 'fronts' of sprintes
            } else {
                //Drag
                transform.position = new Vector3(thing.x, thing.y, 0);
            }
        }
    }
}
