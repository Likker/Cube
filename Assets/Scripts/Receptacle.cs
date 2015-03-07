using UnityEngine;
using System.Collections;

public class Receptacle : MonoBehaviour {

    private GameObject obj = null;

    public GameObject[] toActivate = null;
    public float timeToActivate = 5.0f;
    public float timeToDesactivate = 15.0f;

    public GameObject receptacleFX = null;
    public AudioClip sound;

    private float tmpTime;

	// Use this for initialization
	void Start () {
        StartCoroutine("ActiveObject");
        StartCoroutine("StartDissolving");
        tmpTime = timeToDesactivate;
	}
	
	// Update is called once per frame
	void Update () {
        if (obj)
        {
            timeToActivate -= Time.deltaTime;
            tmpTime -= Time.deltaTime;
            if (obj.GetComponent<Rigidbody>() && tmpTime > 0.0f)
            {
                obj.GetComponent<Rigidbody>().velocity /= 1.5f;
                obj.GetComponent<Rigidbody>().angularVelocity *= 1.01f;
            }
            else if (tmpTime <= 0.0f)
                obj.GetComponent<Rigidbody>().angularVelocity /= 1.01f;
        }
	}

    IEnumerator ActiveObject()
    {
        while (timeToActivate > 0.0f)
            yield return 0;
        if (toActivate.Length > 0)
        {
            foreach (GameObject tA in toActivate)
                if (tag != null)
                    tA.SetActive(true);
        }
    }

    IEnumerator StartDissolving()
    {
        while (timeToActivate > 0.0f)
            yield return 0;
        while (obj.renderer.material.GetFloat("_SliceAmount") < 1.0f)
        {
            obj.renderer.material.SetFloat("_SliceAmount", obj.renderer.material.GetFloat("_SliceAmount") + (Time.deltaTime / timeToDesactivate));
            if (obj.GetComponent<PKFxFX>()){
                Vector4 color = new Vector4(0.0f, 0.50f - (obj.renderer.material.GetFloat("_SliceAmount") / 2.0f), 1.0f - obj.renderer.material.GetFloat("_SliceAmount"), 1.0f);
                obj.GetComponent<PKFxFX>().SetAttribute(new PKFxManager.Attribute("ColorFadeIn", color));
                obj.GetComponent<PKFxFX>().SetAttribute(new PKFxManager.Attribute("ColorFadeOut", color));
            }
            yield return 0;
        }
        if (receptacleFX != null)
            receptacleFX.GetComponent<PKFxFX>().StopEffect();
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
            audio.PlayOneShot(sound);
            if (obj.GetComponent<Rigidbody>())
            {
                obj.GetComponent<Rigidbody>().angularVelocity = new Vector3(1.0f, 1.0f, 1.0f);
            }
        }
    }
}
