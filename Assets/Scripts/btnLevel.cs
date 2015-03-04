using UnityEngine;
using System.Collections;

public class btnLevel : MonoBehaviour {

    public GameObject okImg;
    public int lvl;

	// Use this for initialization
	void Start () {
        string tmp = "finishLvl" + lvl.ToString();

        if (lvl > 1)
        {
            string lvlBefore = "finishLvl" + (lvl - 1).ToString();

            if (!PlayerPrefs.HasKey(lvlBefore))
            {
                gameObject.SetActive(false);
                return;
            }
        }
        if (PlayerPrefs.HasKey(tmp))
            okImg.SetActive(true);
        else
            okImg.SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
