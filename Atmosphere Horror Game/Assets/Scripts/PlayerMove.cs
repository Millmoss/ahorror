using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerMove : MonoBehaviour
{
	private GlobalInput playerInput;
	private float xInput;
	private float zInput;
	private bool jumpInput;
	private bool jumping = false;
	private bool sprintInput;
	public float acceleration = 3f;
	public float moveSpeed = 4.5f;
	public float sprintSpeed = 8.5f;
	public float jumpForce = 100f;
	public float gravityForce = 10f;
	public float mass = 70f;
	public float height = 1.7f;                 //effective height of character for gameplay purposes
	public float stepHeight = .3f;
	protected Vector3 velocity = Vector3.zero;
	protected Rigidbody characterBody;
	protected Collider characterCollider;
	protected bool canMove;
	protected bool onGround;

	void Start()
	{
		canMove = true;
		playerInput = gameObject.GetComponent<GlobalInput>();
		characterBody = gameObject.GetComponent<Rigidbody>();
		characterCollider = gameObject.GetComponent<CapsuleCollider>();

		characterBody.freezeRotation = true;
	}

	void Update()
	{
		inputs();
	}

	void FixedUpdate()
	{
		move();

		gameObject.transform.Translate(velocity * Time.deltaTime);
	}

	void LateUpdate()
	{

	}

	private void inputs()
	{
		xInput = playerInput.getXTiltMove() * acceleration;
		zInput = playerInput.getZTiltMove() * acceleration;
		sprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);
		
		if (!onGround)
			jumpInput = false;
		else if (Input.GetKeyDown(KeyCode.Space) && onGround)
			jumpInput = true;
	}

	private void move()
	{
		if (!canMove)
		{
			return;
		}

		//convert input to acceleration

		xInput *= acceleration;
		zInput *= acceleration;

		if (!onGround)
		{
			xInput /= 50;
			zInput /= 50;
		}

		if (velocity.magnitude > moveSpeed)
		{
			xInput /= 10;
			zInput /= 10;
		}

		if (xInput != 0)
		{
			velocity.x += xInput * Time.deltaTime;
		}
		else
		{
			velocity.x = Mathf.Lerp(velocity.x, 0, Time.deltaTime * 18);
		}

		if (zInput != 0)
		{
			velocity.z += zInput * Time.deltaTime;
		}
		else
		{
			velocity.z = Mathf.Lerp(velocity.z, 0, Time.deltaTime * 18);
		}

		//limit to max speed

		if (sprintInput)
		{
			velocity = Vector3.ClampMagnitude(new Vector3(velocity.x, 0, velocity.z), sprintSpeed) + new Vector3(0, velocity.y, 0);
		}
		else
		{
			velocity = Vector3.ClampMagnitude(new Vector3(velocity.x, 0, velocity.z), moveSpeed) + new Vector3(0, velocity.y, 0);
		}
	}

	private void gravity()
	{
		if (!onGround)
			velocity.y -= Time.deltaTime * gravityForce;
	}

	public void lockMovement()
	{
		canMove = false;
	}

	public void unlockMovement()
	{
		canMove = true;
	}
}
