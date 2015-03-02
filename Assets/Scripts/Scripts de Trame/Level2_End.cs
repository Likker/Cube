using UnityEngine;
using System.Collections;

public class Level2_End : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter()
    {
        WritingEvent.instance.setText("Level2_Success");
        player.GetComponent<MovementController>().enabled = false;
        PlayerPrefs.SetInt("finishLvl2", 1);
    }
}
