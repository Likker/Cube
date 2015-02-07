using UnityEngine;
using System.Collections;

public class RotateCube : MonoBehaviour {
	
    public  float speed = 20.0f;

	// Update is called once per frame
	void Update () {
        transform.Rotate(0.0f, speed * Time.deltaTime, 0.0f);
	}
}
