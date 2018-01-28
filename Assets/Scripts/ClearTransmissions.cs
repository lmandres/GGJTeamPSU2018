using UnityEngine;
using UnityEngine.UI;

public class ClearTransmissions : MonoBehaviour {
    public Button clearButton;
    public Button wipeButton;
    private GameObject[] xmits;
    private GameObject[] sats;

    void Start() {
        Button cBtn = clearButton.GetComponent<Button>();
        cBtn.onClick.AddListener(ClearOnClick);
        Button wBtn = wipeButton.GetComponent<Button>();
        wBtn.onClick.AddListener(WipeOnClick);
    }

    private void ClearOnClick() {
        xmits = GameObject.FindGameObjectsWithTag("Radio Wave");

        foreach (GameObject xmit in xmits) {
            Destroy(xmit);
        }
    }
    private void WipeOnClick() {
        sats = GameObject.FindGameObjectsWithTag("PlayerSat");

        foreach (GameObject sat in sats) {
            Destroy(sat);
        }
    }
}