using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager_Behavior : MonoBehaviour {
    public float timeBetweenRefreshPick = 1.5f;
    public Sprite[] refreshSprites;
    
    private bool gameOver = false;
	private int refreshLevel = 0;

    void Start() {
        StartCoroutine("increaseRefresh");
    }

	void Update () {
        if (Input.GetKeyDown(KeyCode.R) && this.gameOver == true) {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    IEnumerator increaseRefresh() {
        yield return new WaitForSeconds(timeBetweenRefreshPick);
        GetComponent<SpriteRenderer>().sprite = refreshSprites[refreshLevel];
        StartCoroutine("increaseRefresh");
    }

    public void GameOver() {
        this.gameOver = true;
        Time.timeScale = 0;
        // TODO : Dispaly game over image
    }

    public void resetRefresh() {
        refreshLevel = 0;
        GetComponent<SpriteRenderer>().sprite = refreshSprites[refreshLevel];
    }
}
