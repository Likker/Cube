using UnityEngine;
using System.Collections;

public class MainRoom : MonoBehaviour {

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("notFirstGame"))
        {
            WritingEvent.instance.setText("Introduction");
            WritingEvent.instance.setText("IntroductionTwo");
            WritingEvent.instance.setText("IntroductionThree");
            WritingEvent.instance.setText("FirstOrder");
        }
	}
	
	// Update is called once per frame
	void Update () {
	
	}
}
