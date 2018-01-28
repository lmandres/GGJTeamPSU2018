using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Dragable : MonoBehaviour {
    public bool locked;
    private HingeJoint2D lastHinge;
    

    private void Start() {
        lastHinge = gameObject.GetComponentInChildren<HingeJoint2D>();
    }

    public void OnMouseUp() {
        if (lastHinge) {
            JointMotor2D motor = lastHinge.motor;
            motor.motorSpeed = 0;
            lastHinge.motor = motor;
        }

        RectTransform[] rects = GameObject.FindObjectsOfType<RectTransform>();
        foreach (RectTransform r in rects) {
            if (r.name == "Trash") {
                Vector3 diff = Input.mousePosition - r.position;
                if ( Mathf.Abs(diff.x) < r.sizeDelta.x/2 && Mathf.Abs(diff.y) < r.sizeDelta.y/2) {
                    deleteSelf();
                }

            }
        }
        
    }
    private void deleteSelf() {
        DragHandler[] items = GameObject.FindObjectsOfType<DragHandler>();
        string myName = gameObject.name.Replace("(Clone)", "");
        foreach (DragHandler item in items) {
            if (item.name == myName) {
                item.incrementCounter();
            }
        }
        Destroy(gameObject);
    }

    public void OnMouseDrag() {
        Vector3 thing = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(thing.x, thing.y, 0);

        bool ctrlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        bool altPressed = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);

        if (!locked) {
            if (altPressed) { //adjust angle, if there is one
                if (lastHinge) {
                    int diff = (int)(transform.position.y - newPos.y);

                    JointMotor2D motor = lastHinge.motor;
                    motor.maxMotorTorque = 1000;
                    motor.motorSpeed = 10 * diff;
                    lastHinge.motor = motor;
                    lastHinge.useMotor = true;
                }
            } else if (ctrlPressed) {
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