using UnityEngine;
using System.Collections;

public class Level2_FallingTrigger : MonoBehaviour {

    bool fall = false;

    void OnTriggerEnter()
    {
        if (fall == false)
        {
            WritingEvent.instance.setText("Level2_Fail");
            fall = true;
        }
    }
}
