using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager_PopupSpawner : MonoBehaviour {

    public float timeBetweenSpawn = 2.0f;
    public GameObject []popups;
    public int activePopup = 0;

    private List<GameObject> openPopups = new List<GameObject>();

	void Start () {
        StartCoroutine("Spawn");
	}
	
    IEnumerator Spawn() {
        // TODO : Choose random popup
        float width = popups[0].GetComponent<Renderer>().bounds.size.x;
        float height = popups[0].GetComponent<Renderer>().bounds.size.y;

        GameObject popup = Instantiate(popups[0], new Vector3(width / 2, -height / 2, -5), Quaternion.identity) as GameObject;
        activePopup = popup.GetInstanceID();
    Debug.Log(activePopup);
        openPopups.Add(popup);

        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine("Spawn");
    }
}
