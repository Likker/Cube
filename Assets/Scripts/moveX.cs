using UnityEngine;
using System.Collections;

public class moveX : MonoBehaviour {

    public float x = 2;
    public double speed = 1;

	// Use this for initialization
	void Start () {
        iTween.MoveBy(gameObject, iTween.Hash("x", x, "easeType", "linear", "loopType", "pingPong", "speed", speed));
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
