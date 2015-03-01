using UnityEngine;
using System.Collections;

public class btnLevel : MonoBehaviour {

    public GameObject okImg;
    public int lvl;

	// Use this for initialization
	void Start () {
        string tmp = "finishLvl" + lvl.ToString();

        if (PlayerPrefs.HasKey(tmp))
            okImg.SetActive(true);
        else
            okImg.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
