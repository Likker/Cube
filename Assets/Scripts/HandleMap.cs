using UnityEngine;
using System.Collections;

public class HandleMap : MonoBehaviour {

    public GameObject[] objList;
    public int i = 0;


	// Use this for initialization
	void Start () {
        StartCoroutine(CallAgain(i));
	}
	
	// Update is called once per frame
	void Update () {

        

    }	

    IEnumerator CallAgain(int i)
    {
        while (i < objList.GetLength(0))
        {
            NextStep(i);
            yield return new WaitForSeconds(2);
            i++;
        }

    }

    void NextStep(int i)
    {
        Debug.Log("OK");
        ChangeColor color = objList[i].GetComponent<ChangeColor>();
        color.color = new Color(0, 0.6f, 0);
        
        if (i + 1 < objList.GetLength(0))
        {
            ChangeColor color2 = objList[i + 1].GetComponent<ChangeColor>();
            color2.color = new Color(0, 0.8f, 0);
        }
        if (i + 2 < objList.GetLength(0))
        {
            ChangeColor color3 = objList[i + 2].GetComponent<ChangeColor>();
            color3.color = new Color(0, 1, 0, 1f);
        }
        if (i > 0)
        {
            ChangeColor color4 = objList[i-1].GetComponent<ChangeColor>();
            color4.color = Color.white;
        }
       
    }
}
