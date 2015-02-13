using UnityEngine;
using System.Collections;

public class CheckEnd : MonoBehaviour {

    void OnTriggerEnter (Collider other)
    {
        if (other.name.Equals("Player"))
            Debug.Log("FINISH");

        // ici on peut load la prochaine scene
    }

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
