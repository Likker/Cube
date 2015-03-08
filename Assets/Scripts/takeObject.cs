using UnityEngine;
using System.Collections;

public class takeObject : MonoBehaviour {

    public Camera cam;
    public GameObject hand;

    private GameObject obj = null;

    public AudioSource TakeObject;
    public AudioSource ThrowObject;
        
        // Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire2"))
        {
            if (obj == null)
            {
                RaycastHit hit;

                if (Physics.Raycast(cam.transform.position, cam.transform.forward, out hit, 5.0f))
                {
                    if (hit.transform.GetComponent<objTook>())
                    {
                        obj = hit.transform.gameObject;
                        obj.GetComponent<objTook>().setOn(true);
                        obj.GetComponent<objTook>().setHand(hand);
                        TakeObject.Play();
                    }
                }
            }
            else
            {
                obj.GetComponent<objTook>().setOn(false);
                obj = null;
            }
        }
        else if (Input.GetButtonDown("Fire3"))
        {
            if (obj != null)
            {
                if (obj.GetComponent<objTook>())
                {
                    obj.GetComponent<objTook>().eject(cam.transform.forward.normalized);
                    obj = null;
                    ThrowObject.Play();
                }
            }
        }
	}
}
