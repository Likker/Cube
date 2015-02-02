using UnityEngine;
using System.Collections;

public class MovementController : MonoBehaviour {

    private Animator animator;
    protected CharacterController control;

    public float speedRunning = 10.0f;
    public float speedWalking = 5.0f;
    public float jump = 5.0f;

    public Transform foot;
    public Transform rightHand;
    public Transform cam;

    private Transform nextFoot = null;
    private float timeClimb = 0.0f;
    private float distToClimb = 0.0f;

	// Use this for initialization
	void Start () {
        animator = GetComponentInChildren<Animator>();
        control = GetComponent<CharacterController>();
	}
	
    bool isGrounded()
    {
        return (Physics.Raycast(foot.position, Vector3.down, 0.5f));
    }

    private void Climb()
    {
        timeClimb += Time.deltaTime;
        if (timeClimb < 1.40f)
            transform.position = new Vector3(transform.position.x, transform.position.y + ((distToClimb / 1.40f) * Time.deltaTime), transform.position.z);
        else if (timeClimb > 1.40f && timeClimb < 3.0f)
            transform.position += transform.forward * Time.deltaTime;
    }

	// Update is called once per frame
    void Update()
    {
        AnimatorStateInfo state = animator.GetCurrentAnimatorStateInfo(0);

        if (state.IsName("Base Layer.Climb"))
        {
            GetComponent<MouseLook>().enabled = false;
            this.Climb();
        }
        else
        {
            GetComponent<MouseLook>().enabled = true;
        }

        this.HandleAnimation();

        Vector3 move;

        if (Input.GetButtonDown("Jump"))
            move = new Vector3(Input.GetAxis("Horizontal"), jump, Input.GetAxis("Vertical"));
        else
            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

        move.Normalize();
        move = transform.TransformDirection(move);

        float speed = Input.GetKey(KeyCode.LeftShift) ? speedRunning : speedWalking;

        control.SimpleMove(move * speed);
    }

    private void    HandleAnimation()
    {
        animator.SetInteger("isWalking", 0);
        animator.SetInteger("isRunning", 0);

        if (this.isGrounded())
        {
            if (Input.GetKey(KeyCode.LeftShift))
            {
                if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
                    animator.SetInteger("isRunning", 1);
            }
            else
            {
                if (Input.GetAxis("Vertical") != 0.0f || Input.GetAxis("Horizontal") != 0.0f)
                    animator.SetInteger("isWalking", 1);
            }
        }
    }

    void    OnTriggerEnter(Collider coll)
    {
       if (coll.CompareTag("TriggerClimb"))
       {
           if (Physics.Raycast(cam.position, transform.forward, 1.0f) || Physics.Raycast(foot.position, transform.forward, 1.0f))
            {
                animator.SetTrigger("isClimbing");
                nextFoot = coll.GetComponentInChildren<Transform>();
                timeClimb = 0.0f;
                distToClimb = nextFoot.position.y - foot.position.y + 1.5f;
            }
       }
    }
}
