using UnityEngine;
using System.Collections;

public class WriteText : MonoBehaviour {

    public System.String name;
    public bool onStart = false;
    public bool onTrigger = false;

	// Use this for initialization
	void Start () {
        if (onStart)
            WritingEvent.instance.setText(name);
	}

    void OnTriggerEnter()
    {
        if (onTrigger)
            WritingEvent.instance.setText(name);
    }
}
