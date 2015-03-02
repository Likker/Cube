using UnityEngine;
using System.Collections;

public class MainRoom_Teleporter : MonoBehaviour {

    public string level = "";
    public float timeBetweenSwitch = 1.5f;
    public FadeInOut fader;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void setNewLevel(string lvl){
        level = lvl;
        StartCoroutine("switchTelep");
    }

    IEnumerator switchTelep()
    {
        float time = 0.0f;

        if (GetComponent<PKFxFX>())
            GetComponent<PKFxFX>().StopEffect();
        while (time < timeBetweenSwitch)
        {
            time += Time.deltaTime;
            yield return 0;
        }
        if (GetComponent<PKFxFX>())
            GetComponent<PKFxFX>().StartEffect();
    }

    void OnTriggerEnter(Collider coll)
    {
        if (coll.CompareTag("Player"))
            if (level != "")
            {
                if (coll.GetComponent<MovementController>())
                    coll.GetComponent<MovementController>().enabled = false;
                StartCoroutine(loadLevel());
            }
    }

    IEnumerator loadLevel()
    {
        while (WritingEvent.instance.isWriting())
            yield return 0;
        yield return StartCoroutine(fader.fadeOut());
        Application.LoadLevel(level);
    }
}
