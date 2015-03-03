using UnityEngine;
using System.Collections;

public class MoveY : MonoBehaviour {

	// Use this for initialization
    public float y = 2;
    public double speed = 1;

    // Use this for initialization
    void Start()
    {
        iTween.MoveBy(gameObject, iTween.Hash("y", y, "easeType", "linear", "loopType", "pingPong", "speed", speed));
    }
	
	// Update is called once per frame
	void Update () {
	
	}
}
