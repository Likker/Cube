using UnityEngine;
using System.Collections;

public class switchLight : MonoBehaviour {

    public float intensity = 1.0f;
    public float smooth = 0.1f;
    public bool turnOn = true;
	
	// Update is called once per frame
	void Update () {
        if (GetComponent<Light>())
        {
            if (turnOn)
            {
                GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, intensity, smooth * Time.deltaTime);
            }
            else
            {
                GetComponent<Light>().intensity = Mathf.Lerp(GetComponent<Light>().intensity, 0.0f, smooth * Time.deltaTime);
            }
        }
	}
}
