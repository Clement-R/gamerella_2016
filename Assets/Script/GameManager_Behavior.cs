using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class GameManager_Behavior : MonoBehaviour {
    public float timeBetweenRefreshPick = 1.5f;
    public int maxRefreshLevel = 22;
    public Sprite[] refreshSprites;
    public int refreshLevel = 0;

    private bool gameOver = false;

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
        refreshLevel++;

        if (refreshLevel + 1 < maxRefreshLevel) {
            // Display different version of website according to refresh level
            if (refreshLevel >= 0 && refreshLevel <= 7) {
                GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = refreshSprites[0];
            } else if (refreshLevel > 7 && refreshLevel < 12) {
                GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = refreshSprites[1];
            } else if (refreshLevel > 12 && refreshLevel < 17) {
                GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = refreshSprites[2];
            } else if (refreshLevel > 17 && refreshLevel <= 22) {
                GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = refreshSprites[3];
            }
            
            StartCoroutine("increaseRefresh");
        } else {
            this.GameOver();
        }
    }

    public void GameOver() {
        this.gameOver = true;
        Time.timeScale = 0;
        
        // Display gameover !
        GameObject.Find("bleuscreen").GetComponent<SpriteRenderer>().enabled = true;
        GameObject.Find("bleuscreen").GetComponentInChildren<MeshRenderer>().enabled = true;
        GameObject.Find("bleuscreen").GetComponentInChildren<TextMesh>().text = "Score : " + (int) Time.timeSinceLevelLoad * 100;
    }

    public void resetRefresh() {
        refreshLevel = 0;
        GameObject.Find("Background").GetComponent<SpriteRenderer>().sprite = refreshSprites[refreshLevel];
    }
}
