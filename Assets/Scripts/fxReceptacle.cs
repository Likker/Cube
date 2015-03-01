using UnityEngine;
using System.Collections;

public class fxReceptacle : MonoBehaviour {

    public Transform start;
    public Transform end;
    public float speed;

    private Vector3 dir;

    void Start()
    {
        dir = end.position - start.position;
        dir = dir / dir.magnitude;
    }

	// Update is called once per frame
	void Update () {
        transform.position += dir * Time.deltaTime * speed;
        if (Mathf.Abs((transform.position - end.position).magnitude) < 0.5f || Mathf.Abs((transform.position - start.position).magnitude) < 0.5f)
            dir = -dir;
    }
}
