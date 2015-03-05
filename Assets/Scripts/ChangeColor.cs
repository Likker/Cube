using UnityEngine;
using System.Collections;

public class ChangeColor : MonoBehaviour {

    public Color color = Color.white;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
        gameObject.renderer.material.color = color;
	}
}
