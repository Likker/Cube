using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class FadeInOut : MonoBehaviour {

    public Image _fading;
    public float _speed = 1.0f;

	// Use this for initialization
	void Start () {
        _fading.color = Color.black;
        StartCoroutine("fadeIn");
	}

    public IEnumerator fadeIn()
    {
        while (_fading.color.a > 0.05f)
        {
            _fading.color = Color.Lerp(_fading.color, Color.clear, _speed * Time.deltaTime);
            yield return 0;
        }
        _fading.color = Color.clear;
    }

    public IEnumerator fadeOut()
    {
        while (_fading.color.a < 0.95f)
        {
            _fading.color = Color.Lerp(_fading.color, Color.black, _speed * Time.deltaTime);
            yield return 0;
        }
        _fading.color = Color.black;
    }
}
