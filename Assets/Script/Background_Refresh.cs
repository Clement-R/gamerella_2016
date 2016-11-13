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
        if(god.popupOnScreen == false && Time.timeScale == 1) {
            behavior.resetRefresh();
            StartCoroutine("displayButton");
        }
    }

    IEnumerator displayButton() {
        transform.FindChild("refresh_button_clicked").gameObject.SetActive(true);
        yield return new WaitForSeconds(0.1f);
        transform.FindChild("refresh_button_clicked").gameObject.SetActive(false);
    }
}
