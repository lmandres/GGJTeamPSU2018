using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dragable : MonoBehaviour {
    public bool locked;
    private HingeJoint2D lastHinge;

    private void Start() {
        lastHinge = gameObject.GetComponentInChildren<HingeJoint2D>();
    }
    private void OnMouseUp()
    {
        if (lastHinge) {
            Debug.Log("Shutting off motor");

            JointMotor2D motor = lastHinge.motor;
            motor.motorSpeed = 0;
            lastHinge.motor = motor;

        }
    }
    private void OnMouseDrag() {
        Vector3 thing = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 newPos = new Vector3(thing.x, thing.y, 0);

        bool ctrlPressed = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        bool altPressed = Input.GetKey(KeyCode.LeftAlt) || Input.GetKey(KeyCode.RightAlt);

        if (!locked) {
            if (altPressed) { //adjust angle, if there is one
                Debug.Log("Setting lastHinge");
                if (lastHinge) {
                    int diff = (int)(newPos.y - transform.position.y);

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