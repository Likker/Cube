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

    private Vector3 jumpMove = Vector3.zero;

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
        if (timeClimb < 0.7f)
            transform.position = new Vector3(transform.position.x, transform.position.y + ((distToClimb / 0.7f) * Time.deltaTime), transform.position.z);
        else if (timeClimb > 0.7f && timeClimb < 1.5f)
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

            this.HandleAnimation();

            Vector3 move;

            move = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));

            move.Normalize();
            move = transform.TransformDirection(move);

            float speed = (Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0.0f) ? speedRunning : speedWalking;

            control.SimpleMove(move * speed);

            print(jumpMove.y);

            if (this.isGrounded())
            {
                jumpMove.y = 0.0f;
                if (Input.GetButton("Jump") || Input.GetAxis("Jump") > 0.0f)
                    jumpMove.y = jump;
            }
            if (this.isGrounded() == false || jumpMove.y > 0.0f)
            {
                jumpMove.y += Time.deltaTime * Physics.gravity.y;
                control.Move(jumpMove * Time.deltaTime);
            }
        }
    }

    private void    HandleAnimation()
    {
        animator.SetInteger("isWalking", 0);
        animator.SetInteger("isRunning", 0);

        if (this.isGrounded())
        {
            if (Input.GetButton("Fire1") || Input.GetAxis("Fire1") > 0.0f)
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
