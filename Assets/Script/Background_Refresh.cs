using UnityEngine;
using System.Collections;

public class Background_Refresh : MonoBehaviour {
    private GameManager_PopupSpawner god;
    private GameManager_Behavior behavior;

    void Start() {
        god = GameObject.Find("GameManager").GetComponent<GameManager_PopupSpawner>();
        behavior = GameObject.Find("GameManager").GetComponent<GameManager_Behavior>();
    }

    void OnMouseDown() {
        if(god.popupOnScreen == false) {
            Debug.Log("REFRESH");
            behavior.resetRefresh();
        }
    }
}
