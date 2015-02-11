using UnityEngine;
using System.Collections;

public class MainRoom_Portal : MonoBehaviour {

    public GameObject cubeKey;

	// Use this for initialization
	void Start () {
        StartCoroutine("DownPortal");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DownPortal()
    {
        while (cubeKey.activeSelf == true)
            yield return 0;
        GetComponent<mainPortalBehavior>().enabled = false;
        while (transform.position.y > 0.0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return 0;
        }
    }
}
