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
	public float sprintSpeed = 7.65f;
	public float jumpForce = 100f;
	protected Vector3 velocity = Vector3.zero;
	protected Rigidbody characterBody;
	protected Collider characterCollider;
	protected bool canMove;
	protected bool onGround;
	private float lt;
	public Animator anim;
	private float mapArm = 1;
	private float mapChange = 3f;

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

		jump();

		gameObject.transform.Translate(velocity * Time.deltaTime);

		mapArm += mapChange * Time.deltaTime;
		mapArm = Mathf.Clamp01(mapArm);
		anim.SetFloat("MapArm", mapArm, 0, Time.deltaTime);
	}

	void LateUpdate()
	{

	}

	void inputs()
	{
		xInput = playerInput.getXTiltMove() * acceleration;
		zInput = playerInput.getZTiltMove() * acceleration;
		sprintInput = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

		if (!onGround)
		{
			jumpInput = false;
			jumping = false;
		}
		else if (Input.GetKeyDown(KeyCode.Space) && onGround)
			jumpInput = true;

		if (Input.GetKeyDown(KeyCode.M) || Input.GetKeyDown(KeyCode.Tab))
		{
			if (mapChange < 0)
			{
				mapChange = 3f;
			}
			else
			{
				mapChange = -3f;
			}
		}
	}

	void move()
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

		float speedPercent = 0;

		if (sprintInput)
		{
			velocity = Vector3.ClampMagnitude(new Vector3(velocity.x, 0, velocity.z), sprintSpeed) + new Vector3(0, velocity.y, 0);
			speedPercent = new Vector3(velocity.x, 0, velocity.z).magnitude / sprintSpeed;
		}
		else
		{
			velocity = Vector3.ClampMagnitude(new Vector3(velocity.x, 0, velocity.z), moveSpeed) + new Vector3(0, velocity.y, 0);
			speedPercent = new Vector3(velocity.x, 0, velocity.z).magnitude / (2 * moveSpeed);
		}
		anim.SetFloat("SpeedPercent", speedPercent, .1f, Time.deltaTime);
	}

	void jump()
	{
		if (onGround && jumpInput && !jumping)
		{
			characterBody.AddForce(new Vector3(0, jumpForce, 0));
			jumping = true;
		}
	}

	void OnTriggerEnter(Collider c)
	{
		if (c.gameObject.layer == 9)    //add raycast to object below to check if actually on it
			onGround = true;
	}

	void OnTriggerExit(Collider c)
	{
		if (c.gameObject.layer == 9)
			onGround = false;
	}
}
