using UnityEngine;
using System.Collections;

public class crosshair : MonoBehaviour {

    public Sprite crossHair;

    private Rect pos;


	// Use this for initialization
	void Start () {
        pos = new Rect((Screen.width - crossHair.texture.width) / 2.0f, (Screen.height - crossHair.texture.height) / 2.0f, crossHair.texture.width, crossHair.texture.height);
        Screen.showCursor = false;
	}

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
            Application.Quit();
    }

    void OnGUI()
    {
        GUI.DrawTexture(pos, crossHair.texture);
    }
}
