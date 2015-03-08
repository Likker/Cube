using UnityEngine;
using System.Collections;

public class MoveZ : MonoBehaviour {

    // Use this for initialization
    public bool AR = true;
    public float z = 2;
    public double speed = 1;

    // Use this for initialization
    void Start()
    {
        if (AR)
            iTween.MoveBy(gameObject, iTween.Hash("z", z, "easeType", "linear", "loopType", "pingPong", "speed", speed));
        else
            iTween.MoveTo(gameObject, iTween.Hash("z", z, "easeType", "linear", "speed", speed));
    }

    // Update is called once per frame
    void Update()
    {

    }
}
