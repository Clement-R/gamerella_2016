using UnityEngine;
using System.Collections;

public class Popup_Behavior : MonoBehaviour {

    public bool isActive = false;
    public bool isFinished = false;
    private GameManager_PopupSpawner god;

    void Start() {
        god = GameObject.Find("GameManager").GetComponent<GameManager_PopupSpawner>();
    }

	void Update () {
	    if(god.activePopup == this.gameObject.GetInstanceID()) {
            isActive = true;
        } else {
            isActive = false;
        }

        if(isActive && isFinished) {
            god.removePopup(this.gameObject);
            Destroy(this.gameObject);
        }
	}
}
