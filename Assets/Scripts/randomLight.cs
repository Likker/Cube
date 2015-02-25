using UnityEngine;
using System.Collections;

public class randomLight : MonoBehaviour {

    public float minIntensity;
    public float maxIntensity;

    float random;

    void Start()
    {
        random = Random.Range(0.0f, 65535.0f);
    }

    void Update()
    {
        float noise = Mathf.PerlinNoise(random, Time.time);
        light.range = Mathf.Lerp(minIntensity, maxIntensity, noise);
    }
}
