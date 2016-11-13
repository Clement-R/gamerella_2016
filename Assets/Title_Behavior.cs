using UnityEngine;
using System.Collections;

public class Title_Behavior : MonoBehaviour {
	void Update () {
	    if(Input.anyKeyDown) {
            Destroy(this.gameObject);
        }
	}
}
