using UnityEngine;
using System.Collections;

public class AutomaticJump : MonoBehaviour {

    public float speed = 6.0F;
    public float jumpSpeed = 8.0F;
    public float gravity = 20.0F;
    private Vector3 moveDirection = Vector3.zero;
    private float nextActionTime = 0.0f; 
    public float period = 1f;

    private bool canMove;
    private bool turnLeft;
    private bool turnRight;
    private float rotationVal = 0f;
    private float temp = 0;
    private Transform myTransform;

	// Use this for initialization
	void Start () {
        canMove = true;
        myTransform = GameObject.Find("Player").transform;
	}
	
	// Update is called once per frame
	void Update () {
         

	    CharacterController controller = GetComponent<CharacterController>();
        if (controller.isGrounded) {
            moveDirection = new Vector3(0, 0, 1);
            moveDirection = transform.TransformDirection(moveDirection);
            moveDirection *= speed;
            
        }
        if (Time.time > nextActionTime)
        {
            nextActionTime += period;
            moveDirection.y = jumpSpeed;
        }
        moveDirection.y -= gravity * Time.deltaTime;
        controller.Move(moveDirection * Time.deltaTime);
      
        if (Input.GetKeyDown("d"))
        {
            transform.Rotate(transform.rotation.x, 90, transform.rotation.z);
        }
        else if (Input.GetKeyDown("q"))
        {
            transform.Rotate(transform.rotation.x, -90, transform.rotation.z);
        }
    }
}

