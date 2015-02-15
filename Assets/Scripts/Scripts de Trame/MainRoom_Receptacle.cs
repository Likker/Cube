using UnityEngine;
using System.Collections;

public class MainRoom_Receptacle : MonoBehaviour {

    public GameObject cubeKey;

	// Use this for initialization
	void Start () {
        StartCoroutine("checkForOpen");
	}

    IEnumerator checkForOpen()
    {
        while (!cubeKey.GetComponent<objTook>().getOn())
            yield return 0;
        gameObject.animation.Play("Open");
    }
	
	
}
