﻿using UnityEngine;
using System.Collections;

public class MainRoom_CubeKey : MonoBehaviour {

    public float timeToWait = 8.0f;

	// Use this for initialization
	void Start () {
        if (!PlayerPrefs.HasKey("notFirstGame"))
        {
            GetComponent<Rigidbody>().useGravity = false;
            StartCoroutine("WaitSomeTime");
            StartCoroutine("MessageCubeKey");
        }
        else
            timeToWait = 0.0f;
	}
	
    IEnumerator MessageCubeKey()
    {
        while (!this.GetComponent<objTook>().getOn())
            yield return 0;
        WritingEvent.instance.setText("CubeKey");
        StopCoroutine("MessageCubeKey");
    }

    IEnumerator WaitSomeTime()
    {
        while (timeToWait > 0.0f)
        {
            timeToWait -= Time.deltaTime;
            yield return 0;
        }

        GetComponent<Rigidbody>().useGravity = true;
    }

    public float getTime()
    {
        return (timeToWait);
    }
}
