using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {

    float time = 0.0f;
    bool activ = true;

    public int level;

	// Update is called once per frame
	void Update () {
        if (activ)
            time += Time.deltaTime;
	}

    void OnTriggerEnter()
    {
        activ = false;
        time = Time.timeSinceLevelLoad;
        if (!PlayerPrefs.HasKey("Timer" + level.ToString()))
            PlayerPrefs.SetFloat("Timer" + level.ToString(), time);
        else
        {
            float old = PlayerPrefs.GetFloat("Timer" + level.ToString());
            if (old > time)
                PlayerPrefs.SetFloat("Timer" + level.ToString(), time);
        }
    }
}
