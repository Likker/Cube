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
    }

    void onTriggerExit(Collider other)
    {
        other.gameObject.transform.parent = null;
    }
 
}
