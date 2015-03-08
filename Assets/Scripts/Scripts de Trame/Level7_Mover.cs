using UnityEngine;
using System.Collections;

public class Level7_Mover : MonoBehaviour {

    public GameObject toMove;

	// Use this for initialization
	void Start () {
        iTween.MoveTo(toMove, iTween.Hash("y", 0, "easeType", "linear", "speed", 1));
	}
}
