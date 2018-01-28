using UnityEngine;
using UnityEngine.UI;

public class ClearTransmissions : MonoBehaviour {
    public Button clearButton;
    public Button wipeButton;
    private GameObject[] xmits;
    private GameObject[] lasers;
    private GameObject[] sats;

    void Start() {
        Button cBtn = clearButton.GetComponent<Button>();
        cBtn.onClick.AddListener(ClearOnClick);
        Button wBtn = wipeButton.GetComponent<Button>();
        wBtn.onClick.AddListener(WipeOnClick);
    }

    private void ClearOnClick() {
        xmits = GameObject.FindGameObjectsWithTag("Radio Wave");
        lasers = GameObject.FindGameObjectsWithTag("Laser");

        foreach (GameObject xmit in xmits) {
            Destroy(xmit);
        }
        foreach (GameObject laser in lasers) {
            Destroy(laser);
        }
    }
    private void WipeOnClick() {
        sats = GameObject.FindGameObjectsWithTag("PlayerSat");

        foreach (GameObject sat in sats) {
            Destroy(sat);
        }
        DragHandler[] items = GameObject.FindObjectsOfType<DragHandler>();
        foreach (DragHandler item in items) {
            item.reserCounter();
        }
    }
}