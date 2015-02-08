using UnityEngine;
using System.Collections;

public class Receptacle : MonoBehaviour {

    private GameObject obj = null;

    public GameObject[] toActivate = null;
    public float timeToActivate = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (obj)
        {
            timeToActivate -= Time.deltaTime;
            if (obj.GetComponent<Rigidbody>())
            {
                obj.GetComponent<Rigidbody>().velocity /= 1.5f;
                obj.GetComponent<Rigidbody>().angularVelocity *= 1.01f;
            }
            if (timeToActivate <= 0.0f && toActivate != null)
            {
                foreach (GameObject tA in toActivate)
                    tA.SetActive(true);
            }
        }
	}

    void OnTriggerEnter(Collider coll)
    {
        if (coll.GetComponent<objTook>())
        {
            obj = coll.gameObject;
            coll.GetComponent<objTook>().setHand(this.gameObject);
            coll.GetComponent<objTook>().setOn(true);
            coll.GetComponent<objTook>().setEnable(false);
        }
    }
}
