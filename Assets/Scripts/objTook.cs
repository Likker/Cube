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
                Vector3 translate = _hand.transform.position - transform.position;

                GetComponent<Rigidbody>().rigidbody.velocity = (GetComponent<Rigidbody>().rigidbody.velocity + (translate * _speed * Time.deltaTime)) / 2.0f;
            }
        }
	}

    public void setOn(bool on)
    {
        if (_enable)
        {
            _on = on;
            if (GetComponent<Rigidbody>())
            {
                GetComponent<Rigidbody>().useGravity = !on;
            }
        }
    }

    public void eject(Vector3 dir)
    {
        if (_enable)
        {
            this.setOn(false);
            GetComponent<Rigidbody>().rigidbody.velocity = dir * _speed * 0.1f;
        }
    }

    public bool getOn() { return (_on); }

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
