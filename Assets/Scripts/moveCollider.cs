using UnityEngine;
using System.Collections;

public class moveCollider : MonoBehaviour {

    public GameObject platform;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    void OnTriggerEnter(Collider other)
    {
        other.gameObject.transform.parent = platform.transform;
        Debug.Log("ENTER");
    }

    void OnTriggerExit(Collider other)
    {
        other.gameObject.transform.parent = null;
        Debug.Log("EXIT");
    }
 
}
