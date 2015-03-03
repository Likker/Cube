using UnityEngine;
using System.Collections;

public class CheckActive : MonoBehaviour {

    public enum Enum { MoveToY, Test2, Test3 };

    //This is what you need to show in the inspector.
    public Enum myEnum;
    public GameObject obj;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
        if (obj.activeSelf)
        {
            if (myEnum == Enum.MoveToY)
                this.GetComponent<MoveY>().enabled = true;
        }
        
	}
}
