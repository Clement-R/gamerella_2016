using UnityEngine;
using System.Collections;

public class Swp_Behavior : MonoBehaviour {
    public Sprite []swp;

    private GameManager_Behavior behavior;
    private SpriteRenderer sprite;

    // Use this for initialization
    void Start () {
        behavior = GameObject.Find("GameManager").GetComponent<GameManager_Behavior>();
        sprite = GetComponent<SpriteRenderer>();
    }
	
	// Update is called once per frame
	void Update () {
        sprite.sprite = swp[behavior.refreshLevel];
	}
}
