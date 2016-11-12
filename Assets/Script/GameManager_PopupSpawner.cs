using UnityEngine;
using System.Collections;

public class GameManager_PopupSpawner : MonoBehaviour {

    public float timeBetweenSpawn = 2.0f;

    public GameObject []popups;

	void Start () {
        StartCoroutine("Spawn");
	}
	
    IEnumerator Spawn() {
        float width = popups[0].GetComponent<Renderer>().bounds.size.x;
        float height = popups[0].GetComponent<Renderer>().bounds.size.y;

        Instantiate(popups[0], new Vector3(width / 2, - height / 2, -5), Quaternion.identity);
        yield return new WaitForSeconds(timeBetweenSpawn);
    }
}
