using UnityEngine;
using System.Collections;

public class Popup_Typer : MonoBehaviour {

    private Popup_Behavior behavior;
    private TextMesh text;
    private int textIndex = 0;
    private string fakeCode;

    void Start () {
        behavior = GetComponent<Popup_Behavior>();
        text = GetComponentInChildren<TextMesh>();
        TextAsset fakeText = Resources.Load("fake_code") as TextAsset;
        fakeCode = fakeText.text;
        text.text = "";
    }
	
	void Update () {
        if(behavior.isActive) {
            if (Input.anyKeyDown && Time.timeScale == 1) {
                if(!Input.GetMouseButtonDown(0) && !Input.GetMouseButtonDown(1)) {
                    text.text = text.text + fakeCode[textIndex];
                    if (textIndex + 1 < fakeCode.Length) {
                        textIndex++;
                    }
                    else {
                        behavior.isFinished = true;
                    }
                }
            }
        }   
	}
}
