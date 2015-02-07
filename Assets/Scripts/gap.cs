using UnityEngine;
using System.Collections;

public class gap : MonoBehaviour {

    public Transform begin;
    public Transform end;
    public float smooth = 5.0f;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        RaycastHit hit;

        if (Physics.Raycast(transform.position, Vector3.up, out hit))
        {
            if (hit.transform.CompareTag("Player"))
                GetComponent<Rigidbody>().AddForce((end.position - transform.position) * smooth * Time.deltaTime);
            else
                GetComponent<Rigidbody>().AddForce((begin.position - transform.position) * smooth * Time.deltaTime);
        }
        else
            GetComponent<Rigidbody>().AddForce((begin.position - transform.position) * smooth * Time.deltaTime);
	}
}
