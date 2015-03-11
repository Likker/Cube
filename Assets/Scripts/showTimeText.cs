using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class showTimeText : MonoBehaviour {

    public Text TimeText;

	// Use this for initialization
	void Start () {
        Color mycolor = TimeText.color;
        mycolor.a = 0;
        TimeText.color = mycolor;
	}

    public void showText(int level)
    {
        string txt = "Niveau " + level.ToString() + " : ";
        Color mycolor = TimeText.color;
        
        mycolor.a = 0;
        TimeText.color = mycolor;
        if (PlayerPrefs.HasKey("Timer" + level.ToString()))
        {
            int min;
            int sec;
            int ms;
            float   time = PlayerPrefs.GetFloat("Timer" + level.ToString());

            min = (int)(time / 60.0f);
            time -= (float)(min * 60);
            sec = (int)time;
            time -= (float)sec;
            ms = (int)(time * 1000.0f);

            txt += min.ToString() + "'" + sec.ToString() + "''" + ms.ToString();
        }
        else
        {
            txt += "00'00''00";
        }
        TimeText.text = txt;
        StartCoroutine("appear");
    }

    IEnumerator appear()
    {
        float   time = Time.time;
        while (TimeText.color.a < 1)
        {
            float a = Mathf.Lerp(1, 0, (time - Time.time) / 3.0f);
            Color myColor = TimeText.color;

            myColor.a = a;
            TimeText.color = myColor;
            yield return 0;
        }
    }
}
