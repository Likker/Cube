using UnityEngine;
using System.Collections;

public class Level1_LightWay : MonoBehaviour {

    public Transform[] positions;
    public float _duration = 0.1f;
    public float _timetoWait = 3.0f;

	// Use this for initialization
	void Start () {
        StartCoroutine("followWay");	
	}

    IEnumerator followWay()
    {
        while (_timetoWait > 0.0f)
        {
            _timetoWait -= Time.deltaTime;
            yield return 0;
        }
        foreach (Transform t in positions)
        {
            yield return StartCoroutine(goToPos(t));
        }

    }

    IEnumerator goToPos(Transform t)
    {
        float startTime = Time.time;

        while (!this.isNear(t.position, transform.position))
        {
            transform.position = Vector3.Lerp(transform.position, t.position, (Time.time - startTime) / (_duration * Time.deltaTime));
            yield return 0;
        }
    }

    bool isNear(Vector3 a, Vector3 b)
    {
        return (Mathf.Abs((a - b).magnitude) < 0.1f);
    }
}
