using UnityEngine;
using System.Collections;

public class addPlayerPref : MonoBehaviour {

    public string key = "";

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        PlayerPrefs.SetInt(key, 1);
    }
}
