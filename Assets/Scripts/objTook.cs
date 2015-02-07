using UnityEngine;
using System.Collections;

public class objTook : MonoBehaviour {

    public float _speed = 10.0f;

    private bool _on;
    private GameObject _hand;
	
	// Update is called once per frame
	void Update () {
        if (_on)
        {
            if (GetComponent<Rigidbody>())
            {
                //GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().useGravity = false;

                Vector3 translate = _hand.transform.position - transform.position;

                /*if (this.CheckLittleVector(translate, 1.0f) && !this.CheckLittleVector(GetComponent<Rigidbody>().velocity, 15.0f))
                {*/
                    GetComponent<Rigidbody>().rigidbody.velocity /= 1.05f;// Vector3.zero;
                    GetComponent<Rigidbody>().rigidbody.angularVelocity /= 1.05f;// Vector3.zero;
                //}
                GetComponent<Rigidbody>().AddForce(translate * _speed * Time.deltaTime);
            }

//            transform.Translate(translate * _speed * Time.deltaTime);
        }
        else
        {
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().useGravity = true;
                GetComponent<Rigidbody>().isKinematic = false;
            }
        }
	}

    public void setOn(bool on)
    {
        _on = on;
    }

    public void setHand(GameObject hand)
    {
        _hand = hand;
    }

    private bool CheckLittleVector(Vector3 vect, float val)
    {
        if (vect.x > -val && vect.x < val
            && vect.y > -val && vect.y < val
            && vect.z > -val && vect.z < val)
            return (true);
        return (false);
    }
}
