using UnityEngine;
using System.Collections;

public class Popup_Moving : MonoBehaviour {
    public float moveSpeed = 0.5f;
    public float delta = 2.0f;

    private Popup_Behavior behavior;
    private Transform boxTransform;
    private float nextMove = 0.0f;
    private bool firstMove = true;

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

        Debug.Log(height);
        Debug.Log(width);

        float x = 0.0f;
        float y = 0.0f;

        if (!firstMove) {
            x = Random.Range(this.transform.position.x - this.delta, this.transform.position.x + this.delta);
            y = Random.Range(this.transform.position.y + this.delta, this.transform.position.y - this.delta);

            x = Mathf.Clamp(x, width / 2, 12.8f - (width / 2));
            y = Mathf.Clamp(y, -7.2f + (height / 2),  -(height / 2));
        }
        else {
            x = Random.Range(width / 2, 12.8f - (width / 2));
            y = Random.Range(-(height / 2), -7.2f + (height / 2));
        }

        this.transform.position = new Vector3(x, y, this.transform.position.z);
        Debug.Log(x + " : " + y);
        this.firstMove = false;
    }
}
