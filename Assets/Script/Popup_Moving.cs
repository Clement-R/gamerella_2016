using UnityEngine;
using System.Collections;

public class Popup_Moving : MonoBehaviour {
    public float moveSpeed = 0.5f;

    private Popup_Behavior behavior;
    private Transform boxTransform;
    private float nextMove = 0.0f;

    void Start () {
        behavior = GetComponent<Popup_Behavior>();
        boxTransform = transform.GetChild(0);
    }

    void Update() {
        if (behavior.isActive) {
            if (Time.time > nextMove) {
                nextMove = Time.time + moveSpeed;
                move();
            }
        }
    }

    void move() {
        float width = GetComponent<Renderer>().bounds.size.x;
        float height = GetComponent<Renderer>().bounds.size.y;

        float x = Random.Range(width / 2, 12.8f - (width / 2));
        float y = Random.Range(-(height / 2), -7.2f + (height / 2));

        this.transform.position = new Vector3(x, y, this.transform.position.z);
    }
}
