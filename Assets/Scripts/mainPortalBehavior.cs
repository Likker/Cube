using UnityEngine;
using System.Collections;

public class mainPortalBehavior : MonoBehaviour {

    private float factor = 1.0f;
    private Vector3 initialPos;

    public float maxY = 1.0f;
    public float minY = 1.0f;
    public float speed = 10.0f;

	// Use this for initialization
	void Start () {
        initialPos = new Vector3(transform.position.x, transform.position.y, transform.position.z);
	}
	
	// Update is called once per frame
	void Update () {
        if ((transform.position.y > initialPos.y + maxY) || (transform.position.y < initialPos.y - minY))
            factor = -factor;
        transform.Translate(0.0f, factor * speed * Time.deltaTime, 0.0f);
	}
}
