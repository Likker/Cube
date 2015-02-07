using UnityEngine;
using System.Collections;

public class objTook : MonoBehaviour {

    public float _speed = 10.0f;

    private bool _on;
    private GameObject _hand;
    private bool _enable = true;

	// Update is called once per frame
	void Update () {
        if (_on)
        {
            if (GetComponent<Rigidbody>())
            {
                //GetComponent<Rigidbody>().isKinematic = true;
                GetComponent<Rigidbody>().useGravity = false;

                Vector3 translate = _hand.transform.position - transform.position;

                GetComponent<Rigidbody>().rigidbody.velocity = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().rigidbody.velocity.x, -3.0f, 3.0f),
                                                                            Mathf.Clamp(GetComponent<Rigidbody>().rigidbody.velocity.y, -3.0f, 3.0f),
                                                                            Mathf.Clamp(GetComponent<Rigidbody>().rigidbody.velocity.z, -3.0f, 3.0f));
                GetComponent<Rigidbody>().rigidbody.angularVelocity = new Vector3(Mathf.Clamp(GetComponent<Rigidbody>().rigidbody.angularVelocity.x, -3.0f, 3.0f),
                                                                           Mathf.Clamp(GetComponent<Rigidbody>().rigidbody.angularVelocity.y, -3.0f, 3.0f),
                                                                           Mathf.Clamp(GetComponent<Rigidbody>().rigidbody.angularVelocity.z, -3.0f, 3.0f));
                  
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
        if (_enable)
            _on = on;
    }

    public void setHand(GameObject hand)
    {
        if (_enable)
            _hand = hand;
    }

    public void setEnable(bool enable)
    {
        _enable = enable;
    }
}
