using UnityEngine;
using System.Collections;

public class MainRoom_Teleporter : MonoBehaviour {

    private string level = "";
    public float timeBetweenSwitch = 1.5f;

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
                Application.LoadLevel(level);
            }
    }
}
