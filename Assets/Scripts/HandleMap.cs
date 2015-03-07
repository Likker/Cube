using UnityEngine;
using System.Collections;

public class HandleMap : MonoBehaviour {

    public GameObject[] objList;
    public int i = 0;
    public float YUp;
    public float YDown;
    public int timer = 2;


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
            yield return new WaitForSeconds(timer);
            i++;
        }

    }

    void NextStep(int i)
    {
        ChangeColor color = objList[i].GetComponent<ChangeColor>();
        color.color = new Color(0, 0.8f, 0);
        objList[i].transform.localPosition = new Vector3(objList[i].transform.localPosition.x,
                                                         YUp,
                                                         objList[i].transform.localPosition.z);
   
        if (i + 1 < objList.GetLength(0))
        {
            ChangeColor color2 = objList[i + 1].GetComponent<ChangeColor>();
            color2.color = new Color(0, 1f, 0);
            objList[i+1].transform.localPosition = new Vector3(objList[i+1].transform.localPosition.x,
                                                         YUp,
                                                         objList[i+1].transform.localPosition.z);
            
        }
        if (i > 0)
        {
            ChangeColor color4 = objList[i-1].GetComponent<ChangeColor>();
            color4.color = Color.white;
            objList[i - 1].transform.localPosition = new Vector3(objList[i - 1].transform.localPosition.x,
                                                        YDown,
                                                        objList[i - 1].transform.localPosition.z);
        }
       
    }
}
