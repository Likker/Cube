using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class MainRoom_Portal : MonoBehaviour {

    public GameObject cubeKey;

    public Text[] textToAppear;
    public Image[] imgToAppear;

    public float speedToAppear = 400.0f;

	// Use this for initialization
	void Start () {
        foreach (Text t in textToAppear)
            t.color = new Color(t.color.r, t.color.g, t.color.b, 0.0f);
        foreach (Image i in imgToAppear)
            i.color = new Color(i.color.r, i.color.g, i.color.b, 0.0f);
        StartCoroutine("DownPortal");
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    IEnumerator DownPortal()
    {
        while (cubeKey.activeSelf == true)
            yield return 0;
        GetComponent<mainPortalBehavior>().enabled = false;
        while (transform.position.y > 0.0f)
        {
            transform.Translate(Vector3.down * Time.deltaTime);
            yield return 0;
        }
        
        while (textToAppear[0].color.a < 255)
        {
            foreach (Text t in textToAppear)
            {
                t.color = new Color(t.color.r, t.color.g, t.color.b, t.color.a + (speedToAppear * Time.deltaTime));
            }
            foreach (Image i in imgToAppear)
            {
                i.color = new Color(i.color.r, i.color.g, i.color.b, i.color.a + (speedToAppear * Time.deltaTime));
            }
            yield return 0;
        }


    }
}
