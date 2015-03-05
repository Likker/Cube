using UnityEngine;
using System.Collections;

public class Level4_Cache : MonoBehaviour {

    public float _timeToWait;
    public Transform _goto;

    void Start()
    {
        StartCoroutine(Cache());
    }

	// Update is called once per frame
	IEnumerator Cache() {
        while (_timeToWait > 0.0f){
            _timeToWait -= Time.deltaTime;
            yield return 0;
        }
        while (Mathf.Abs((_goto.position - transform.position).magnitude) > 0.5f)
        {
            transform.position = Vector3.Lerp(transform.position, _goto.position, Time.deltaTime * 1.0f);
            yield return 0;
        }
        gameObject.SetActive(false);
	}
}
