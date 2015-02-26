using UnityEngine;
using System.Collections;

public class Level1_FallingTrigger : MonoBehaviour {

    bool fall = false;

    void OnTriggerEnter()
    {
        if (fall == false)
        {
            WritingEvent.instance.setText("Level1_Fail");
            fall = true;
        }
    }
}
