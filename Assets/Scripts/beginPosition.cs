using UnityEngine;
using System.Collections;

public class beginPosition : MonoBehaviour {


    public GameObject BeginDoor;
	// Use this for initialization
	void Start () {

        // Initialize player position

        this.transform.position = new Vector3(BeginDoor.transform.position.x + 3.5f,
                                              BeginDoor.transform.position.y + 3,
                                              BeginDoor.transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
