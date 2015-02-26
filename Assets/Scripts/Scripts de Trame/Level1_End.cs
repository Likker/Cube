using UnityEngine;
using System.Collections;

public class Level1_End : MonoBehaviour {

    public GameObject player;

    void OnTriggerEnter()
    {
        WritingEvent.instance.setText("Level1_Success");
        player.GetComponent<MovementController>().enabled = false;
    }
}
