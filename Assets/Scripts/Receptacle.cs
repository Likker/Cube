using UnityEngine;
using System.Collections;

public class Receptacle : MonoBehaviour {

    private GameObject obj = null;

    public GameObject[] toActivate = null;
    public float timeToActivate = 5.0f;
    public float timeToDesactivate = 15.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine("ActiveObject");
        StartCoroutine("StartDissolving");
	}
	
	// Update is called once per frame
	void Update () {
        if (obj)
        {
            timeToActivate -= Time.deltaTime;
            timeToDesactivate -= Time.deltaTime;
            if (obj.GetComponent<Rigidbody>() && timeToDesactivate > 0.0f)
            {
                obj.GetComponent<Rigidbody>().velocity /= 1.5f;
                obj.GetComponent<Rigidbody>().angularVelocity *= 1.01f;
            }
            else if (timeToDesactivate <= 0.0f)
                obj.GetComponent<Rigidbody>().angularVelocity /= 1.01f;
        }
	}

    IEnumerator ActiveObject()
    {
        while (timeToActivate > 0.0f)
            yield return 0;
        if (toActivate != null)
        {
            foreach (GameObject tA in toActivate)
                tA.SetActive(true);
        }
    }

    IEnumerator StartDissolving()
    {
        while (timeToActivate > 0.0f)
            yield return 0;
        while (obj.renderer.material.GetFloat("_SliceAmount") < 1.0f)
        {
            obj.renderer.material.SetFloat("_SliceAmount", obj.renderer.material.GetFloat("_SliceAmount") + (Time.deltaTime / 15.0f));
            yield return 0;
        }
        gameObject.animation.Play("Close");
        StartCoroutine("Disapear");
    }

    IEnumerator Disapear()
    {
        while (gameObject.animation.isPlaying)
            yield return 0;
        obj.SetActive(false);
        while (transform.position.y > -20.0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return 0;
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

            if (obj.GetComponent<Rigidbody>())
            {
                obj.GetComponent<Rigidbody>().angularVelocity = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}
