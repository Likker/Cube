using UnityEngine;
using System.Collections;

public class ActiveOnTriggerEnter : MonoBehaviour {

    public GameObject[] toActivate;

	// Use this for initialization
	void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter()
    {
        foreach (GameObject g in toActivate)
        {
            g.SetActive(true);
        }
    }
}
