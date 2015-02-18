using UnityEngine;
using System.Collections;

public class MainRoom_AreaLightCubeKey : MonoBehaviour {

    public GameObject cubekey;

	// Use this for initialization
	void Start () {
        this.GetComponent<Light>().enabled = false;
        StartCoroutine(trameLight());
	}

    IEnumerator trameLight()
    {
        while (cubekey.GetComponent<MainRoom_CubeKey>().getTime() > 0.0f)
            yield return 0;
        this.GetComponent<Light>().enabled = true;
        while (!cubekey.GetComponent<objTook>().getOn())
            yield return 0;
        gameObject.SetActive(false);
    }
}
