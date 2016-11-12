using UnityEngine;
using System.Collections;

public class DetectClick : MonoBehaviour {
    private Popup_Behavior behavior;

    void Start() {
        behavior = GetComponentInParent<Popup_Behavior>();
    }

    void OnMouseDown() {
        behavior.isFinished = true;
    }
}
