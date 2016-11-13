using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager_PopupSpawner : MonoBehaviour {

    public float timeBetweenSpawn = 2.0f;
    public float timeBeforeGameStart = 2.0f;
    public GameObject []popups;
    public int activePopup = 0;
    public int maxPopup = 5;
    public bool popupOnScreen = false;
    
    private List<GameObject> openPopups = new List<GameObject>();
    // BEST HACK EU
    private int z = -5;
    private GameManager_Behavior behavior;
    private int numberOfPopupDone = 0;

    void Start () {
        Time.timeScale = 1;
        behavior = GetComponent<GameManager_Behavior>();
        StartCoroutine("StartGame");
	}

    void Update() {
        if(maxPopup == openPopups.Count) {
            behavior.GameOver();
        }

        if(openPopups.Count == 0) {
            popupOnScreen = false;
        } else {
            popupOnScreen = true;
        }
    }

    IEnumerator StartGame() {
        yield return new WaitForSeconds(timeBeforeGameStart);
        StartCoroutine("Spawn");
    }
	
    IEnumerator Spawn() {
        GameObject chosenPopup = popups[Random.Range(0, popups.Length)];

        float width = popups[0].GetComponent<Renderer>().bounds.size.x;
        float height = popups[0].GetComponent<Renderer>().bounds.size.y;

        float x = Random.Range(width / 2, 12.8f - (width / 2));
        float y = Random.Range(-(height / 2), -7.2f + (height / 2));

        GameObject popup = Instantiate(chosenPopup, new Vector3(x, y, this.z), Quaternion.identity) as GameObject;

        activePopup = popup.GetInstanceID();
        openPopups.Add(popup);
        // Decreaze Z
        z -= 1;

        yield return new WaitForSeconds(timeBetweenSpawn);
        StartCoroutine("Spawn");
    }

    public void removePopup(GameObject popup) {
        openPopups.Remove(popup);
        if(openPopups.Count - 1 >= 0) {
            activePopup = openPopups[openPopups.Count - 1].GetInstanceID();
        }

        numberOfPopupDone++;
        this.increaseDifficulty();
    }

    void increaseDifficulty() {
        if(numberOfPopupDone == 3) {
            // 9
            timeBetweenSpawn--;
        } else if(numberOfPopupDone == 7) { // +4
            // 8
            timeBetweenSpawn--;
        } else if (numberOfPopupDone == 12) { // +5
            // 7
            timeBetweenSpawn--;
        } else if (numberOfPopupDone == 18) { // +6
            // 6
            timeBetweenSpawn--;
        } else if (numberOfPopupDone == 25) { // +7
            // 5
            timeBetweenSpawn--;
        } else if (numberOfPopupDone == 33) { // +8
            // 4
            timeBetweenSpawn--;
        }
    }
}
