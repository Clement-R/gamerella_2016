using UnityEngine;
using System.Collections;

public class Popup_Behavior : MonoBehaviour {

    private GameManager_PopupSpawner god;

    void Start() {
        god = GameObject.Find("GameManager").GetComponent<GameManager_PopupSpawner>();
    }

	void Update () {
        Debug.Log("THIS : " + this.GetInstanceID());
        Debug.Log("ACTIVE : " + god.activePopup);

	    if(god.activePopup == this.GetInstanceID()) {
            Debug.Log("I'm alive !");
        }
	}
}
