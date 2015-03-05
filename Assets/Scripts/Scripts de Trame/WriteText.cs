using UnityEngine;
using System.Collections;

public class WriteText : MonoBehaviour {

    public string name = "";
    public bool onStart = false;
    public bool onTrigger = false;
    public bool catchPlayer = false;

	// Use this for initialization
	void Start () {
        if (onStart)
            WritingEvent.instance.setText(name);
	}

    void OnTriggerEnter(Collider coll)
    {
        if (onTrigger)
        {
            if ((catchPlayer && coll.CompareTag("Player")) || !catchPlayer)
                WritingEvent.instance.setText(name);
        }
    }
}
