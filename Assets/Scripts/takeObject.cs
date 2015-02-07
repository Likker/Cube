using UnityEngine;
using System.Collections;

public class takeObject : MonoBehaviour {

    public Camera cam;
    public GameObject hand;

    private GameObject obj = null;
        
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
                    }
                }
            }
            else
            {
                obj.GetComponent<objTook>().setOn(false);
                obj = null;
            }
        }
	}
}
