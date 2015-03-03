using UnityEngine;
using System.Collections;

public class WriteText : MonoBehaviour {

    public System.String name;

	// Use this for initialization
	void Start () {
        WritingEvent.instance.setText(name);
	}
	

}
