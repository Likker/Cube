using UnityEngine;
using System.Collections;

public class MainRoom_AreaLightCubeKey : MonoBehaviour {

    public GameObject cubekey;

	// Use this for initialization
	void Start () {
        light.intensity = 0.0f;
        StartCoroutine(trameLight());
	}

    IEnumerator trameLight()
    {
        while (!cubekey.GetComponent<Rigidbody>().useGravity)
            yield return 0;
        GetComponent<Light>().intensity = 0.4f;
        while (!cubekey.GetComponent<objTook>().getOn())
            yield return 0;
        this.gameObject.SetActive(false);
    }
}
